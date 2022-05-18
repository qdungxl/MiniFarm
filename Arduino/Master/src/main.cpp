#include <Arduino.h>
#include <Wire.h>

#define I2C_ADDR 2

byte x;
int LedPin = 13;
unsigned long Proces1 = 0;
unsigned long Proces2 = 0;
unsigned long Proces3 = 0;
bool LedState = false;

void ChopTatLed();
void SendToSlaveOutput(String str);
int StrLength(String str);

void setup() 
{
  pinMode(LedPin,OUTPUT);
  Serial.begin(9600);
  Wire.begin();
  
}

void loop() 
{
  
  if(Serial.available()>0)
  {
    String str = Serial.readStringUntil('\n');
    Serial.println(str);
    SendToSlaveOutput(str);
  }
  delay(1000);
  Wire.requestFrom(I2C_ADDR,3);
  Serial.print("Chuoi nhan duoc tu Slave la: ");
  if (Wire.available())
  {
    for(int i=0;i<3;i++)
    {
      char c = Wire.read();
      Serial.write(c);
    }
  }
  Serial.println();
  delay(1000);
}

void SendToSlaveOutput(String str)
{
  Wire.beginTransmission(I2C_ADDR);
  for(int i=0; i<=StrLength(str);i++){
    Wire.write(str[i]);
  }
  Wire.endTransmission();
}

void ChopTatLed()
{
  if(millis()-Proces1>=200)
  {
    Proces1 = millis();
    LedState = !LedState;
    digitalWrite(LedPin,LedState);
  }
}
int StrLength(String str)
{
  int x =0;
    for(int i=0; i<100;i++)
    {
      if(str[i]=='\0') break;
      x++;
    }
  return x;
}

/*
while (Wire.available())
  {
    char c = Wire.read();
    Serial.print(c);
  }
  delay(10);
----------------
if (Wire.available())
  {
    char c = Wire.read();
    Serial.println(c);
  }
  -------------------
*/