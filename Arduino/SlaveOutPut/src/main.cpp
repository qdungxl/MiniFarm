#include <Arduino.h>
#include <Wire.h>

#define I2C_ADDR 2

int DongCoBom = 2;
bool BomState = false;
int DongCoPhun = 3;
int DongCoLamMat = 4;
int DongCoQuatHut = 5;

void requestEvent();
void receiveEvent(int howMany);
bool DieuKhienDongCo(String str);
void SendToSlaveOutput(String str);
int StrLength(String str);

void setup() {
  // put your setup code here, to run once:
  pinMode(DongCoBom,OUTPUT);
  pinMode(DongCoPhun,OUTPUT);
  pinMode(DongCoLamMat,OUTPUT);
  pinMode(DongCoQuatHut,OUTPUT);
  Wire.begin(I2C_ADDR);
  Wire.onRequest(requestEvent);
  Wire.onReceive(receiveEvent);
  Serial.begin(9600);
}

void loop() {
  
}
void receiveEvent(int howMany){
  while (1<Wire.available())
  {
    String str = Wire.readStringUntil('\0');
    if(DieuKhienDongCo(str))
    {
      BomState = !BomState;
    }
  }
}
void requestEvent(){
  char c[] = {'O','F','F'};
  Wire.write(c);
}
bool DieuKhienDongCo(String str){
  if(str=="dc11") {
    digitalWrite(DongCoBom,1);
    return true;
  }
  if(str=="dc10")
  {
    digitalWrite(DongCoBom,0);
    return true;
  } 
  if(str=="dc21")
  {
    digitalWrite(DongCoPhun,1);
    return true;
  }
  if(str=="dc20")
  {
    digitalWrite(DongCoPhun,0);
    return true;
  } 
  if(str=="dc31") 
  {
    digitalWrite(DongCoLamMat,1);
    return true;
  }
  if(str=="dc30")
  {
    digitalWrite(DongCoLamMat,0);
    return true;
  }
  if(str=="dc41")
  {
    digitalWrite(DongCoQuatHut,1);
    return true;
  }
  if(str=="dc40")
  {
    digitalWrite(DongCoQuatHut,0);
    return true;
  }
  return false;
}
void SendToSlaveOutput(String str)
{
  Wire.requestFrom(I2C_ADDR,6);
  Wire.beginTransmission(I2C_ADDR);
  for(int i=0; i<=StrLength(str);i++){
    Wire.write(str[i]);
  }
  Wire.endTransmission();
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
if (BomState){
    char c = 'O';
    Wire.write(c);
  }
  else
  {
    Wire.write("Off");
  }
  */