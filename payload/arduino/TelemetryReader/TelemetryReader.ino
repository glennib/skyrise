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
 Modified: 2014-08-12
 
 */

const char START_OF_MESSAGE = '$';
const char END_OF_MESSAGE = '\n';
const int GPS_PIN = 4;

float _lat = 0.0;
float _lon = 0.0;
int _alt = 0.0;
String _gpstime = "";
boolean _gpsGood = false;
boolean _lastGpsLight = false;

void setup() {
  Serial.begin(9600);
  Serial1.begin(9600);

  pinMode(GPS_PIN, OUTPUT);
}

unsigned long _timestampGps = 0;
unsigned long _timestampLED = 0;

void loop() {
  unsigned long now = millis();
  if (now - _timestampGps >= 800) {
    handleSerial();
    /*
  char charBuf[50];
     String telemetry = (String) START_OF_MESSAGE;
     telemetry += _gpstime; // time
     telemetry += ',';
     dtostrf(_lat, 4, 10, charBuf); // lat
     telemetry += charBuf;
     telemetry += ',';
     dtostrf(_lon, 4, 10, charBuf); // lon
     telemetry += charBuf;
     telemetry += ',';
     telemetry += int(_alt); // alt
     */
    now = millis();
  }

  if (now - _timestampLED >= 350) {
    if (_gpsGood) {
      digitalWrite(GPS_PIN, HIGH);
      _lastGpsLight = true;
    }
    else {
      if (_lastGpsLight) {
        digitalWrite(GPS_PIN, LOW);
        _lastGpsLight = false;
      }
      else {
        digitalWrite(GPS_PIN, HIGH);
        _lastGpsLight = true;
      }
    }
    _timestampLED = millis();
    now = _timestampLED;
  }


  //Serial.println(telemetry);
  delay(100);
}



