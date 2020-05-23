/* By youtube.com/xcibe95x */
/* github.com/xcibe95x */

/* PINS SETUP
 *  
 * Voltmeter - A0
 * USB Voltmeter - A1
 * SDA - A4
 * SCL - A5
 * PWM - D9
 * BUZZER - D7
 * 
*/

#include <Bounce2.h>
#include <SPI.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>

// LCD Coords
#define XPOS 0
#define YPOS 1

// LCD Offsets, Remove or Replace with your LCD offsets/code aswell as libraries
LiquidCrystal_I2C lcd(0x27, 16, 2); 

//You can add a different tube name here and then add it's factor in the setup
enum tube {SBM20, SI29BG, SBM19, STS5, SI22G, SI3BG, SBM21, LND712, SBT9, SI1G};

///////////EASY CONFIGURATION//////////

int installed_tube = tube(SBM20); // Change with the Tube used in your Project

//////////////////////////////////////


unsigned long previousMillis = 0;
unsigned long previousMillis1 = 0;

const long interval = 40000; 
const long interval1 = 500;

const int counter = 10; // 11 (DEBUG) 2 (TUBE)
const int led =  13;
const int buzzer =  7;

int measuringUnit = 0;
int buttonState = 0;

int countPerSecond = 0;
int countPerMinute = 0;
float conversionFactor = 0;
float microSievert = 0;
float milliRoentgen = 0;

int pbt = 0;
int s1 = 0;


/////////////////////////////////


Bounce bouncer = Bounce();

void setup() {
  
 Serial.begin(9600); // Open Serial Port for Debug or External Tools
 
 // Calculate or find the factor value and add it here if your tube is different.
 switch (installed_tube) {
    case 0:   conversionFactor = 0.006315; break; //SBM20
    case 1:  conversionFactor = 0.010000; break; //SI29BG
    case 2:   conversionFactor = 0.001500; break; //SBM19
    case 3:    conversionFactor = 0.006666; break; //STS5
    case 4:   conversionFactor = 0.001714; break; //SI22G
    case 5:   conversionFactor = 0.631578; break; //SI3BG
    case 6:   conversionFactor = 0.048000; break; //SBM21
    case 7:  conversionFactor = 0.005940; break; //LND712
    case 8:    conversionFactor = 0.010900; break; //SBT9
    case 9:    conversionFactor = 0.006000; break; //SI1G
    default: break;
  }
  Serial.println(10000*conversionFactor);

  //SPI.begin();
  lcd.init();
  lcd.backlight();
  lcd.clear();
  lcd.setCursor(0,0);  
  lcd.print("Geiger Counter");
  delay(5000);
  lcd.clear();

TCCR1A = TCCR1A & 0xe0 | 2;
TCCR1B = TCCR1B & 0xe0 | 0x09; 
analogWrite(9,22); // output 9 PWM = 10%

pinMode(led, OUTPUT);
pinMode(buzzer, OUTPUT);
digitalWrite(led, HIGH);
digitalWrite(13, HIGH);


pinMode(counter, INPUT);
digitalWrite(counter, HIGH); // Connect the integrated pull-up resistor 
bouncer.attach(counter); // Set the pulse
bouncer.interval(5); // Parameter, stable interval = 5 мс

 
  
  
}

void loop() {
  
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

 unsigned long currentMillis = millis();
 unsigned long currentMillis1 = millis();

//Check if an event occured
if (bouncer.update())
 { 
  if (bouncer.read()==0)
  { 
    bt++;
  }
}

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    lcd.clear();
    microSievert = bt*conversionFactor;
    bt = 0;   
  }
  
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  if (bt != pbt) {
    pbt = bt;
    s1 = 1;
}
    
///////////////////////////////////////////////TEXT ON DISPLAY//////////////////////////////////////////////////////////////////

if (measuringUnit == 0) {
  lcd.setCursor(0,1);
  lcd.print(bt);
  lcd.print(" CPS");
  lcd.setCursor(0,0);
  lcd.print(microSievert, 3);
  lcd.print(" uSv/hr");
} else {
  lcd.setCursor(0,1);
  lcd.print(bt);
  lcd.print(" CPM");
  lcd.setCursor(0,0);
  lcd.print(microSievert);
  lcd.print(" mR/hr");
}


/////////////////////////////////////////////////BATTERY  INDICATION////////////////////////////////////////////
  batterylevel(15,0);
  usbplug(14,0);
  

////////////////////////////////////////////////////RADIATION ICON AND BUZZER/////////////////////////////////////////////////////////////
if (s1 == 1){
    digitalWrite(led, 1);
    digitalWrite(buzzer, 1);
}
else
{
    digitalWrite(led, 0);
    digitalWrite (buzzer, 0);
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 if (currentMillis1 - previousMillis1 >= interval1) {
    previousMillis1 = currentMillis1;    
    if (s1 == 1){
      s1=0;
    }
  }
  
  if (digitalRead(12) == 1) {
    if (measuringUnit == 0) {
      measuringUnit = 1;
      lcd.clear();
      delay(100);
    } else { 
      measuringUnit = 0;
      lcd.clear();
      delay(100);
    }
  }
  
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
