from __future__ import division
from smbus import SMBus
import time

bus = SMBus(1)

ADR = 0x77

CMD_READ_P = 0x48
CMD_READ_T = 0x58
CMD_GET = 0x00
CMD_PROM_PRES_SENS = 0xA2
CMD_PROM_PRES_OFFS = 0xA4
CMD_PROM_TEMP_COEF_PRES_SENS = 0xA6
CMD_PROM_TEMP_COEF_PRES_OFFS = 0xA8
CMD_PROM_TEMP_REF = 0xAA
CMD_PROM_TEMP_COEF = 0xAC

c1 = 0
c2 = 0
c3 = 0
c4 = 0
c5 = 0
c6 = 0

temp = 0
pres = 0

def initGY63():
	global c1, c2, c3, c4, c5, c6
	
	c1 = bus.read_word_data(ADR, 0xa2)
	time.sleep(0.05)

	c2 = bus.read_word_data(ADR, 0xa4)
	time.sleep(0.05)

	c3 = bus.read_word_data(ADR, 0xa6)
	time.sleep(0.05)

	c4 = bus.read_word_data(ADR, 0xa8)
	time.sleep(0.05)

	c5 = bus.read_word_data(ADR, 0xaa)
	time.sleep(0.05)

	c6 = bus.read_word_data(ADR, 0xac)
	time.sleep(0.05)
	
	print "Initialization complete."
	print "presSens", c1
	print "presOffs", c2
	print "tempCoefSens", c3
	print "tempCoefOffs", c4
	print "tempRef", c5
	print "tempCoef", c6
	print ""

def getGY63():
	global temp, pres

	# make gy63 read pressure
	bus.write_byte(ADR, CMD_READ_P)
	time.sleep(0.05)
	
	# get pressure
	adcPresRead = bus.read_i2c_block_data(ADR, CMD_GET)
	time.sleep(0.05)

	# calculate raw pressure data
	rawPres = adcPresRead[0] * 0x10000 + adcPresRead[1] * 0x100 + adcPresRead[2]

	# make gy63 read temp
	bus.write_byte(ADR, CMD_READ_T)
	time.sleep(0.05)

	# get temp
	adcTempRead = bus.read_i2c_block_data(ADR, CMD_GET)
	time.sleep(0.05)

	# calculate raw temperature data
	rawTemp = adcTempRead[0] * 0x10000 + adcTempRead[1] * 0x100 + adcTempRead[2]

	dT = rawTemp - c5 * 2**8
	off = c2 * 2**17 + dT * c4 / 2**6
	sens = c1 * 2**16 + dT * c3 / 2**7

	temp = (2000 + dT * c6 / 2**23) / 100
	pres = (rawPres * sens / 2**21 - off) / 2**15 / 100

initGY63()

while True:
	getGY63()
	print "T:", temp
	print "P:", pres
	print ""
	time.sleep(2)

