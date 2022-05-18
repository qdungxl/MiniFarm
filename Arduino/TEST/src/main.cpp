#include <Arduino.h>

int StrLength(String s); // lay chieu dai chuoi

void setup()
{
  Serial.begin(9600);
}

void loop() 
{
  String str = "";
  if(Serial.available()>0){
    String str = Serial.readStringUntil('\n');
  }
  delay(100);
}
int StrLength(String s)
{
  int x =0;
    for(int i=0; i<100;i++)
    {
      if(str[i]=='\0') break;;
      x++;
    }
  return x;
}