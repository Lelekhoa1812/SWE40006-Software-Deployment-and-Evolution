FROM python:3.11-slim

# Best practice: set non-root user later if needed
WORKDIR /app

# Install deps first (layer caching)
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Copy source
COPY csvstats.py .

EXPOSE 8000
ENTRYPOINT ["python", "csvstats.py"]
