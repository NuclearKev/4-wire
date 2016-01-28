# 4-wire

## Licensing
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published 
by the Free Software Foundation, either version 3 of the license, or
(at your option) any later version. For more information view the LICENSE
file.

## Program Information
Firstly, this program assumes DMM1 has address 1 and DMM2 has address 2. 
DMM1 will be used for doing the 4-wire measurement and the voltage in part
d. DMM2 will be used for current only.

In the C# program you will notice a spreadsheet - this is where you should
enter your data. The labels should be pretty self explanitory. It's in your 
best interest to copy your data in an Excel spreadsheet as well; just in case 
the program has an issue or if you don't plan on finishing in one sitting.
Don't click on the upload button until you have all the data filled in
the spreadsheet. This uploads ALL the data to the database with the correct
labels and such. Also, the group ID is your groups letter assigned by West.
For example, I'm group J.
Lastly, the "4-wire" button will run an automated 4-wire resistance and 
place the values in their cells on the spreadsheet. The "Power Supply" button
will run the power supply automation and place the values where they should go.
Note that the program will detect which range you're in so you don't need to
manually tell the program whether you're in a low, medium, or large current
range. If you're out of range and try to run it, it'll give you an error.
After you've ran the automation and collected all the manual data, copy
and paste your data from your Excel spreadsheet in the correct sections 
on the C# spreadsheet and hit upload. This will put everything into the
database with the correct labeling. This prevents idiots like Jon Covert
and I from doing it wrong.

## Database
Server: iet2

Username: EET321

Password: EET321_S16

Table: EET321_Lab4_S16

## Understanding the Database
In the database you will notice there are a few items. Date/time, groupID,
resistance, type, and info (optional). Under "resistance" are all the
resistances; no matter what way you measured it. Under "type" is the method
in which you measured the resistance (2-wire, 4-wire). Under "info" you will
see things like NP (No Pressure), LP (Light Pressure), MP (Medium Pressure),
HP(Heavy Pressure), SC (Small Current), MC (Medium Current), or LC (Large 
Current). If it is blank, this means it was the standard 4-wire measurement.
NOTE: DO NOT USE THE TIMES IN THE DATABASE FOR YOUR ANALYSIS! The first
number is measured at time 0 and so on.
