/*

 Emergency methods that are used by the main program.
 
 */
byte _countAcc = 0;
int _lastAcc = 0;
byte _countSpin = 0;
void controlEmergency() {
  if ((_acc - _lastAcc) * (_acc - _lastAcc) < 100) {
    _countAcc++;
  }
  else {
    _countAcc = 0;
  }
  _lastAcc = _acc;
  
  if (_spin == 0) {
    _countSpin++;
  }
  else {
    _countSpin = 0;
  }
  
  if ((_countAcc >= 60 || _countSpin >= 60)) {
    _emStatus = true;
  }
  else {
    _emStatus = false;
  }
}

#define FLASH_DURATION 50
#define WAIT_DURATION 
void enterEmergency() {
  digitalWrite(SENSOR_RELAY_ACTUATOR, HIGH);
  while (_emStatus) {
    // 1
    digitalWrite(EM_LED_1, HIGH);
    delay(FLASH_DURATION);
    digitalWrite(EM_LED_1, LOW);
    // 2
    digitalWrite(EM_LED_2, HIGH);
    delay(FLASH_DURATION);
    digitalWrite(EM_LED_2, LOW);
    // 3
    digitalWrite(EM_LED_3, HIGH);
    delay(FLASH_DURATION);
    digitalWrite(EM_LED_3, LOW);
    // 4
    digitalWrite(EM_LED_4, HIGH);
    delay(FLASH_DURATION);
    digitalWrite(EM_LED_4, LOW);
    
    controlEmergency();
  }
  digitalWrite(SENSOR_RELAY_ACTUATOR, LOW);
}
