from smbus import SMBus
import time

bus = SMBus(1) # Opens I2C bus.

ADR = 0x77 # Address of pressure sensor.

CMD_READ_P = 0x48 # Message to read pressure.
CMD_READ_T = 0x58 # Message to read temperature.
CMD_GET = 0x00 # Message to read new values.

SLEEP = 1.0 # How long of a pause to take between reads.

PATH = '/home/pi/skyrise/data/pressure.txt' # Path to write new pressure to.


# These are constants used to calculate read values. Gathered from chip.
c1 = 0
c2 = 0
c3 = 0
c4 = 0
c5 = 0
c6 = 0

# The values will be stored in these variables. Celsius and mbar.
temp = 0
pres = 0

def initGY63():
	global c1, c2, c3, c4, c5, c6 # Grant access to the global variables.
	
	# This block reads the calibration constants.
	c1 = bus.read_i2c_block_data(ADR, 0xa2)
	time.sleep(0.05)

	c2 = bus.read_i2c_block_data(ADR, 0xa4)
	time.sleep(0.05)

	c3 = bus.read_i2c_block_data(ADR, 0xa6)
	time.sleep(0.05)

	c4 = bus.read_i2c_block_data(ADR, 0xa8)
	time.sleep(0.05)

	c5 = bus.read_i2c_block_data(ADR, 0xaa)
	time.sleep(0.05)

	c6 = bus.read_i2c_block_data(ADR, 0xac)
	time.sleep(0.05)
	
	# This block takes two bytes and turns them into a number.
	c1 = c1[0] * 256 + c1[1]
	c2 = c2[0] * 256 + c2[1]
	c3 = c3[0] * 256 + c3[1]
	c4 = c4[0] * 256 + c4[1]
	c5 = c5[0] * 256 + c5[1]
	c6 = c6[0] * 256 + c6[1]

def getGY63():
	global temp, pres # Grants access to the globals.

	# make gy63 read pressure
	bus.write_byte(ADR, CMD_READ_P)
	time.sleep(0.015)
	
	# get pressure
	d1 = bus.read_i2c_block_data(ADR, CMD_GET)
	time.sleep(0.05)

	# calculate raw pressure data
	d1 = d1[0] * 65536 + d1[1] * 256.0 + d1[2]

	# make gy63 read temp
	bus.write_byte(ADR, CMD_READ_T)
	time.sleep(0.05)

	# get temp
	d2 = bus.read_i2c_block_data(ADR, CMD_GET)
	time.sleep(0.05)

	# calculate raw temperature data
	d2 = d2[0] * 65536 + d2[1] * 256.0 + d2[2]

	dT = d2 - c5 * 2**8
	off = c2 * 2**16 + dT * c4 / 2**7
	sens = c1 * 2**15 + dT * c3 / 2**8

	temp = (2000 + (dT * c6) / 2**23) / 100
	pres = (((d1 * sens) / 2**21 - off) / 2**15) / 100

initGY63() # Initialize the sensor.

while True:
	getGY63()
	s = str(pres) + ',' + str(temp)
	f = open(PATH, "w")
	try:
		f.write(s)
	except:
		print "Error with opening or writing to pressure file."
	finally:
		f.close()
	
	time.sleep(SLEEP)
