/*
  SD Card Datalogger
  
  This program receives comma separated telemetry values started with the
  character $ and ended with the character \n, and writes them to an SD-
  card.
  
  Circuit is found in Microsoft Visio file "SDCard.vsdx".
  
  Author: Glenn Bitar
  Created: 2014-08-10
  Modified: 2014-08-10
  
*/

#include <SD.h>

#define FILE "datalog.txt"

const int chipSelect = 10;
const char START_OF_MESSAGE = '$';
const char END_OF_MESSAGE = '\n';


void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(9600);
   while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }


  Serial.print("Initializing SD card...");
  // make sure that the default chip select pin is set to
  // output, even if you don't use it:
  pinMode(10, OUTPUT);
  
  // see if the card is present and can be initialized:
  if (!SD.begin(chipSelect)) {
    Serial.println("Card failed, or not present");
    // don't do anything more:
    return;
  }
  
  File dataFile = SD.open(FILE, FILE_WRITE);
  
  if (dataFile) {
    dataFile.println("START");
    dataFile.close();
    Serial.println("START");
  }
  else {
    Serial.println("error opening " FILE);
  }
  
  Serial.println("card initialized.");
}


// Global that holds current read, unprocessed information from serial port.
String _currentIndata = "";

void loop() {
  if (Serial.available() > 0) {
    char readChar = Serial.read();
    
    switch (readChar) {
      case START_OF_MESSAGE:
        _currentIndata = "";
        break;
      case END_OF_MESSAGE:
        writeTelemetry();
        _currentIndata = "";
        break;
      default:
        _currentIndata += readChar;
        break;
    }
  }
}