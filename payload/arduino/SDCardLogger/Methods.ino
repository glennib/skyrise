/*

  Methods that are used by the main program.

*/


void writeTelemetry(String telemetry) {  
  File dataFile = SD.open(FILE, FILE_WRITE);
  
  if (dataFile) {
    dataFile.print(telemetry);
    dataFile.close();
    Serial.print(telemetry);
  }
  else {
    Serial.println("error opening " FILE);
  }
}

void debug(String str) {
  Serial.println(str);
  ;
}
