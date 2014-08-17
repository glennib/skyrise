#define MAX_IN 1024 // 3.3 V
#define MAX_V 3.3 // 1024
#define FACTOR 5

void getVoltage() {
  int input = analogRead(VOLTAGE_PIN);  
  _voltage = (float)input / MAX_IN * MAX_V * FACTOR;
}
