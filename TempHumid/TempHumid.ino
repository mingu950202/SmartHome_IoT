#include <DHT.h>
#include <DHT_U.h>

#define TEMP 2
#define DHTTYPE DHT22

int BlindPin = 8;
int AirconPin = 13;
int BoilerPin = 12;
int ReadUVintensityPin = A0;
int Fan1Pin = 3;
char AValue;

DHT temp(TEMP, DHTTYPE);

void setup() {
  temp.begin();
  Serial.begin(9600);
    
  pinMode(AirconPin, OUTPUT);
  pinMode(BoilerPin, OUTPUT);
  pinMode(ReadUVintensityPin, INPUT);
  pinMode(BlindPin, OUTPUT);
  pinMode(Fan1Pin,OUTPUT);
}

void loop() {

  float t = temp.readTemperature(); 
  float h = temp.readHumidity(); 
  
  int uvLevel = averageAnalogRead(ReadUVintensityPin);
  float outputVoltage = 5.0 * uvLevel/1024;
  float uvIntensity = mapfloat(outputVoltage, 0.99, 2.9, 0.0, 15.0);

    if(Serial.available())
  {
    AValue = Serial.read();
    {
      if ( AValue == '3')       // 블라인드
      {
        digitalWrite(BlindPin,LOW);
      }
      else if ( AValue == '2')
      {
        digitalWrite(BlindPin,HIGH);
      }    
      else if ( AValue == '5')       // 에어컨
      {
        digitalWrite(AirconPin,HIGH);
      }
      else if ( AValue == '4')
      {
        digitalWrite(AirconPin,LOW);
      }
      else if ( AValue == '7')  // 보일러
      {
        digitalWrite(BoilerPin,HIGH);
      }
      else if ( AValue == '6')
      {
        digitalWrite(BoilerPin,LOW);
      }
      else if ( AValue == '9')  // 환풍기1
      {
        digitalWrite(Fan1Pin,HIGH);
      }
      else if ( AValue == '8')
      {
        digitalWrite(Fan1Pin,LOW);
      }
          
      else if ( AValue == 'x')  // 전체종료
      {
        digitalWrite(AirconPin,LOW);
        digitalWrite(BoilerPin,LOW);
        digitalWrite(Fan1Pin,LOW);
      }
    }
  }
 
  Serial.print(t); // 온도
  Serial.print(",");
  Serial.print(h);  // 습도
  Serial.print(",");
  Serial.println(uvIntensity); // 자외선
  //Serial.print(",");
  //Serial.println(d);
  delay(3000);

}

int averageAnalogRead(int pinToRead)
{
  byte numberOfReadings = 8;
  unsigned int runningValue = 0;

  for(int x = 0 ; x < numberOfReadings ; x++)
    runningValue += analogRead(pinToRead);
  runningValue /= numberOfReadings;

  return(runningValue);

}
float mapfloat(float x, float in_min, float in_max, float out_min, float out_max)
{
  return ((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
}
