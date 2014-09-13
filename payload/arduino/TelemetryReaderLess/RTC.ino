/*

  Used to get time from RTC chip.

*/

void getTime() {
  _time = print2digits(hour()) + print2digits(minute()) + print2digits(second());
}

String print2digits(int number) {
  String o = "";
  if (number >= 0 && number < 10) {
    o += '0';
  }
  o += number;
  return o;
}

void setupRTC() {
  setTime(RTC.get());
}
