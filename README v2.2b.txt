Thank you for downloading Doom Mod Loader version 2.2b!

Microsoft .net framework (at least) version 3.5 is required in order to use Doom Mod Loader!
If your system is up-to-date you should have it installed already, as it's included in the regular windows updates and has been released more than 10 years ago. 

If you don't have it, you can find it here and install it manually:
https://www.microsoft.com/en-us/download/details.aspx?id=21

In order to use DML 2.X you need at least:
1)A modern Doom sourceport (Any that follow the zdoom command line parameters standard should be fine, read below for the tested ones)
2)An original game (IWAD) like "doom.wad", "freedoom.wad" etc... 
3)Microsoft Net Framework 3.5


As for this version, the only tested source port are:
-GZdoom (v4.2.4), -height and -width do not work due to gzdoom way of handling resolution)
-LZdoom (3.83a)

-Zandronum (3.0)
-Zdoom(2.8.1)
-QZDoom (2.1.0)
-Skulltag(98d)
-Chocholate Doom (3.0.0, really BASIC compability, most of the DML features don't work)

(As long as it follows the zdoom command line standard, any engine should work fine)

============================"HOW-TO" QUICK START GUIDE============================
BEFORE YOU ADD ANY FILE:Starting from version 2.2, DML has become fully portable, meaning that you can also place your file in the relative subfolder inside the "FILE"
folder next to "DML v2.2b.exe" and they will be read. 
Importing file trough the "ADD" buttons and the file manager it's still supported but you cant take advantage of the portability. 
If you don't want to load a file in dml, write it's full name (with the extension, like "modidontwanttosee.wad") in the blacklist.txt file

NOTE:If you place a file inside a folder while DML is running, you have to click on "refresh resources", otherwise it will not show up!

-HOW TO PLAY JUST THE ORIGINAL GAME:
1)Add your iwad's to the IWAD folder inside the "FILE" folder next to "DML v2.2b.exe" 
1b)Add your iwad/s (original games/s) trough the "ADD" button in the IWAD section, you can add as many as you like, from any folder of your PC.(If your game is not in the .wad format you'll need to change the filter in the file dialog to see it,if it does not follow the "IWAD 4 byte standard",a warning will pop-up,but you can still add it)
2)Add your sourceport to the PORT folder inside the "FILE" folder next to "DML v2.2b.exe" 
2b)Add your favorite/s modern sourceport/s trough the "ADD" button in the Source Port section.
3)Select from the relative combobox the sourceport and the game you want to play. 
4)Hit "PLAY".

-HOW TO PLAY WITH MODS:
1)If you don't have already, do step 1 to 3 of the previous how-to.
2)Add your mods to the PWAD folder inside the "FILE" folder next to "DML v2.2b.exe" 
2b)Add your favourite/s mods through the "Open file manager" button in the MODS section, you can add single file/s or whole folders (and also include subfolders), drag & drop is supported.
3)Select them in the list on the left (click to select, click again to deselect)
4)Hit "play", if it's just 1 mod it will start right away, if are multiple mods a window will pop up, if so:
4b)Change the mod loading order as stated by the mod developer or at your discrection. 

Files in the list will be loaded starting from the top, remember that each time a file is loaded it will replace any stuff loaded previously.
Let my try to explain it with a little example, you have the following setup:
Game: doom.wad
Mod A: GunsAndMonsters.wad
Mod B: JustGuns.wad

You want to play with the monsters of mod A , but with the guns of mod B. 
If you have mod B at the top of the list followd by mod A, mod B will replace Doom guns, mod A will replace doom monsters and mod B guns.
But if you move mod A at the top followed by mod B, mod A will replace doom monsters and guns, and mod B will replace mod A guns,  achieving what you were looking for!

File loading order really matters if the mods you're using replaces the same stuff or have some kind of dependencies.
If you have mod C that replace just the IMP, and mod D that replace just the Demon, it doesn't really matters what you load first as they have nothing in common.

-HOW TO SAVE MODS IN PRESETS
If you play many mods togheter, you can save them in a preset. Next time you want to play again those mod just select the preset from the combobox.
1)Do step 1 to 3 of the previous how to.
2)Select at least 2 mods
3)Click on "play"
4)Manage the files loading order
5)Click on "SAVE PRESET"
6)Write a name for the preset
7)Check any additional info you want to save with preset (IWAD, SOURCEPORT, ALTERNATIVE CONFIGURATION, RENDERER  AND COMMANDLINE)
8) Click on "save as new..." if it's a new preset of you want to make a copy
8b)Click on update if you want that any changes you made will be overwrtie the current preset one
8c) Click on "update and play" if you want to update the preset and launch the game right away.  

-HOW TO START FROM LEVEL X
1)Fill with the level code (NOT the full name) the "start from level" field. 
On doom.wad  should be something like EYMX, where Y is the episode and X is the level (Ex: E1M4 in doom will load "Command Control").
On doom2.wad should be something like MAPXX, where XX is number of the level (Ex: MAP07 in doom 2 will load "Dead Simple").

-HOW TO LOAD AN ALTERNATIVE SOURCEPORT CONFIGURATION FILE (.ini or .cfg)?
The configuration files stores any settings of the sourceport. Sometimes can be useful to quick switch between the sourceport default one and another.  
For example, I use the standard .ini in the sourceport folder to play modern-like doom mod, and i have an alternative .ini that i use to play classic doom mod.
This can be useful also to share the same configuration between compatible sourceport.
1)Again, If you don't have already, do step 1 to 3 of the first how-to.
2)Tick the "Use alternative engine configuration file" in the alternative sourceport configuration file section.
3)Add your configuration to the "PORT_CONFIG" folder inside the "FILE" folder next to "DML v2.2b.exe" 
3b)Add the alternative/s .ini o .cfg trough the "ADD" button.
(don't add the one in the same folder of the engine as it is already loaded by default, instead make a copy of if somewhere else and add that copy). 
4)Select the one you want to use from the combobox. 
5)Hit "play". Now any settings will be read and saved in that ini/cfg. If you want to use again the original just untick the box.

-HOW TO REMOVE STUFF?
1)Select the item you want to remove from the combobox
1b)Select the mod/s you want to remove from the list in the file manager
2)Click "remove", a confirmation message will pop-up.

============================CHANGELOG===========================
(This is the latest changelog. You can read all changelogs here https://drive.google.com/file/d/1JmftFasvTYk60aeFedylvR0nQUnHSp1W/view)
[01/02/2020 | 2.2b]
-DML 2.X code gets released on github! https://github.com/Premo36/DML2.X (BSD 4-Clause License)
-P36_utilitis.dll code integrated in the .exe, removed the .dll dependencies.
-Improved CHEX3.wad identification: As it does not follow the IWAD standard (https://zdoom.org/wiki/WAD#Header),
 I used to rely on it's name to indentify it correctly as an IWAD, now i rely on it's checksum instead,
 so the iwad it's identified by it's content rather than it's name.
-Varaibles and function renaming, improved code comments.

Bugfixes
-Fixed bug where a file written in the BLACKLIST.TXT file would not be ignored if it was in the same folder as the blacklist file.

===================INFO===================
AUTHOR TWITTER: @premo36
EMAIL: info@p36software.net
WEBSITE: https://p36software.net
PROJECT REPOSITORY: https://github.com/Premo36/DML2.X
Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)

=================LICENSE===================
BSD 3-Clause License

Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
