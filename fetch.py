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

presSens = 0
presOffs = 0
tempCoefSens = 0
tempCoefOffs = 0
tempRef = 0
tempCoef = 0

temp = 0
pres = 0

def initGY63():
	presSens = bus.read_word_data(ADR, CMD_PROM_PRES_SENS)
	time.sleep(0.05)

	presOffs = bus.read_word_data(ADR, CMD_PROM_PRES_OFFS)
	time.sleep(0.05)

	tempCoefSens = bus.read_word_data(ADR, CMD_PROM_TEMP_COEF_PRES_SENS)
	time.sleep(0.05)

	tempCoefOffs = bus.read_word_data(ADR, CMD_PROM_TEMP_COEF_PRES_OFFS)
	time.sleep(0.05)

	tempRef = bus.read_word_data(ADR, CMD_PROM_TEMP_REF)
	time.sleep(0.05)

	tempCoef = bus.read_word_data(ADR, CMD_PROM_TEMP_COEF)
	time.sleep(0.05)
	
	print "Initialization complete."
	print "presSens", presSens
	print "presOffs", presOffs
	print "tempCoefSens", tempCoefSens
	print "tempCoefOffs", tempCoefOffs
	print "tempRef", tempRef
	print "tempCoef", tempCoef

def getGY63():
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

	dt = rawTemp - tempRef * 2**8
	temp = 2000.0 + dt * tempCoef / 2**23
	off = presOffs * 2**16 + tempCoefOffs * dt / 2**7
	sens = presSens * 2**15 + tempCoefSens * dt / 2**8
	pres = (presSens * sens / 2**21 - off) / 2**15

	print dt, pres, temp

initGY63()

while True:
	getGY63()
	#print pres, temp
	time.sleep(2)

