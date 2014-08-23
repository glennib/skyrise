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
 
 Third party libraries used:
 * FreeIMU
 * HTU21D 
 
 Circuit is found in "ArduinoPayload.vsdx".
 
 Author: Glenn Bitar
 Created: 2014-08-10
 Modified: 2014-08-21
 
 */

#include <Wire.h>
#include <HTU21D.h>
#include <HMC58X3.h>
#include <ADXL345.h>
#include <MS561101BA.h>
#include <SoftwareSerial.h>
#include <Time.h>
#include <DS1307RTC.h>

const char START_OF_MESSAGE = '$';
const char END_OF_MESSAGE = '\n';
//const int GPS_PIN = 4;
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
//unsigned long _timestampLED = 0;
const int DELAY = 10;

// fields for rtc
String _time = "";

// fields from gps sensor
float _lat = 0.0;
float _lon = 0.0;
unsigned int _alt = 0.0;

boolean _gpsGood = false;
//boolean _lastGpsLight = false;

// fields from barometer
float _pressure = 0.0;
float _tempPressure = 0.0;

// fields from accelerometer
int _acc = 0.0;

// fields from magnetometer
int _heading = 0;

// fields for humidity
float _humidity = 0.0, _tempHumidity = 0.0;

// fields for gyroscope
int _spin = 0;

// fields for voltage
float _voltage = 0.0;

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
  setupRTC();

  // Serial Setup
  Serial.begin(9600);
  Serial1.begin(9600);
  _serial.begin(9600);
  
  // GPS setup
  delay(2000);
  gpsSetup();

  // IO setup
  //pinMode(GPS_PIN, OUTPUT);
  //digitalWrite(GPS_PIN, LOW);
}

void loop() {
  unsigned long now = millis();
  if (now - _timestamp >= 1000) {
    // get new field data
    handleSerial();
    getTime();
    getBarometer();
    getAccelerometer();
    getMagnetometer();
    getHumiditySensor();
    getGyroscope();
    getVoltage();

    // handle string
    char charBuf[12];
    String telemetry = (String) START_OF_MESSAGE;
    // time    
      telemetry += _time; // time
      telemetry += ',';
    // GPS
    if (_gpsGood) {
      dtostrf(_lat, 4, 7, charBuf); // lat
      telemetry += charBuf;
      telemetry += ',';
      dtostrf(_lon, 4, 7, charBuf); // lon
      telemetry += charBuf;
      telemetry += ',';
      telemetry += _alt; // alt
      telemetry += ',';
    }
    else {
      telemetry += ",,,";
    }
    // acceleration
    telemetry += _acc;
    telemetry += ',';
    // heading
    telemetry += (String)_heading;
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
    // tempHumidity
    dtostrf(_tempHumidity, 3, 1, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // Voltage
    dtostrf(_voltage, 3, 2, charBuf);
    telemetry += charBuf;
    telemetry += ',';
    // GYRO SPIN
    telemetry += (String)_spin;
    
    // END
    telemetry += END_OF_MESSAGE;

    _timestamp = millis();

    Serial.print(telemetry);
    _serial.print(telemetry);
  }

  /*
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
  */
  handleSerial();
}
