from fastapi import FastAPI, HTTPException
from pydantic import BaseModel

app = FastAPI(title="FastAPI Calculator")

class CalcRequest(BaseModel):
    a: float
    b: float

@app.get("/")
def health():
    return {"message": "FastAPI Calculator is running. See /docs for API."}

@app.post("/add")
def add(req: CalcRequest):
    return {"result": req.a + req.b}

@app.post("/subtract")
def subtract(req: CalcRequest):
    return {"result": req.a - req.b}

@app.post("/multiply")
def multiply(req: CalcRequest):
    return {"result": req.a * req.b}

@app.post("/divide")
def divide(req: CalcRequest):
    if req.b == 0:
        raise HTTPException(status_code=400, detail="Division by zero")
    return {"result": req.a / req.b}
