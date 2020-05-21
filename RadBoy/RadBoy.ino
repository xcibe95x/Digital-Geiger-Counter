#include <Bounce2.h>
#include <SPI.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

#define NUMFLAKES 10
#define XPOS 0
#define YPOS 1
#define DELTAY 2

// PINS SETUP
/*
 * Voltmeter - A0
 * USB Voltmeter - A1
 * SDA - A4
 * SCL - A5
 * PWM - D9
 * 
*/

//#define RAD 2
//#define BUZZER 7
//#define BTN_1 10
//#define BTN_2 11
//#define BTN_3 12


//////////////////////////////////////////////////////////////////////////////

unsigned long previousMillis = 0; 
unsigned long previousMillis1 = 0; 
const long interval = 40000; 
const long interval1 = 500;

const int buttonPin = 11; 
const int ledPin =  13;

int buttonState = 0;
int bt = 0;
int pbt = 0;
int s1 = 0;
unsigned long j;
unsigned long CR = 0;

unsigned long cs;
int sec;
/////////////////////////////////

float input_voltage = 0.0;
float temp=0.0;


///////////////////////////////////

Bounce bouncer = Bounce();

void setup() {

  //Serial.begin(9600);
  //SPI.begin();
  lcd.init();
  lcd.backlight();
  lcd.clear();
  lcd.setCursor(0,0);  
  lcd.print("RadBoy ☢");
  delay(2000);
  lcd.clear();


TCCR1A = TCCR1A & 0xe0 | 2;
TCCR1B = TCCR1B & 0xe0 | 0x09; 
analogWrite(9,22 ); // output 9 PWM = 10%

pinMode(13, OUTPUT);
pinMode(7, OUTPUT); // buzzer
digitalWrite(13, HIGH);


pinMode(buttonPin, INPUT); // pulsante sul pin 2
digitalWrite(buttonPin ,HIGH); // collegare la resistenza pull-up integrata
bouncer.attach(buttonPin); // imposta il pulsante
bouncer.interval(5); // Parameter, stable interval = 5 мс


}

void loop() {

  
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

 unsigned long currentMillis = millis();
 unsigned long currentMillis1 = millis();


if (bouncer.update())
 { //se si è verificato un evento
  if (bouncer.read()==0)
  { 
    bt++;
  }
}

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    lcd.clear();
    CR = bt;
    bt = 0;   
  }
  
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  if (bt != pbt) {
    pbt = bt;
    s1 = 1;
}
    
///////////////////////////////////////////////TEXT ON DISPLAY//////////////////////////////////////////////////////////////////

  lcd.setCursor(0,1);
  lcd.print(bt);
  lcd.setCursor(0,0);
  lcd.print(CR);
  lcd.print(" ");
  lcd.print("mR/hr");

/////////////////////////////////////////////////BATTERY  INDICATION////////////////////////////////////////////
  batterylevel(15,0);
  usbplug(14,0);
  

////////////////////////////////////////////////////RADIATION ICON AND BUZZER/////////////////////////////////////////////////////////////
if (s1 == 1){
    digitalWrite(13, HIGH);
    digitalWrite (7, HIGH); // buzzer ON
}
else
{
    digitalWrite(13, LOW);
    digitalWrite (7, LOW); // buzzer OFF
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 if (currentMillis1 - previousMillis1 >= interval1) {
    previousMillis1 = currentMillis1;    
    if (s1 == 1){
      s1=0;
    }
  }
  //display.display();
}

// Draw battery level in position x,y
void batterylevel(int xpos,int ypos)
{
   double analog_value = analogRead(A1);

  //read the voltage and convert it to volt
   float curvolt = ( analog_value * 5.0) / 1024;
  // check if voltge is bigger than 4.2 volt so this is a power source
  if(curvolt > 4.0)
  {
    byte batlevel[8] = {
    B01110,
    B11111,
    B11111,
    B10101,
    B10001,
    B11011,
    B11011,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 4.0 && curvolt > 3.8)
  {
    byte batlevel[8] = {
    B01110,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 3.8 && curvolt > 3.7)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 3.7 && curvolt > 3.6)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B10001,
    B11111,
    B11111,
    B11111,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 3.6 && curvolt > 3.4)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B10001,
    B10001,
    B11111,
    B11111,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 3.4 && curvolt > 3.2)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B10001,
    B10001,
    B10001,
    B11111,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt <= 3.2 && curvolt > 3.0)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B10001,
    B10001,
    B10001,
    B10001,
    B11111,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
  if(curvolt < 3.0)
  {
    byte batlevel[8] = {
    B01110,
    B10001,
    B10001,
    B10001,
    B10001,
    B10001,
    B10001,
    B11111,
    };
    lcd.createChar(0 , batlevel);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(0));
  }
}

// Draw USB icon in position x,y
void usbplug(int xpos,int ypos)
{
  
   double USBvalue = analogRead(A6);
   float USB = ( USBvalue * 5.0) / 1024;


// lcd.setCursor(10,1);
// lcd.print(USB);
  
  if(USB > 4.0)
    {
    byte usbicon[8] = {
  B00100,
  B00101,
  B10101,
  B10111,
  B11100,
  B00100,
  B01110,
  B00100
    };
    lcd.createChar(1 , usbicon);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(1));
  }
   if(USB < 4.0)
  {
    byte usbicon[8] = {
    B00000,
    B00000,
    B00000,
    B00000,
    B00000,
    B00000,
    B00000,
    B00000,
    };
    lcd.createChar(1 , usbicon);
    lcd.setCursor(xpos,ypos);
    lcd.write(byte(1));
  }
}

// Read internal voltage (Not Used so far)
long readVcc() {
  long result;
  // Read 1.1V reference against AVcc
  ADMUX = _BV(REFS0) | _BV(MUX3) | _BV(MUX2) | _BV(MUX1);
  delay(2); // Wait for Vref to settle
  ADCSRA |= _BV(ADSC); // Convert
  while (bit_is_set(ADCSRA, ADSC));
  result = ADCL;
  result |= ADCH << 8;
  result = 1126400L / result; // Back-calculate AVcc in mV
  return result;
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
