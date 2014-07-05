import time
import serial

PORT = '/dev/ttyAMA0'
REFRESH = 0.20
BAUD = 9600

s = serial.Serial(PORT, BAUD, timeout=1)

time.sleep(2)

noString = 0

def processGPS(inp):
	arr = inp.split(',')
	if arr[1] == "$GPRMC":
		processRMC(inp)
	elif arr[1] == "$GPVTG":
		processVTG(inp)
	elif arr[1] == "$GPGGA":
		processGGA(inp)
	elif arr[1] == "$GPGSA":
		processGSA(inp)
	elif arr[1] == "$GPGSV":
		processGSV(inp)
	elif arr[1] == "$GPGLL":
		processGLL(inp)
	else print "ERROR. Unknown message from GPS:", inp

curString = ""
while(True):
	c = s.read()
	if c = '$':
		processGPS(curString)
		curString = "$"
	else:
		curString += c
