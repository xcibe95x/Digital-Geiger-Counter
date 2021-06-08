/* Mauro Leoci 2021 */
/* Made and Scripted by https://youtube.com/xcibe95x */
/* The Project is open sourced and all updates are found on github */
/* https://github.com/xcibe95x */

// Included Libraries
#include <SPI.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

// Definitions
#define LOG_PERIOD 5000 // Refresh period in milli-Seconds

#define gm_input 2    // Pin D2 Recieve radiation pulse
#define SwDoseUnit 3  // Pin D3 Dose
#define SwCPM 4       // Pin D5 Count Per Minute
#define SwCPS 5       // Pin D4 Count Per Second
#define SwBgLight 6   // Pin D6 Light Switch
#define Clicker 7     // Pin D7 Buzzer
#define PulseLed 8    // Pin D8 Pulse Led
#define BatteryLed 9  // Pin D9 Battery Warning Led
#define Battery 0     // Pin A0 Input Battery Voltage

// Variables

int readIndex =-1;
int avgTotal;
int avgFinal;
float conversionFactor;

// Geiger Tubes
//////////////////////////////////////////////////////////////////////////////////
           //0    //1     //2    //3   //4    //5    //6    //7     //8   //9
enum tube {SBM20, SI29BG, SBM19, STS5, SI22G, SI3BG, SBM21, LND712, SBT9, SI1G};
int installed_tube = tube(SBM20); // Current Tube Model


// Variables for ISR.
long interruptTime = 0;     // Time for a new Interrupt.
long lastInterrupt = 0;     // Time when last Interrupt occured.
long bouncePreventTime = 4; // Minimum allowed time between interrupts.

// Variables for radiation count.
unsigned int count = 0;          // Counts used in ISR
unsigned int countPerSecond = 0; // Counts per second (CPS).
unsigned int countPerMinute = 0; // Counts per minute (CPM).

long timePreviousLog = 0;    // Time for previous CPS reading.

float outputSieverts(float x)  {
  float y = x * conversionFactor;
  return y;
}

void setup() {
  
  Serial.begin(9600);
  lcd.init();

  // Pin Initalizations
  pinMode(SwDoseUnit, INPUT_PULLUP); // Enable pullup resistor to keep the switch input
  pinMode(SwCPS, INPUT_PULLUP);
  pinMode(SwCPM, INPUT_PULLUP);
  pinMode(SwBgLight, INPUT_PULLUP);
  pinMode(gm_input, INPUT);
  pinMode(BatteryLed, OUTPUT);
  pinMode(Clicker, OUTPUT);
  
  digitalWrite(BatteryLed, HIGH);
  
  //digitalWrite(PulseLed, HIGH);
  digitalWrite(Clicker, HIGH); // Set high as normal mode

  // Attaches ISP to gm_inpt pin.
  // When pulse is detected ISR countPulse is initiated.
  attachInterrupt(digitalPinToInterrupt(gm_input), countPulse, FALLING);

  ////////////////////////////////////// Tubes Factors //////////////////////////////////////////
 
 // Calculate or find the factor value and add it here if your tube is different.
 // Doing your own calculations and calibrations may make your geiger counter more accurate
 // I will only correct values for SBM-20
 switch (installed_tube) {
    case 0: conversionFactor = 0.006655; break; //SBM20 My Calibration same as dividing count by 151
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
     lcd.backlight();
     lcd.setCursor(0,0);  
     lcd.print("Geiger Counter");
     lcd.setCursor(0,1);  
     lcd.print("Battery ");
     float BatteryLevel = (analogRead(Battery) * (5.0 / 1023));
     lcd.print(BatteryLevel);
     lcd.print("%");
     delay(1500);
     lcd.clear();
 
}

void loop() {

  // Check Battery Level and Turn On Warning Led if Low
  // We must multiply by 5 to get the actual battery level
  // Dividing is optional to get 3.70 instead of 3700 for Example
  
  float BatteryLevel = (analogRead(Battery)* 5.0) / 1023;

  
  if (BatteryLevel <= 3.0) {
      digitalWrite(BatteryLed, 1);
   } else {
      digitalWrite(BatteryLed, 0);
   }

 // Switches Controls //


 // Dose Rate Measure
 if (digitalRead(SwDoseUnit) == 0) {
     lcd.setCursor(0,1);
     lcd.print(outputSieverts(countPerMinute));
     lcd.print(" ");
     lcd.print("\344Sv/hr ");
 } else {
     lcd.setCursor(0,1);
     lcd.print(outputSieverts(countPerMinute) * pow(10, 2));
     lcd.print(" ");
     lcd.print("mR/hr ");
 }

   
   // Display Dose Rate
  if (digitalRead(SwCPM) == 1 && digitalRead(SwCPS) == 1) {
     lcd.setCursor(0,0);  
     lcd.print("Average CPM");
     lcd.print(" ");
     lcd.print(avgFinal);
     lcd.print("    ");
  } else {
 // Display Dose Rate
  if (digitalRead(SwCPS) == 1) {
     lcd.setCursor(0,0);  
     lcd.print("Count/Sec");
     lcd.print(" ");
     lcd.print(countPerSecond);
     lcd.print("    ");
  }

   // Display Dose Rate
  if (digitalRead(SwCPM) == 1) {
     lcd.setCursor(0,0);  
     lcd.print("Count/Min");
     lcd.print(" ");
     lcd.print(countPerMinute);
     lcd.print("    ");
  }
  
}
 
 // Backlight Control
  if (digitalRead(SwBgLight) == 1) {
    lcd.noBacklight(); 
    }
  else {
 
    if (BatteryLevel <= 3.0 && (!Serial)){
    lcd.noDisplay();
    lcd.noBacklight();
  } else {
    lcd.display();
    lcd.backlight();
  }
   
  }

 // Check if the log period has passed and show dose rate.
  if ((millis()) - timePreviousLog > LOG_PERIOD){ 
    countPerSecond = count * 1000 / LOG_PERIOD;
    countPerMinute = count * 60000 / LOG_PERIOD;
    timePreviousLog = millis(); //Update measurement time.
    count = 0;
    lcd.clear(); // Refresh LCD
    
    readIndex++;

  if (readIndex < 5) {
   avgTotal += countPerMinute; 
  }
 
  if (readIndex >= 5) {
  avgFinal = avgTotal / 5;
  avgTotal = countPerMinute;
  readIndex = 0;
  }
 }



}


//ISR Interrupt Service Routine countPulse.
void countPulse(){

digitalWrite(Clicker, 1);
interruptTime = millis(); //Set time for interrupt, check for bouncing.
if (interruptTime - lastInterrupt > bouncePreventTime){
  
digitalWrite(PulseLed, 1);
//Detach Interrupt from input pin.
detachInterrupt(digitalPinToInterrupt(gm_input));
count++; //Add counts.


//Reattach interrupt.
attachInterrupt(digitalPinToInterrupt(gm_input),countPulse,FALLING);
lastInterrupt = interruptTime; //Update last interrupt time.
digitalWrite(Clicker, 0);
digitalWrite(PulseLed, 0);
  }
}
