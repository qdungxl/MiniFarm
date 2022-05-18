#include <Arduino.h>
#include "DHT.h"
#define DHTType DHT11
#define LedPin 13
unsigned long LedTime = 0;
unsigned long SensorTime = 0;
bool LedState = false;
int Humidity; //save humidity of DHT
int Temperture; //save Temperture of DHT
int SoilSenSor; //save humidity of soil sensor.
int SoilPin[] = {A0,A1,A2,A3};
int DHTPin[] = {2,3,4,5};
int MotorPin[] = {8,9,10,11};
int NumberOfSensor = 4;
struct SenSor
{
  int Temperture;
  int Humidity;
  int SoilSenSor;
};

void setup() 
{
  Serial.begin(19200);
  pinMode(LedPin,OUTPUT);
  for(int i =0; i<4;i++)
  {
    pinMode(DHTPin[i],INPUT);
    pinMode(MotorPin[i],OUTPUT);
  }
}

void LedProcess();
SenSor TakeValueSensor(int DHTPin, int PotPin);
String SendValueSensorToPC();
String DieuKhienDongCo(String s);

void loop() 
{
  String s = "";
  if(Serial.available()>0)
  {
    s = Serial.readStringUntil('\n');
  }
  if(s=="S")
  {
    String SensorValue = SendValueSensorToPC();
    Serial.println(SensorValue);
  }
  else if (s!="")
  {
    String Result = DieuKhienDongCo(s);
    Serial.println(Result);
  }
  delay(200);
}


String SendValueSensorToPC()
{
  String s ="";
  for(int i=0; i<NumberOfSensor;i++)
    {
    SenSor SS = TakeValueSensor(DHTPin[i],SoilPin[i]);
    String str = "";
    str+=SS.SoilSenSor;
    str+= ".";
    str+= SS.Temperture;
    str+=".";
    str+=SS.Humidity;
    if(i!=NumberOfSensor-1) str+="-";
    s = s+ str;
    }
    return s;
}
void LedProcess()
{
  if(millis()-LedTime>=500)
  {
    LedState = !LedState;
    digitalWrite(LedPin,LedState);
    LedTime = millis();
  }
}

SenSor TakeValueSensor(int DHTPin, int PotPin)
{
  DHT dht(DHTPin,DHTType);
  dht.begin();
  SenSor SS;
  SS.Humidity = dht.readHumidity();
  SS.Temperture = dht.readTemperature();
  SS.SoilSenSor =analogRead(PotPin);
  return SS;
}
String DieuKhienDongCo(String s)
{
  if(s=="dc11")
  {
    digitalWrite(MotorPin[0],1);
    return "dc11";
  } 
  if(s=="dc10")
  {
    digitalWrite(MotorPin[0],0);
    return "dc10";
  }
  if(s=="dc21")
  {
    digitalWrite(MotorPin[1],1);
    return "dc21";
  }
  if(s=="dc20")
  {
    digitalWrite(MotorPin[1],0);
    return "dc20";
  }
  if(s=="dc31")
  {
    digitalWrite(MotorPin[2],1);
    return "dc31";
  }
  if(s=="dc30")
  {
    digitalWrite(MotorPin[2],0);
    return "dc30";
  }
  if(s=="dc41")
  {
    digitalWrite(MotorPin[3],1);
    return "dc41";
  }
  if(s=="dc40")
  {
    digitalWrite(MotorPin[3],0);
    return "dc40";
  }
  return "F";
}