/*
  Telemetry Reader and Sender
 
 This program reads all sensors connected, generates a comma separated telemetry
 string started with $ and ended with \n, and transmits it serially to another
 Arduino which logs it, and to a RF transmitter, which transmits the string to a
 receiver on the ground.
 
 Connected sensors:
 * HTU21D Humidity sensor
 * GY-63 Pressure sensor
 * GY-80 Accelerometer, magnetometer and gyroscope
 * ublox MAX-6Q GPS
 
 Circuit is found in "*INSERT CIRCUIT LOCATION*".
 
 Author: Glenn Bitar
 Created: 2014-08-10
 Modified: 2014-08-16
 
 */

#include <Wire.h>
#include <HTU21D.h>
#include <HMC58X3.h>
#include <ADXL345.h>
#include <MS561101BA.h>
#include <SoftwareSerial.h>

const char START_OF_MESSAGE = '$';
const char END_OF_MESSAGE = '\n';
const int GPS_PIN = 4;
const int VOLTAGE_PIN = A0;

// Software Serial
SoftwareSerial _serial(7, 8); // RX 7, TX 8, calls for interrupt 4?

// I2C equipment
MS561101BA _barometer = MS561101BA();
ADXL345 _accelerometer;
HMC58X3 _magnetometer;
HTU21D _humiditySensor;

// for timekeeping purposes:
unsigned long _timestamp = 0;
unsigned long _timestampLED = 0;
const int DELAY = 10;

// fields from gps sensor
float _lat = 0.0;
float _lon = 0.0;
int _alt = 0.0;
String _gpstime = "";

boolean _gpsGood = false;
boolean _lastGpsLight = false;

// fields from barometer
float _pressure = 0.0;
float _tempPressure = 0.0;

// fields from accelerometer
float _accX = 0.0, _accY = 0.0, _accZ = 0.0;

// fields from magnetometer
float _heading = 0;

// fields for humidity
float _humidity = 0.0, _tempHumidity = 0.0;

// fields for gyroscope
int _spin = 0;

// fields for voltage
int _voltage = 0.0;

void setup() {
  // I2C Setup
  Wire.begin();
  _barometer.init(MS561101BA_ADDR_CSB_HIGH);
  _accelerometer.init(ADXL345_ADDR_ALT_LOW);
  _accelerometer.set_bw(ADXL345_BW_12);
  _magnetometer.init(false);
  _magnetometer.calibrate(1, 32);
  _magnetometer.setMode(0);
  _humiditySensor.begin();
  gyroSetup();

  // Serial Setup
  Serial.begin(9600);
  Serial1.begin(9600);
  _serial.begin(9600);

  // IO setup
  pinMode(GPS_PIN, OUTPUT);
  digitalWrite(GPS_PIN, LOW);
}

void loop() {
  unsigned long now = millis();
  if (now - _timestamp >= 1000) {
    // get new field data
    handleSerial();
    getBarometer();
    getAccelerometer();
    getMagnetometer();
    getHumiditySensor();
    getGyroscope();
    getVoltage();

    // handle string
    char charBuf[12];
    String telemetry = (String) START_OF_MESSAGE;
    // GPS
    if (_gpsGood) {
      telemetry += _gpstime; // time
      telemetry += ',';
      dtostrf(_lat, 4, 7, charBuf); // lat
      telemetry += charBuf;
      telemetry += ',';
      dtostrf(_lon, 4, 7, charBuf); // lon
      telemetry += charBuf;
      telemetry += ',';
      telemetry += int(_alt); // alt
      telemetry += ',';
    }
    else {
      telemetry += ",,,,";
    }
    // acceleration
    dtostrf(_accX, 3, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    dtostrf(_accY, 3, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    dtostrf(_accZ, 3, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // heading
    telemetry += (String)int(_heading);
    telemetry += ',';
    // pressure
    dtostrf(_pressure, 3, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // tempPressure
    dtostrf(_tempPressure, 3, 1, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // humidity
    dtostrf(_humidity, 3, 1, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // Voltage
    dtostrf(_voltage, 4, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // GYRO SPIN
    telemetry += (String)_spin;
    telemetry += ',';
    // tempHumidity
    dtostrf(_tempHumidity, 3, 1, charBuf);
    telemetry += charBuf;
    // END
    telemetry += END_OF_MESSAGE;

    _timestamp = millis();

    Serial.print(telemetry);
    _serial.print(telemetry);
  }

  if (_gpsGood) {
    digitalWrite(GPS_PIN, HIGH);
    _lastGpsLight = true;
  }
  else {
    now = millis();
    if (now - _timestampLED >= 500) {
      if (_lastGpsLight) {
        digitalWrite(GPS_PIN, LOW);
        _lastGpsLight = false;
      }
      else {
        digitalWrite(GPS_PIN, HIGH);
        _lastGpsLight = true;
      }
      _timestampLED = millis();
    }
  }
  handleSerial();  
}
