from ms5611 import ms5611
import time
import smbus

bus = smbus.SMBus(1)

sensor = ms5611(bus)

while True:
	print chr(27) + "[2J"
	print sensor.read()
	time.sleep(0.5)
