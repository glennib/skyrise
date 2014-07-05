import time
import serial

lat = 0
lon = 0
alt = 0
good = False

def processRMC(inp):
	if inp[2] == 'V':
		good = False
	elif inp[2] == 'A':
		good = True
	else:
		print "ERROR: unknown data status"

def processVTG(inp):
	time.sleep(0)

def processGGA(inp):
	global lat, lon, alt
	buf = inp[1][:2]
	lat = float(buf)
	buf = inp[1][2:]
	lat += float(buf) / 60
	if inp[3] == 'S':
		buf *= -1;
	elif inp[3] != 'N':
		print "ERROR: Neither north or south??"
	print lat

def processGSA(inp):
	time.sleep(0)

def processGSV(inp):
	time.sleep(0)

def processGLL(inp):
	return

def processGPS(inp):
	if inp == "":
		return
	elif inp[0] != '$':
		return

	arr = inp.split(',')

	if arr[0] == "$GPRMC":
		processRMC(arr)
	elif arr[0] == "$GPVTG":
		processVTG(arr)
	elif arr[0] == "$GPGGA":
		if good:
			processGGA(arr)
	elif arr[0] == "$GPGSA":
		processGSA(arr)
	elif arr[0] == "$GPGSV":
		processGSV(arr)
	elif arr[0] == "$GPGLL":
		processGLL(arr)
	else:
		print "ERROR. Unknown message from GPS:", inp


PORT = '/dev/ttyAMA0'
REFRESH = 0.20
BAUD = 9600

s = serial.Serial(PORT, BAUD, timeout=1)

time.sleep(2)

curString = ""
while(True):
	c = s.read()
	if c == '$':
		processGPS(curString)
		curString = "$"
	else:
		curString += c
