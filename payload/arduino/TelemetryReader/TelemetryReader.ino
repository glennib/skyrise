


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
  Modified: 2014-08-10
  
*/

#include "HTU21D.h"
#include "ADXL345.h"
#include "MS561101BA.h"
#include "HMC58X3.h"
#include <Wire.h>

const char START_OF_MESSAGE = '$';
const char end_of_message = '\n';

HMC58X3 _magnetometer;

void setup() {
  Serial.begin(9600);
  Wire.begin();
  
  _magnetometer.init(false);
  _magnetometer.calibrate(1, 32);
  _magnetometer.setMode(0);
}

void loop() {
  handleSerial();
}
