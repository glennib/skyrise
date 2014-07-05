import time
import serial

s = serial.Serial('/dev/ttyAMA0', 9600, timeout=1)

time.sleep(1)

key = bytearray([0xb5, 0x62, 0x06, 0x24, 0x00, 0x24, 0b00000001, 0x00, 0x06, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 , 0, 0, 0, 0x00, 0x00])

cka = 0
ckb = 0

for i in range(2, 42):
	cka = cka + key[i]
	ckb = ckb + cka

cka = cka % 256
ckb = ckb % 256

key[42] = cka
key[43] = ckb

s.write(key)

while True:
	s.read()

