/* Made and Scripted by Youtube.com/xcibe95x */
/* Please consider to stop by and drop a subscribe to support me <3 */
/* github.com/xcibe95x */

// QUICK CONFIGURATION
//////////////////////////////////////////////////////////////////////////////////
           //0    //1     //2    //3   //4    //5    //6    //7     //8   //9
enum tube {SBM20, SI29BG, SBM19, STS5, SI22G, SI3BG, SBM21, LND712, SBT9, SI1G}; // Add your tube name here and in the Setup

int installed_tube = tube(SBM20); // Change with the Tube used in your Project

// A4 SDA LCD
// A5 SCL LCD
const int led =  2;      // D2 INDICATOR LED
const int buzzer = 7;    // D7 INDICATOR BUZZER  
const int PWM = 9;       // D9 PWM
const int volt = A1;     // Voltmeter for Battery
const int usbV = A6;     // Voltmeter for USB Port

// Strings
String stCPS = " CPS";
String stCPM = " CPM";
String uSv = " \344Sv/hr";
String mSv = " mSv/hr";
String mR = " mR/hr";

//////////////////////////////////////////////////////////////////////////////////

// Libraries
#include <SPI.h>
#include <LiquidCrystal_I2C.h>
#include <Wire.h>

#define XPOS 0 // LCD X Position
#define YPOS 1 // LCD Y Position
#define GEIGER_PIN 3 // Geiger-Muller Tube Impulse input
#define LOG_PERIOD 20000 // Period before refreshing values (in milliseconds)
#define DISP_PERIOD 5000
#define MINUTE_PERIOD 60000 // 1 Minute (in milliseconds)

// LCD Offsets, Remove or Replace with your LCD offsets/code aswell as libraries n stuff
LiquidCrystal_I2C lcd(0x27, 16, 2);

int trigger;

unsigned long CPM; // Counts per minute
unsigned long CPS; // Counts per second
unsigned long counts; // Geiger Muller Tube Activity
unsigned long previousMillis = 0; // Time Measuring;

float conversionFactor;
float CPMArray[100];

// Units
float microSieverts;
float milliSieverts;
float milliRoentgens;

/////////////////////////////////

void IMPULSE() {
  counts++;
  trigger = 1;
}

float outputSieverts(float x)  {
  float y = x * conversionFactor;
  return y;
}

// SETUP

void setup() {

 // Initalize ports
 SPI.begin();
 Serial.begin(9600); // Open Serial Port for Debug or External Tools

 // Initialize LCD
 lcd.init();
 lcd.clear();
 lcd.backlight();

 // LCD Prints
 lcd.setCursor(0,0);  
 lcd.print("CHB-95");
 lcd.setCursor(10,0);  
 lcd.print("Rev.2C");
 lcd.setCursor(0,1);  
 lcd.print("Geiger Counter");
 delay(1500);
 lcd.clear();

/////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////// TUBE CONFIGURATION //////////////////////////////////////////
 
 // Calculate or find the factor value and add it here if your tube is different.
 // Doing your own calculations and calibrations may make your geiger counter more accurate
 // I will only correct values for SBM-20
 switch (installed_tube) {
    case 0: conversionFactor = 0.006655; break; //SBM20 My Calibration
    //case 0: conversionFactor = 0.0057; break; //SBM20 People use this one usually, but i think it's not accurate. dividing by 151 is better.
    //case 0: conversionFactor = 0.006315; break; //SBM20 Alternative Value
    case 1: conversionFactor = 0.010000; break; //SI29BG
    case 2: conversionFactor = 0.001500; break; //SBM19
    case 3: conversionFactor = 0.006666; break; //STS5
    case 4: conversionFactor = 0.001714; break; //SI22G
    case 5: conversionFactor = 0.194; break; //SI3BG Consider avoiding this Tube, spend a lil more on a sensitive Tube.
    //case 5: conversionFactor = 0.044444; break; //SI3BG
    //case 5: conversionFactor = 0.631578; break; //SI3BG
    case 6: conversionFactor = 0.048000; break; //SBM21
    case 7: conversionFactor = 0.005940; break; //LND712
    case 8: conversionFactor = 0.010900; break; //SBT9
    case 9: conversionFactor = 0.006000; break; //SI1G
    default: break;
 } 

/////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////

 // Pin Setups (Buttons will be configured later)
 pinMode(buzzer, OUTPUT);
 pinMode(led, OUTPUT);
 pinMode(GEIGER_PIN, INPUT);
 attachInterrupt(digitalPinToInterrupt(GEIGER_PIN), IMPULSE, FALLING);

/////////////////////////////////////////////////////////////////////////////////////////////////////

 // PWM = 10% Output(9)
  digitalWrite(13, HIGH);
  TCCR1A = TCCR1A & 0xe0 | 3;
  TCCR1B = TCCR1B & 0xe0 | 0x09; 
  analogWrite(PWM,22);
  
  // More LCD Prints
  lcd.setCursor(0,0);  
  lcd.print("Software Updates:");
  lcd.setCursor(0,1);  
  lcd.print("github/xcibe95x");
  delay(1000);
  lcd.clear();

  lcd.setCursor(0,0);
  lcd.print(CPM);
  lcd.print(stCPM);
  lcd.setCursor(0,1);
  lcd.print(outputSieverts(CPM));
  lcd.print(mSv);
 
} // Setup End

// LOOP

void loop() {

 // Keep track of Arduino internal timer
 unsigned long currentMillis = millis();

 // Conversions
 milliRoentgens = microSieverts/10; // 10 microsievert/hour = 1 milliroentgen/hour
 milliSieverts = microSieverts/1000; // 1 microsievert/hour = 0.001 millisievert/hour

 // Update CPM Counter
  if (currentMillis - previousMillis > LOG_PERIOD) {
    previousMillis = currentMillis;
    
    CPM = counts * MINUTE_PERIOD / LOG_PERIOD;
 
    lcd.clear();
    
    lcd.setCursor(0,0);
    lcd.print(CPM);
    lcd.print(stCPM);
    lcd.setCursor(0,1);
    lcd.print(outputSieverts(CPM));
    lcd.print(mSv);
       
    counts = 0;
    
  } 

  // This is a fix for Indicators as they won't get enough current otherwise
  if (trigger == 1){
    digitalWrite(led, HIGH);
    digitalWrite(buzzer, HIGH); // buzzer ON
    trigger = 0;
  }
  else
  {
    digitalWrite(led, LOW);
    digitalWrite(buzzer, LOW); // buzzer OFF
}

   
/////////////////////////////////////////////////ICON INDICATORS//////////////////////////////////////

  batterylevel(15,0);
  usbplug(14,0);
  
//////////////////////////////////////////////////////////////////////////////////////////////////////

} // Loop End


// Draw battery level in position x,y
void batterylevel(int xpos,int ypos)
{
   double analog_value = analogRead(volt);

  //read the value and convert it volt
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
  
   double USBvalue = analogRead(usbV);
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
                        
