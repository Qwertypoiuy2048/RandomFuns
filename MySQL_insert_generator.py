# ===== PASTE YOUR DATA HERE =====
RAW_DATA = \
"""
term_year| term| course section faculty_fname faculty_lname capacity

2019| Fall| CIT| 111| 1| Marty| Morring| 30
2019| Fall| ECON| 150| 1| Nate| Norris| 50
2019| Fall| ECON| 150| 2| Nate| Norris| 50
2019| Fall| ECON| 388| 1| Ben| Barrus| 35
2019| Fall| HUM| 376| 1| John| Jensen| 30
2018| Winter| CIT| 111| 2| Marty| Morring| 30
2018| Winter| CIT| 111| 3| Bill| Barney| 35
2018| Winter| ECON| 150| 1| Nate| Norris| 50
2018| Winter| ECON| 150| 2| Nate| Norris| 50
2018| Winter| HUM| 376| 1| John| Jensen| 30
"""

TABLE_NAME = "course"
SKIP_LINES = [0,1]


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
