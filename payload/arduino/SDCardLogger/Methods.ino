/*

  Methods that are used by the main program.

*/


void writeTelemetry() {  
  File dataFile = SD.open(FILE, FILE_WRITE);
  
  if (dataFile) {
    dataFile.println(_currentIndata);
    dataFile.close();
    Serial.println(_currentIndata);
  }
  else {
    Serial.println("error opening " FILE);
  }
}
