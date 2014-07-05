from smbus import SMBus
import time

bus = SMBus(1)

ADR = 0x77

CMD_READ_P = 0x48
CMD_READ_T = 0x58
CMD_GET = 0x00
CMD_PROM_PRES_SENS = 0xA2
CMD_PROM_PRES_OFFS = 0xA4

# make gy63 read pressure
bus.write_byte(ADR, CMD_READ_P)
time.sleep(0.05)

# get pressure
adcPresRead = bus.read_i2c_block_data(ADR, CMD_GET)
time.sleep(0.05)

# make gy63 read temp
bus.write_byte(ADR, CMD_READ_T)
time.sleep(0.05)

# get temp
adcTempRead = bus.read_i2c_block_data(ADR, CMD_GET)
time.sleep(0.05)

# calculate raw pressure data
rawPres = adcPresRead[0] * 0x10000 + adcPresRead[1] * 0x100 + adcPresRead[2]

# calculate raw temperature data
rawTemp = adcTempRead[0] * 0x10000 + adcTempRead[1] * 0x100 + adcTempRead[2]

# get factory data
presSensRead = bus.read_i2c_block_data(ADR, CMD_PROM_PRES_SENS)
time.sleep(0.05)

presOffsRead = bus.read_i2c_block_data(ADR, CMD_PROM_PRES_OFFS)
time.sleep(0.05)

tempCoefPresSensRead = bus.read_i2c_block_data(ADR, CMD_PROM_TEMP_COEF_PRES_SENS)

tempCoefPresOffsRead = bus.read_i2c_block_data(ADR, CMD_PROM_TEMP_COEF_PRES_OFFS)

tempRefRead = bus.read_i2c_block_data(ADR, CMD_TEMP_REF_READ)

presSens = presSensRead[0] * 256.0 + presSensRead[1]
presOffs = presOffsRead[0] * 256.0 + presOffsRead[1]

print adcRead
