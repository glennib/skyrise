import smbus
import time

class ms5611:

	READ_PRES = 0x48
	READ_TEMP = 0x58
	CAL_CONST = 0xA0
	GET_READ  = 0x00
	SLEEP_TIME = 0.015
	
	C = [0, 0, 0, 0, 0, 0, 0]
	D = [0, 0, 0]
	
	def __init__(self, bus, address=0x77):
		self.bus = bus
		self.address = address
		
		# This block reads the calibration constants.
		for i in range(1, 7):
			C[i] = bus.read_i2c_block_data(self.address, self.CAL_CONST + 2*i)
			C[i] = C[i][0] * 256 + C[i][1]
	
	def read():
		# Read pressure into chip
		bus.write_byte(self.address, self.READ_PRES)
		time.sleep(self.SLEEP_TIME)
	
		# Read pressure from chip
		D[1] = bus.read_i2c_block_data(self.address, self.GET_READ)
		time.sleep(self.SLEEP_TIME)
		# Calculate raw data
		D[1] = D[1][0] * 65536 + D[1][1] * 256.0 + D[1][2]
		
		# Read temperature into chip
		bus.write_byte(self.address, self.READ_TEMP)
		time.sleep(self.SLEEP_TIME)
		
		# Read temperature from chip
		D[2] = bus.read_i2c_block_data(self.address, self.GET_READ)

		# Calculate raw data
		D[2] = D[2][0] * 65536 + D[2][1] * 256.0 + D[2][2]
		

		# Perform calculations
		dT = D[2] - C[5] * 2**8
		OFF = C[2] * 2**16 + dT * C[4] / 2**7
		SENS = C[1] * 2**15 + dT * C[3] / 2**8
		
		temp = (2000 + (dT * C[6]) / 2**23) / 100
		pres = (((D[1] * SENS) / 2**21 - OFF) / 2**15) / 100
		
		return (pres, temp)
