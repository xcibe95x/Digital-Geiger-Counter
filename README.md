# DIY Geiger Counter

 Are you sick of youtube tutorial promising you a Geiger Counter and then it sucks?, This repo is for you, i have spent hours of research, it might not be the best
 But it works nicely, it just need some hardware re-engineering and maybe experts in Radiations can help improving the code.

# 22/05/2022 - I KNOW, Still didn't update the rep with schematics and shit, Wait for it, is gonna happen, i'm working on releasing it along a youtube showcase video

# 08-06-2021 - I'm bringing this project for my exams and the repository will be updated with some schematics and photos of the project, i've beeen running this challenge to get my self a geiger counter for a year now, and i'm pretty statisfied with the end result, after all the prototypes and tests, the version i was able to make and bring to my exams is the one which brings me the most statisfaction. So i will be proud to update this repository by the end of the month or a bit later with schematics and images.

Consider some of the informations below outdated, as it's been a year not updating them.

## This counter is now inspired by Imagesco GCA-07W Design and Functioning

## Consider getting yourself a cheap SBM-20 and don't waste money on the SI3BG

> IMPORTANT: This is still in progress and Schematics are not yet avaialable, i will add them soon, take any information here confidential and not 100% Accurate. I will keep updating the source and i already fixed a lot of bugs.

I have always wanted to have a **Geiger Counter** to check if some things in the garage or around the house that lay here from many years, has some activity, but as you know they are expensive and if you are not gonna use it in a professional way or going in a trip to a radioactive area, there's no use in spending all this money, after some researches online, it opened to me a few ways, after trial and error i was able to make a functioning geiger counter, however i have some basics in electronics and coding, but i have a small understanding of Radiation, so i have been researching to gain some knowledge to make my geiger counter as accurate as possible, the detection circuit is based on the most basic one you can find anywhere, but ofcourse i changed  it a bit, the goal of this project is to make a really easy and customizable code and schematics accessibile to anyone even with minimal understanding of coding electronics and stuff. Hope it will be helpful.
And if it was, please support me by subscribing on my youtube channel!

## Why do you think this is gonna work and what makes it accurate?

**Don't take any of my words for granted.** 
But i'm purely optimistic that this will be as accurate as an actual Geiger Counter Using the same SBM-20 Tube.
I have been googling around, and i did a bit of the math necessary, the Conversion Factor for this Tube given by the manufacter is 0,0057. Wich is given by doing some math with the values in the datasheet, and is not accurate you would need to redo the math with more tested elements, and than remove own background radiation of the tube itself, long story short, you would get a Conversion Factor of 0.005777.
So i managed to obtain a list of Conversion Factors for different tubes, in which the SBM-20 is 0.006315
Wich is more legit, than i made my own calibration and conversion factor, wich should be accurate, i did the test with Americium 241. 
Also notice that the code will be adjusted for this SBM-20 in particular wich is also the most common Tube.
But i will add some easy support for a bunch of tubes, but don't take it as accurate.
That said, i will try to adjust this geiger counter accordingly.

## Some documentations

[2N3904 Datasheets and Equivalents](https://components101.com/2n3904-pinout-datasheet)
[SBM-20 Manufacter Datasheets](http://www.gstube.com/data/2398/)
[GM Tube Calculator](https://andkom.github.io/gmcalc/)
[Useful Reading for Conversion Factors] (https://sites.google.com/site/diygeigercounter/technical/gm-tubes-supported)

## Components Used

 - Arduino Nano
 - 16x2 I2C (LCD)
 - 3x 2N3904 Transistor
 - 2x 4.7M Ohm Resistor
 - 4x 100K Ohm Resistors
 - A bunch of 10K Resistors
 - 16v 100uF Capacitor
 - 470 pF Capacitor
 - DC-DC Converter 5v to 1200v (Aliexpress, find a good seller got scammed a lot on this.)
 - 3,7V Battery of any capacity you like, i used two phone battery's from an LG soldered in Parallel.
 - 1x Switch button for ON/OFF
 - 3x Push Buttons for the functions
 - 1x Led
 - SBM-20 Geiger Tube (Initially SI3BG, but does not count anything or go in avalanche)
 - 1x Recycled headphones jack to connect headphones
 - 2x Recycled fuse base to hold the tube (makes it easy to replace)
 
 ## Changelog
 
 # 2.0
 - The previous code was completely changed so the changelog has been reset, any changes will be listed here.


## What if my tube is not on the list?

If your tube is not in the list, you will need to findout the manufacter sheet (Usually some russian papersheet), and find the Conversion Factor, if you don't find it you will need to calculate the Conversion Factor yourself, you may try to ask to the seller of the tube itself, or around the forums if someone has the same tube and know the conversion factor, or can manage to calculate it for you.

# Other Informations
Note: Own Background Radiation can also be called Inherent, Self or Shielded.
You may or not use this information to remove some noise from the conversion to get a more accurate uSv/hr.

|                |CONVERSION FACTOR              |OWN BACKGROUND RADIATION     |
|----------------|-------------------------------|-----------------------------|
|SBM-20          |`'0.006315'`                   | 1 CPS = 60 CPM              |
|SI29BG          |`'0.010000'`                   |                             |
|SBM19           |`'0.001500'`                   | 1,83 CPS = 109,8 CPM        |
|STS5            |`'0.006666'`                   | Similiar to SBM-20 ??       |
|SI22G           |`'0.001714'`                   |                             |
|SI3BG           |`'0.631578'`                   | 0,2 CPS = 12 CPM            |
|SBM21           |`'0.048000'`                   |                             |
|LND712          |`'0.005940'`                   |                             |
|SBT9            |`'0.010900'`                   |                             |
|SI1G            |`'0.006000'`                   |                             |
