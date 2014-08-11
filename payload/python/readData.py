# This script reads the data from the files in the data-folder, and prints it directly to the terminal.
# Not to be used in launch, just to display the sensor data.

import time

DATAPATH = '/home/pi/skyrise/data/'
ACCELEROMETER_FILE = 'accelerometer.txt'
COMPASS_FILE = 'compass.txt'
BAROMETER_FILE = 'pressure.txt'


pressure = 0.0
temperature = 0.0

accX = ""
accY = ""
accZ = ""

heading = ""

def readBarometer():
	global pressure, temperature
	s = ""
	try:
		f = open(DATAPATH + BAROMETER_FILE, "r")
		try:
			s = f.read()
		except:
			pass
		finally:
			f.close()
	except:
		pass
	li = s.rsplit(',')
	pressure = li[0]
	temperature = li[1]


def readCompass():
	global heading
	s = ""
	try:
		f = open(DATAPATH + COMPASS_FILE, "r")
		try:
			s = f.read()
		except:
			pass
		finally:
			f.close()
	except:
		pass
	heading = s

def readAccelerometer():
	global accX, accY, accZ
	s = ""
	try:
		f = open(DATAPATH + ACCELEROMETER_FILE, "r")
		try:
			s = f.read()
		except:
			pass
		finally:
			f.close()
	except:
		pass
	li = s.rsplit(',')
	try:
		accX = li[0]
		accY = li[1]
		accZ = li[2]
	except:
		pass

while True:
	readBarometer()
	readAccelerometer()
	readCompass()
	
	print chr(27) + "[2J"
	print "Pressure:", pressure
	print "Temperature:", temperature
	print "Heading:", heading
	print "Acceleration (X, Y, Z): {0}, {1}, {2}".format(accX, accY, accZ)
	time.sleep(0.01)
