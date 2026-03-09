# ===== PASTE YOUR DATA HERE =====
RAW_DATA = """
 artwork_id|keyword_id

  
 1  | 2
 2  | 1
 2  | 10
 3  | 2
 4  | 4
 4  | 7
 4  | 3
 5  | 5
 5  | 9
 5  | 7
 5  | 6
 6  | 4
 6  | 7
 7  | 8
 7  | 7
 7  | 6
 8  | 4
 8  | 7
 9  | 9
 9  | 10
 10 | 10
 11 | 9
 11 | 7
 11 | 11
 12 | 10
 12 | 7
 12 | 2
 13 | 1
 13 | 7
"""

TABLE_NAME = "artwork_has_keyword"
SKIP_LINES = []

# =============================================

def clean_value(v):
    v = v.strip()
    v = v.replace("$", "")
    v = v.replace("'", "''")   # escape SQL quotes
    return v

def is_number(v):
    try:
        float(v)
        return True
    except:
        return False

lines = [l.strip() for l in RAW_DATA.strip().split("\n") if l.strip()]

# Detect headers
raw_headers = lines[0].split("|")
headers = []
col_num = []
for i,h in enumerate(raw_headers):
    col_num.append("a")
    if i not in SKIP_LINES:
        headers.append(h.strip().lower().replace(" ", "_"))
expected_cols = len(col_num)

print(f"-- Detected {expected_cols} columns:", headers, "\n")

# Process rows
for row_num, line in enumerate(lines[1:], start=2):
    values = [clean_value(v) for v in line.split("|")]

    # 🚨 THROW EXCEPTION IF COLUMN COUNT MISMATCH
    if len(values) != expected_cols:
        raise ValueError(
            f"Column shift detected on line {row_num}!\n"
            f"Expected {expected_cols} columns, got {len(values)}\n"
            f"Line content: {line}"
        )

    
    sql_values = []
    for i,v in enumerate(values):
        if i not in SKIP_LINES:
            if v == "":
                sql_values.append("NULL")
            elif is_number(v):
                sql_values.append(v)
            else:
                sql_values.append(f"'{v}'")

    col_str = ", ".join(headers)
    val_str = ", ".join(sql_values)

    print(f"INSERT INTO {TABLE_NAME} ({col_str}) VALUES ({val_str});")
