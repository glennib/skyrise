/*

  I2C Gather methods that are used by the main program.

*/
void getBarometer() {
  float temp = NULL, pressure = NULL;
  while (temp == NULL) {
    temp = _barometer.getTemperature(MS561101BA_OSR_4096);
  }
  while (pressure = NULL) {
    pressure = _barometer.getPressure(MS561101BA_OSR_4096);
  }
  _tempPressure = temp;
  _pressure = pressure;
  //_timestampBarometer = millis();
}

#define G 9.81
void getAccelerometer() {
  float acc_data[3];
  _accelerometer.get_Gxyz(acc_data);
  if (_accelerometer.status) {
    _accX = acc_data[0] * G;
    _accY = acc_data[1] * G;
    _accZ = acc_data[2] * G;
    
    //_timestampAccelerometer = millis();
  }
}

void getMagnetometer() {
  int ix, iy, iz;
  float fx, fy, fz;
  _magnetometer.getValues(&ix, &iy, &iz);
  _magnetometer.getValues(&fx, &fy, &fz);
  
  float heading = atan2(fy, fx);
  if (heading < 0) {
    heading += 2 * M_PI;
  }
  
  _heading = heading / M_PI * 180;
  //_timestampMagnetometer = millis();
}

void getHumiditySensor() {
  float hum = _humiditySensor.readHumidity();
  float temp = _humiditySensor.readTemperature();
  
  _humidity = hum;
  _tempHumidity = temp;
  //_timestampHumidity = millis();
}
