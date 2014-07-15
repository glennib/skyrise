import time
import serial

PORT = '/dev/ttyAMA0' # Serial port to read GPS string from.
BAUD = 9600 # Baud rate for the GPS chip.
PATH = '../data/gps.txt'

lat = 0
lon = 0
alt = 0
gpstime = ""

good = False # This contains whether the last GPS read contained good information.

# Each one of the process functions is to parse the different types of strings that come from the chip.

# GPRMC - Recommended minimum specific GPS/Transit data
def processRMC(inp):
	global good # Grants access to global parameter good.

	# We use the third ([2]) entry of RMC to determine if the data coming from the GPS chip is legit.
	if inp[2] == 'V':
		good = False
	elif inp[2] == 'A':
		good = True
	else:
		print "ERROR: unknown data status"

# GPVTG - Track made good and ground speed
def processVTG(inp):
	return

# GPGGA - Global Positioning System Fix Data
def processGGA(inp):
	global lat, lon, alt, gpstime # Grants access to the global variables.

	gpstime = inp[1] # Store time.

	buf = inp[2][:2] # The two first digits of the latitude is degrees.
	lat = float(buf) # Turn it into a number.
	buf = inp[2][2:] # The rest is minutes (with decimals)
	lat += float(buf) / 60 # Add it to the degrees.
	if inp[3] == 'S': # Determine if it's south, if so, negate.
		lat *= -1
	elif inp[3] != 'N': # If it's neither S nor N, then what??
		print "ERROR: Neither north or south??"

	buf = inp[4][:3] # Grab longitude.
	lon = float(buf) # Turn it into number.
	buf = inp[4][3:] # Grab minutes.
	lon += float(buf) / 60 # Add it to lon.
	if inp[5] == 'W': # If it's west, negate.
		lon *= -1
	elif inp[5] != 'E': # If it's not east nor west, then what?
		print "ERROR: Neither east or west??"

	alt = float(inp[9]) # Grab the altitude and turn it into a number.

	# This is for debugging purposes.
	print "Lat:", lat
	print "Lon:", lon
	print "Alt:", alt

# GPGSA - GPS DOP and active satellites
def processGSA(inp):
	return

# GPGSV - GPS Satellites in view
def processGSV(inp):
	return

# GPGLL - Geographic position, latitude / longitude
def processGLL(inp):
	return

# This function processes the read data once finished.
def finishGPS():
	if good:
		# Creating a string containing gps information.
		s = gpstime + ','
		s += str(lat) + ','
		s += str(lon) + ','
		s += str(alt)
		
		# Write the latest GPS data to gps.txt.
		try:
			f = open(PATH, "w")
			f.write(s)
		except:
			print "Error with opening or writing to GPS file."
		finally:
			f.close()
	else:
		print "No good data from last read."


# This takes a finished line from the chip, and determines which function to parse it through.
def processGPS(inp):
	if inp == "": # If the string input is empty, we don't do anything. This may happen on the first run.
		return
	elif inp[0] != '$': # If the string input doesn't start with a $, there's a parsing error. Don't do anything with it.
		return

	arr = inp.split(',') # Here we split the input by commas, so we can easily handle each of the data elements. Element 0 will indicate the type of message.

	# Here we read element 0 and pass arr to the right function.
	if arr[0] == "$GPRMC":
		processRMC(arr)
	elif arr[0] == "$GPVTG":
		processVTG(arr)
	elif arr[0] == "$GPGGA":
		if good: # The good variable must be True to parse the GGA-string.
			processGGA(arr)
		finishGPS() # after GGA is parsed, we have the info we need. finishGPS handles what happens after that.
	elif arr[0] == "$GPGSA":
		processGSA(arr)
	elif arr[0] == "$GPGSV":
		processGSV(arr)
	elif arr[0] == "$GPGLL":
		processGLL(arr)
	else:
		print "ERROR. Unknown message from GPS:", inp




s = serial.Serial(PORT, BAUD, timeout=1) # Open serial port.

time.sleep(0.5)

curString = "" # Contains the unfinished string.
while(True):
	c = s.read() # Reads next character.
	if c == '$': # If the next character is a $, we have a new line to read. Take what we already have and parse it.
		processGPS(curString)
		curString = "$" # Restart curString.
	else: # Add last read char to curString.
		curString += c
