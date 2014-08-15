/*
  SD Card Datalogger
 
 This program receives comma separated telemetry values started with the
 character $ and ended with the character \n, and writes them to an SD-
 card.
 
 Circuit is found in Microsoft Visio file "SDCard.vsdx".
 
 Author: Glenn Bitar
 Created: 2014-08-10
 Modified: 2014-08-13
 
 */

#include <SD.h>

#define FILE "datalog.txt"
#define DELAY 10

const int chipSelect = 10;


void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
  Serial1.begin(9600);
  while (!Serial1) {;} // wait

  setupSD();
}


// Global that holds current read, unprocessed information from serial port.

void loop() {
  handleSerial();
  delay(DELAY);
}

