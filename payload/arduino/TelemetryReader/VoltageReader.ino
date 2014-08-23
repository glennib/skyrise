/*

  Used to read voltage.

*/

/*
#define MAX_IN 1024 // 3.3 V
#define MAX_V 3.3 // 1024
#define FACTOR 5*/

void getVoltage() {
  int input = analogRead(VOLTAGE_PIN);  
  _voltage = input * 0.01611328125; // factor 0.0161... = 3.3*5/1024. For scaling.
}
