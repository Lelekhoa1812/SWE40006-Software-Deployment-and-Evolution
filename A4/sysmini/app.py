from fastapi import FastAPI
from fastapi.responses import HTMLResponse, JSONResponse
import psutil, os

app = FastAPI(title="SysMini")

INDEX_HTML = """
<!doctype html>
<html>
  <head>
    <meta charset="utf-8">
    <title>SysMini</title>
    <style>
      body { font-family: sans-serif; max-width: 720px; margin: 40px auto; }
      table { border-collapse: collapse; width: 100%; margin-top: 20px; }
      th, td { border: 1px solid #ccc; padding: 8px; text-align: center; }
      th { background: #f2f2f2; }
    </style>
  </head>
  <body>
    <h1>SysMini Metrics</h1>
    <table>
      <thead>
        <tr>
          <th>CPU (%)</th>
          <th>Memory (%)</th>
          <th>Load Avg (1m)</th>
          <th>Load Avg (5m)</th>
          <th>Load Avg (15m)</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td id="cpu">-</td>
          <td id="mem">-</td>
          <td id="l1">-</td>
          <td id="l5">-</td>
          <td id="l15">-</td>
        </tr>
      </tbody>
    </table>
    <script>
      async function poll(){
        try {
          const res = await fetch('/metrics');
          const j = await res.json();
          document.getElementById('cpu').innerText = j.cpu_percent;
          document.getElementById('mem').innerText = j.mem_percent;
          document.getElementById('l1').innerText = j.loadavg[0];
          document.getElementById('l5').innerText = j.loadavg[1];
          document.getElementById('l15').innerText = j.loadavg[2];
        } catch(e) {
          console.error("Error fetching metrics", e);
        }
      }
      poll();
      setInterval(poll, 2000);
    </script>
  </body>
</html>

"""

@app.get("/", response_class=HTMLResponse)
def index():
    return INDEX_HTML

@app.get("/health")
def health():
    return {"status":"ok"}

@app.get("/metrics")
def metrics():
    cpu = psutil.cpu_percent(interval=0.2)
    mem = psutil.virtual_memory().percent
    load = os.getloadavg() if hasattr(os, "getloadavg") else (0.0, 0.0, 0.0)
    return JSONResponse({"cpu_percent": cpu, "mem_percent": mem, "loadavg": load})
