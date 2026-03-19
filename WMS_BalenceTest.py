import csv
# effects = {'H1': 0, 'H2': 0, 'H3': 0, 'H4': 0, 'V1': 0, 'V2': 0, 'V3': 0, 'V4': 0, 'B1': 0, 'B2': 0, 'B3': 0, 'B4': 0}
effects = {'H1': 0, 'V1': 0, 'B1': 0, 'H2': 0, 'V2': 0, 'B2': 0, 'H3': 0, 'V3': 0, 'B3': 0, 'H4': 0, 'V4': 0, 'B4': 0}

with open('C:/Users/ehcre/.vscode/projects/MyProjects/WMS.csv', 'r', encoding='utf-8') as f:

    surges = []
    for line in f:
        row = line.strip().split(',')
        surges.append(row)

    for row in surges:
        effect_type = row[0]
        level = row[1]
        key = effect_type + level
        if key in effects:
            effects[key] += 1


print("Effect counts:")
total_1 = effects['H1'] + effects['V1'] + effects['B1']
total_2 = effects['H2'] + effects['V2'] + effects['B2']
total_3 = effects['H3'] + effects['V3'] + effects['B3']
total_4 = effects['H4'] + effects['V4'] + effects['B4']
total_B = effects['B1'] + effects['B2'] + effects['B3'] + effects['B4']
total_V = effects['V1'] + effects['V2'] + effects['V3'] + effects['V4']
total_H = effects['H1'] + effects['H2'] + effects['H3'] + effects['H4']
total_all = total_1 + total_2 + total_3 + total_4


print("H1:", effects['H1'])
print("V1:", effects['V1'])
print("B1:", effects['B1'])
print(f"Total 1: {total_1}")

print()
print("H2:", effects['H2'])
print("V2:", effects['V2'])
print("B2:", effects['B2'])
print(f"Total 2: {total_2}")

print()
print("H3:", effects['H3'])
print("V3:", effects['V3'])
print("B3:", effects['B3'])
print(f"Total 3: {total_3}")

print()
print("H4:", effects['H4'])
print("V4:", effects['V4'])
print("B4:", effects['B4'])
print(f"Total 4: {total_4}")

print()
print("B1:", effects['B1'])
print("B2:", effects['B2'])
print("B3:", effects['B3'])
print("B4:", effects['B4'])
print(f"Total B: {total_B}")

print()
print("V1:", effects['V1'])
print("V2:", effects['V2'])
print("V3:", effects['V3'])
print("V4:", effects['V4'])
print(f"Total V: {total_V}")

print()
print("H1:", effects['H1'])
print("H2:", effects['H2'])
print("H3:", effects['H3'])
print("H4:", effects['H4'])
print(f"Total H: {total_H}")

print()
print(f"Total H: {total_H}")
print(f"Total V: {total_V}")
print(f"Total B: {total_B}")
print(f"Total 1: {total_1}")
print(f"Total 2: {total_2}")
print(f"Total 3: {total_3}")
print(f"Total 4: {total_4}")

print()
print(f"Total all: {total_all}")


"""
Effect counts:

H2: 28
V2: 68
B2: 46
Total 2: 142

H3: 48
V3: 92
B3: 53
Total 3: 193

H4: 11
V4: 9
B4: 15
Total 4: 35

B1: 25
B2: 46
B3: 53
B4: 15
Total B: 139

V1: 37
V2: 68
V3: 92
V4: 9
Total V: 206

H1: 28
H2: 28
H3: 48
H4: 11
Total H: 115

Total H: 115
Total V: 206
Total B: 139
Total 1: 90
Total 2: 142
Total 3: 193
Total 4: 35

Total all: 460

Empower Chaos:
V3: 92
V4: 9
Total: 101
1-4 surges from this table

Crystal Clusters:
H2: 28
V2: 68
Total 2: 96

H3: 48
V3: 92
Total 3: 140

Sum total: 236
1-2 surges from this table


Cloak of Flickering Reality:
H1: 28
V1: 37
B1: 25
Total 1: 90

H2: 28
V2: 68
B2: 46
Total 2: 142

Sum total: 232
1 surge from this table
"""
