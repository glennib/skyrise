/*

 Emergency methods that are used by the main program.
 
 */

void controlEmergency() {  
  if (hour() > 24) {
    _emStatus = true;
  }
  else {
    _emStatus = false;
  }
}

#define FLASH_DURATION 50
#define WAIT_DURATION 800
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
    
    delay(WAIT_DURATION);
  }
  digitalWrite(SENSOR_RELAY_ACTUATOR, LOW);
}
