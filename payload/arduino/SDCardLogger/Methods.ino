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
    //Serial.println("error opening " FILE);
    //Serial.println("Retrying opening sequence");
    //setupSD();
    //writeTelemetry(telemetry);
  }
}

void debug(String str) {
  //Serial.println(str);
  ;
}

void setupSD() {
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
