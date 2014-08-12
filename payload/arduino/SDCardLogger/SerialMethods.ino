/*

 Serial methods that are used by the main program.
 
 */


#define START_OF_MESSAGE '$'
#define END_OF_MESSAGE '\n'
#define SERIAL_DELAY 5

String _curString = "";

void handleSerial() {
  while(Serial1.available()) {
    _curString += (char)Serial1.read();
  }
  delay(SERIAL_DELAY);
  if (Serial1.available()) { // indicates that there's more to the current transmit
    handleSerial();
  }
  else { // should indicate that the current transmit is done, move on to processing
    processCurString();
  }
}

void processCurString() { // is only entered if the current transmit is complete
  if (_curString != "") {
    int posStart = _curString.indexOf(START_OF_MESSAGE);
    int posStop = _curString.indexOf(END_OF_MESSAGE);

    if (posStart != -1) { // found start
      if (posStop != -1) { // found stop
        if (posStop <= posStart) { // stop is less than start??
          debug("Stop less than start");
        }
        else { // all is good
          String telemetry = _curString.substring(posStart + 1, posStop - posStart);
          _curString = _curString.substring(posStop + 1);
          writeTelemetry(telemetry);
        }
      }    
      else { // stop not found
        debug("Stop not found");
      }
    }
    else { // start not found
      debug("Start not found");
      _curString = "";
    }
  }
}
