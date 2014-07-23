import smbus
import time

ADR = 0x1e

bus = smbus.SMBus(1)
r = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

while(True):

	for i in range(0, 13):
		r[i] = bus.read_byte_data(ADR, i)
		time.sleep(0.050)
	print chr(27) + "[2J"
	print r
