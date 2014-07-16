import multisensor.adxl345 as adxl345
import multisensor.hmc5883l as hmc5883l
import pressure.ms5611 as ms5611
import time
import smbus

# Where the data should be stored.
DATAPATH = '/home/pi/skyrise/data/'
ACCELEROMETER_FILE = 'accelerometer.txt'
COMPASS_FILE = 'compass.txt'
BAROMETER_FILE = 'pressure.txt'

# How long it should be between each of the readings.
ACCELEROMETER_TIMEOUT = 0.010
COMPASS_TIMEOUT = 0.010
BAROMETER_TIMEOUT = 1.000

# A timestamp on the last reading, set asynchronous.
accelerometer_stamp = time.time()
compass_stamp = accelerometer_stamp + 0.5
barometer_stamp = accelerometer_stamp + 0.05

# Open the bus.
bus = smbus.SMBus(1)

# Initialize each of the sensors, the bus we created is sent to the objects.
accelerometer = adxl345.adxl345(bus)
compass = hmc5883l.hmc5883l(bus)
barometer = ms5611.ms5611(bus)

# Method for gathering data from the accelerometer.
def gatherAccelerometer():
  (x, y, z) = accelerometer.getAxes()
  string = "{0:.4f},{1:.4f},{2:.4f}".format(x, y, z)
  try:
    f = open(DATAPATH + ACCELEROMETER_FILE, "w")
    try:
      f.write(string)
    except:
      pass
    finally:
      f.close()
  except:
    return

# Method for gathering data from the compass.
def gatherCompass():
  heading = compass.heading()
  string = "{0:.1f}".format(heading)
  try:
    f = open(DATAPATH + COMPASS_FILE, "w")
    try:
      f.write(string)
    except:
      return
    finally:
      f.close()
  except:
    return

# Method for gathering data from the barometer.
def gatherBarometer():
  (pressure, temperature) = barometer.read()
  string = "{0:.0f},{1:.1f}".format(pressure, temperature)
  try:
    f = open(DATAPATH + BAROMETER_FILE, "w")
    try:
      f.write(string)
    except:
      return
    finally:
      f.close()
  except:
    return

# Main loop. Controls each of the timestamps to see if the specified timeout has passed, and eventually runs the gather methods.
while True:
  if time.time() - accelerometer_stamp >= ACCELEROMETER_TIMEOUT:
    gatherAccelerometer()
    accelerometer_stamp = time.time()

  if time.time() - compass_stamp >= COMPASS_TIMEOUT:
    gatherCompass()
    compass_stamp = time.time()

  if time.time() - barometer_stamp >= BAROMETER_TIMEOUT:
    gatherBarometer()
    barometer_stamp = time.time()
