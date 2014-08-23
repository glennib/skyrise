/*

 GPS methods that are used by the main program.
 
 */

#define SERIAL_DELAY 2
#define GPS_CHAR '$'

String _curString = "";
void handleSerial() {
  while(Serial1.available()) {
    _curString += (char)Serial1.read();
  }
  delay(SERIAL_DELAY);
  if (Serial1.available()) { // indicates that there's more to the current gps transmit
    handleSerial();
  }
  else if (_curString != "") { // should indicate that the current gps transmit is done, move on to processing
    processCurString();
  }
}

void processCurString() { // is only entered if the current gps transmit is complete
    int pos1 = _curString.indexOf(GPS_CHAR);
    int pos2 = _curString.indexOf(GPS_CHAR, pos1 + 1);
    if (pos2 != -1) { // means there's more to process.
      String gpsString = _curString.substring(pos1, pos2 - pos1 + 1);
      _curString = _curString.substring(pos2);
      processGPSString(gpsString);
    }
    else { // there's nothing more to process
      processGPSString(_curString);
      _curString = "";
    }
}

void processGPSString(String gpsString) {
  //debug("processGPSString()");
  String name = gpsString.substring(0, 6);
  if (name == "$GPRMC") {
    processRMC(gpsString);
    //_timestampGps = millis();
  }
  /*else if (name == "$GPVTG") {
    ;
    //processVTG();
  }*/
  else if (name == "$GPGGA") {
    if (_gpsGood) {
      //debug("Got good signal");
      processGGA(gpsString);
    }
    else {
      //debug("No good signal");
    }
  }
  /*else if (name == "$GPGSA") {
    ;
    //processGSA();
  }
  else if (name == "$GPGSV") {
    ;
    //processGSV();
  }
  else if (name == "$GPGLL") {
    ;
    //processGLL();
  }
  else {
    //debug("Unknown GPS message: " + gpsString);
  }*/
}

void processRMC(String gpsString) {
  // 12 fields
  //debug("processRMC()");
  int field = 0;
  for (int i = 0; i < gpsString.length(); i++) {
    if (gpsString[i] == ',') {
      field++;
    }
    else {
      if (field == 2) {
        if (gpsString[i] == 'A') {
          _gpsGood = true;
          break;
        }
        else {
          _gpsGood = false;
          break;
        }
        /*else {
          //debug("Unknown data status in GPS");
        }*/
      }
    }
  }
}

void processGGA(String gpsString) {
  //debug("processGGA()");
  float lat = 0.0, lon = 0.0;
  int alt;
  String buf = "";
  int field = 0;
  char charBuf[15];
  for (int i = 0; i < gpsString.length(); i++) { // every char loop
    if (gpsString[i] == ',') { // If there's a separator
      switch (field) { // what to do when finished processing a field??
      case 2:
        buf.substring(0, 2).toCharArray(charBuf, 50);
        lat = atof(charBuf);
        buf.substring(2).toCharArray(charBuf, 50);
        lat += atof(charBuf) / 60;
        break;
      case 3:
        if (buf == "S") {
          lat *= -1;
        }
        /*else if(buf != "N") {
          //debug("Neither north or south?" + gpsString);
        }*/
        break;
      case 4:
        buf.substring(0, 3).toCharArray(charBuf, 50);
        lon = atof(charBuf);
        buf.substring(3).toCharArray(charBuf, 50);
        lon += atof(charBuf) / 60;
        break;
      case 5:
        if (buf == "W") {
          lon *= -1;
        }
        /*else if(buf != "E") {
          //debug("Neither west or east??" + gpsString);
        }*/
        break;
      case 9:
        buf.toCharArray(charBuf, 50);
        alt = atoi(charBuf);
        break;
      }
      buf = "";
      field++;
    }
    else { // What to do when next char comes?
      buf += gpsString[i];      
    }
  }
  _lat = lat;
  _lon = lon;
  _alt = alt;
}

void gpsSetup() {
  byte setupArray[44];
  setupArray[ 0] = 181;
  setupArray[ 1] = 98;
  setupArray[ 2] = 6;
  setupArray[ 3] = 36;
  setupArray[ 4] = 36;
  setupArray[ 5] = 0;
  setupArray[ 6] = 255;
  setupArray[ 7] = 255;
  setupArray[ 8] = 6;
  setupArray[ 9] = 3;
  setupArray[10] = 0;
  setupArray[11] = 0;
  setupArray[12] = 0;
  setupArray[13] = 0;
  setupArray[14] = 16;
  setupArray[15] = 39;
  setupArray[16] = 0;
  setupArray[17] = 0;
  setupArray[18] = 5;
  setupArray[19] = 0;
  setupArray[20] = 250;
  setupArray[21] = 0;
  setupArray[22] = 250;
  setupArray[23] = 0;
  setupArray[24] = 100;
  setupArray[25] = 0;
  setupArray[26] = 44;
  setupArray[27] = 1;
  setupArray[28] = 0;
  setupArray[29] = 0;
  setupArray[30] = 0;
  setupArray[31] = 0;
  setupArray[32] = 16;
  setupArray[33] = 39;
  setupArray[34] = 0;
  setupArray[35] = 0;
  setupArray[36] = 0;
  setupArray[37] = 0;
  setupArray[38] = 0;
  setupArray[39] = 0;
  setupArray[40] = 0;
  setupArray[41] = 0;
  setupArray[42] = 77;
  setupArray[43] = 219;
  
  for (int i = 0; i < 44; i++) {
    Serial1.write(setupArray[i]);
  }
}
