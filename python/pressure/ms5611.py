import smbus
import time

class ms5611:

	READ_PRES = 0x48
	READ_TEMP = 0x58
	CAL_CONST = 0xA0
	GET_READ  = 0x00
	SLEEP_TIME = 0.0083
	
	C = [0, 0, 0, 0, 0, 0, 0]
	D = [0, 0, 0]
	
	def __init__(self, bus, address=0x76):
		self.bus = bus
		self.address = address
		
		# This block reads the calibration constants.
		for i in range(1, 7):
			self.C[i] = self.bus.read_i2c_block_data(self.address, self.CAL_CONST + 2*i)
			self.C[i] = self.C[i][0] * 256 + self.C[i][1]
	
	def read(self):
		# Read pressure into chip
		self.bus.write_byte(self.address, self.READ_PRES)
		time.sleep(self.SLEEP_TIME)
	
		# Read pressure from chip
		self.D[1] = self.bus.read_i2c_block_data(self.address, self.GET_READ)
		time.sleep(self.SLEEP_TIME)
		# Calculate raw data
		self.D[1] = self.D[1][0] * 65536 + self.D[1][1] * 256.0 + self.D[1][2]
		
		# Read temperature into chip
		self.bus.write_byte(self.address, self.READ_TEMP)
		time.sleep(self.SLEEP_TIME)
		
		# Read temperature from chip
		self.D[2] = self.bus.read_i2c_block_data(self.address, self.GET_READ)

		# Calculate raw data
		self.D[2] = self.D[2][0] * 65536 + self.D[2][1] * 256.0 + self.D[2][2]
		

		# Perform calculations
		dT = self.D[2] - self.C[5] * 2**8
		OFF = self.C[2] * 2**16 + dT * self.C[4] / 2**7
		SENS = self.C[1] * 2**15 + dT * self.C[3] / 2**8
		
		temp = (2000 + (dT * self.C[6]) / 2**23) / 100
		pres = (((self.D[1] * SENS) / 2**21 - OFF) / 2**15) / 100
		
		return (pres, temp)
