import sys, pandas as pd

def usage():
    print("Usage: csvstats <csv_path> <numeric_column>")
    sys.exit(1)

if __name__ == "__main__":
    if len(sys.argv) != 3:
        usage()
    path, col = sys.argv[1], sys.argv[2]
    try:
        df = pd.read_csv(path)
        if col not in df.columns:
            print(f"ERROR: Column '{col}' not in CSV header: {list(df.columns)}"); sys.exit(2)
        s = pd.to_numeric(df[col], errors="coerce").dropna()
        print(f"Rows: {len(df)}")
        print(f"Valid numeric in '{col}': {len(s)}")
        print(f"Min: {s.min()} | Max: {s.max()}")
        print(f"Mean: {s.mean()} | Median: {s.median()}")
        sys.exit(0)
    except FileNotFoundError:
        print(f"ERROR: File not found: {path}"); sys.exit(3)
    except Exception as e:
        print(f"ERROR: {e}"); sys.exit(4)

