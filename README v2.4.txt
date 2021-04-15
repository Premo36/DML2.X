Thank you for downloading Doom Mod Loader version 2.4!

If your reading this file from the standard windows notepad you may want to enable Format->Word Wrap to avoid having to scrolling to the right.

Microsoft .net framework (at least) version 3.5 is required in order to use Doom Mod Loader!
If your system is up-to-date you should have it already.
If you don't have it, the first time you open DML, Windows will ask you if you want to install it. 
If you're on an older Windows version that does not automatically install it, you can find it here and install it manually:
https://www.microsoft.com/en-us/download/details.aspx?id=21

In order to use DML 2.X you need at least:
1)A modern Doom sourceport (Any that follow the zdoom command line parameters standard should be fine, read below for the tested ones)
2)An original game (IWAD) like "doom.wad", "freedoom.wad" etc... 
3)Microsoft Net Framework 3.5


As for this version, the only tested source port are:

FULL COMPATIBILITY:
-GZdoom (v4.3.3), -height and -width do not work due to gzdoom way of handling resolution)
-LZdoom (v3.85)
-Zandronum (3.0)
-Zdoom(2.8.1)
-QZDoom (2.1.0)
-Skulltag(98d)

PARTIAL COMPATIBILITY (Some DML features don't work):
-Chocholate Doom (3.0.0)
-PRBOOM PLUS(2.5.1.4)
-GLBOOM PLUS(2.5.1.4)

(As long as it follows the zdoom command line standard, any engine should work fine)

============================"HOW-TO" QUICK START GUIDE============================
BEFORE YOU ADD ANY FILE:Starting from version 2.2, DML has become fully portable, meaning that you can also place your file in the relative subfolder inside the "FILE"
folder next to "DML vX.X.exe" (X is the version number)  and they will be read. 
Importing file trough the "ADD" buttons and the file manager it's still supported but you cant take advantage of the portability. 
If you don't want to load a file in dml, write it's full name (with the extension, like "modidontwanttosee.wad") in the blacklist.txt file

NOTE:If you place a file inside a folder while DML is running, you have to click on "refresh resources", otherwise it will not show up!

-HOW TO PLAY JUST THE ORIGINAL GAME:
1)Add your iwad's to the "IWAD" folder inside the "FILE" folder next to "DML vX.X.exe" 
   NOTE: To be recognised you game must have one of the following extension: ".wad", ".pk3", ".zip", ".pak", ".pk7", ".grp", ".rff", ".deh", ".iwad", ".ipk3". 
   1b)Add your iwad/s (original games/s) trough the "ADD" button in the IWAD section, you can add as many as you like, from any folder of your PC. 
   NOTE:If your game is not in the .wad format you'll need to change the filter in the file dialog to see it. 
   NOTE: If it does not follow the "IWAD 4 byte standard",a warning will pop-up,but you can still add it)
2)Add your sourceport to the PORT folder inside the "FILE" folder next to "DML vX.X.exe" 
2b)Add your favorite/s modern sourceport/s trough the "ADD" button in the Source Port section.
3)Select from the relative combobox the sourceport and the game you want to play. 
4)Hit "PLAY".
  NOTE: Your sourceport must be able to launch trough the "-iwad" parameter your original game in order to work. Not all sourceport may support all types of file supported by DML 2.X

-HOW TO PLAY WITH MODS:
1)If you don't have already, do step 1 to 3 of the previous how-to.
2)Add your mods to the PWAD folder inside the "FILE" folder next to "DML vX.X.exe" 
2b)Add your favourite/s mods through the "Open file manager" button in the MODS section, you can add single file/s or whole folders (and also include subfolders), drag & drop is supported.
3)Select them in the list on the left (click to select, click again to deselect)
4)Hit "play", if it's just 1 mod it will start right away, if are multiple mods a window will pop up, if so:
4b)Change the mod loading order. You can use the "UP" and "DOWN" button or the up/down arrow keys on your keyboard to move by one position a mod. 
   NOTE:You can hold "CTRL" while pressing  "UP" or "DOWN" for moving a mod quickly to the top or the bottom of the list.

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
7)Check any additional info you want to save with preset (IWAD, SOURCEPORT, ALTERNATIVE CONFIGURATION, RENDERER and COMMANDLINE)
8) Click on "save as new..." if it's a new preset of you want to make a copy
8b)Click on update if you want that any changes you made will be overwrite the current preset one
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
3)Add your configuration to the "PORT_CONFIG" folder inside the "FILE" folder next to "DML vX.X.exe" 
3b)Add the alternative/s .ini o .cfg trough the "ADD" button.
(don't add the one in the same folder of the engine as it is already loaded by default, instead make a copy of if somewhere else and add that copy). 
4)Select the one you want to use from the combobox. 
5)Hit "play". Now any settings will be read and saved in that ini/cfg. If you want to use again the original just untick the box.

-HOW TO REMOVE STUFF?
1)Select the item you want to remove from the combobox
1b)Select the mod/s you want to remove from the list in the file manager
2)Click "remove", a confirmation message will pop-up if you have DELETE/WARNING messages enabled.

-HOW TO DISPLAY ALSO THE FOLDER IN WHICH THE FILE IS LOCATED OR THE FULL PATH TO THE MOD IN THE MOD LIST?
1)Click on "Preferences".
2)Change "mod list view mode" from "ONLY FILE NAME" (which is the default setting) to "LAST FOLDER AND FILE NAME" or "FULL PATH".
3)Click on "Save".

-HOW DO I ENABLE/DISABLE SOME OR ALL MESSAGE BOX?
1)Click on "Preferences".
2)Check/Uncheck all types of message you want/don't want to see. By default all type of message are enabled.
3)Click on "Save".

============================CHANGELOG===========================
(This is the latest changelog. You can read all changelogs here https://p36software.net/downloads/dml2/changelog.txt)
[19/04/2021 | 2.4 ]
NEW FEATURES:
-Added support for loading ".iwad" and ".ipk3" file has an IWAD (Original game)
-Added file explorer shortcut to each "FILE" subfolder under the "Open" menu on the left of the software main window.
-Added "Mod list view mode" to manage the new 3 view mode of the file list: "ONLY FILE NAME" show only the mod name, "FOLDER AND FILE NAME" show the file name and the folder where it's placed and "FULL PATH" shows the full path to the mod. Can be changed in the preferences menu, default to "ONLY FILE NAME"
-Added welcome screen with some info about the software and how you can contact me.
-Mods in mod order window can now be directly pushed to the top or the bottom of the list by holding down "CTRL" while clicking on the "UP" or "DOWN" button.
-Mods now can be also ordered by folder and path.
-Mods in the Mod Loading Order window can be moved UP or DOWN with the arrow keys
-Mods in the Mod Loading Order window can be removed with the DELETE key
-Updated about box with new P36 Software logo, new support email, button links to my "business" twitter (@p36software) and to Tank Rider (my new game).
-Updated "unhandled exception" message to show the current software version.
-Updated assembly info

BUG FIXES:
-Fixed bug where "search" and "extension" filter in mods list were resetted to default when clicking on "Reload resources"
-Fixed bug where "USE_ADVANCED_SELECTION_MODE" flag was ignored on appllication start until the user opened and closed the preferences window
-Fixed bug where application would crash if in the mod load order windows, the last mod was removed and, without selecting another mod, the user tried to move up or down a mod.
-Fixed bug where all mods name in Mod Load Order window will change to "DoomModLoader2.Entity.PathName" .
-Fixed bug where the select preset will reset to "-" when the user clicked on "Reload resources".
-Fixed bug where the latest added iwad file does not always get automatically selected.
-Fixed bug whe preset name with spaces at the beginning or end of the file will make resets DML2X ini values to defaults.

NEW SETTINGS:
-FILE_VIEW_MODE
-CONFIG_VERSION

===================INFO===================
TWITTER: @p36software
EMAIL: support@p36software.net (feedback, bug reports, help...)
EMAIL: info@p36software.net (everything else)
WEBSITE: https://p36software.net
PROJECT REPOSITORY: https://github.com/Premo36/DML2.X

AUTHOR TWITTER: @premo36

Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)

=================LICENSE===================
BSD 3-Clause License

Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)
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