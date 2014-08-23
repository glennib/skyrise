/*

  I2C Gather methods that are used by the main program.

*/

void getBarometer() {
  float temp = NULL, pressure = NULL;
  while (temp == NULL) {
    temp = _barometer.getTemperature(MS561101BA_OSR_4096);
  }
  while (pressure == NULL) {
    pressure = _barometer.getPressure(MS561101BA_OSR_4096);
  }
  _tempPressure = temp;
  _pressure = pressure;
  //_timestampBarometer = millis();
}

void getAccelerometer() {
  int x, y, z;
  _accelerometer.readAccel(&x, &y, &z);
  if (_accelerometer.status) {
    _acc = z * 41;
  }
}

void getMagnetometer() {
  //int ix, iy, iz;
  float fx, fy, fz;
  //_magnetometer.getValues(&ix, &iy, &iz);
  _magnetometer.getValues(&fx, &fy, &fz);
  
  float heading = atan2(fy, fx);
  if (heading < 0) {
    heading += 2 * M_PI;
  }
  
  _heading = heading / M_PI * 180;
  //_timestampMagnetometer = millis();
}

void getHumiditySensor() {
  _humidity = _humiditySensor.readHumidity();
  _tempHumidity = _humiditySensor.readTemperature();
  
  /*_humidity = hum;
  _tempHumidity = temp;*/
  //_timestampHumidity = millis();
}

void getGyroscope() {
  _spin = getSpin();
}
