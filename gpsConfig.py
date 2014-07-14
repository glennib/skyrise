import time
import serial

s = serial.Serial('/dev/ttyAMA0', 9600, timeout=1) # Open serial port.

time.sleep(1)

# This is the settings message to send. Supposed to set GPS in <1g airborne mode.
key = bytearray([0xb5, 0x62, 0x06, 0x24, 0x00, 0x24, 0b00000001, 0x00, 0x06, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x00, 0x00])

# Checksum code.
cka = 0
ckb = 0

for i in range(2, 42):
	cka = cka + key[i]
	ckb = ckb + cka

cka = cka % 256
ckb = ckb % 256

key[42] = cka
key[43] = ckb

print "Sending config key..."
s.write(key)

# This is the message to request a poll of the settings.
key = bytearray([0xb5, 0x62, 0x06, 0x24, 0x00, 0x00, 0x00, 0x00])

for i in range(2, 6):
	cka = cka + key[i]
	ckb = ckb + cka

cka = cka % 256
ckb = ckb % 256

key[6] = cka
key[7] = ckb

time.sleep(1)

print "Sending config poll..."
s.write(key)

print "Reading..."

while True:
	print s.read()
