import smbus
from adxl345 import ADXL345
import time

bus = smbus.SMBus(1)

sensor = ADXL345(bus)

while True:
	x = sensor.getAxes(False)
	print chr(27) + "[2J"
	print x
	time.sleep(0.1)
