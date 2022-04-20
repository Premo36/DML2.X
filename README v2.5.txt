Thank you for downloading Doom Mod Loader version 2.5!
If you're reading this file from the standard Windows notepad.exe you may want to enable Format->Word Wrap to avoid having to keep scrolling to the right.

============================CHANGELOG===========================
(This is the latest changelog. You can read all changelogs here https://p36software.net/downloads/dml2/changelog.txt . The number between parentheses is the issue number on the DML2.X github)
[22/04/2022 | 2.5 ]
NEW FEATURES:
-Now it works under Linux/Mac trough mono (Be sure to have downloaded the mono version, the one with "mono" in the exe name, and follow the instructions otherwise it will not work!)
-The preset name it's now fully visible while browsing the preset list, no matter how long the preset is (#13).
-Mods list "Order By" value it's now kept between application launches (#8).
-Preset order can now be changed via the software settings. Possible order are "Alphabetical - Ascending", "Alphabetical - Descending" , "Date - Ascending" and "Date - Descending" (#11).
-Mods list can now also be ordered by "Date - Ascending" and "Date - Descending".
-Added a workaround that mitigate the gzdoom bug where quicksave made with 'BIND [KEY] "SAVE QUICKSAVE.ZDS"' are saved in the wrong folder. Can be enabled in DML 2.X preferences. (Windows/Linux only) (#14) .
-In the mod order window, the selected mod can now be pushed directly to the top/bottom of the list  also by using pageUP/pageDOWN (#19).
-Now the mod that you always use can be placed in a preset and loaded automatically each time you play, just select the preset in the "autoload" combobox in the "Game" section of DML 2.X (#20).
-Updated the renderer selection in order to work with the newest gzdoom releases(#21).
-Added a monero address in the welcome/about windows and readme txt, in case anyone wants to donate.

BUGFIXES:
-Fixed bug where the DMLv2.ini will store the whole path of the alternative sourceport configuration file instead of just the name, making DML 2.X not fully portable (#9) .
-Fixed bug where the "please insert a preset name" error message had of a information icon instead of an error one (#18).
-Fixed bug where the mods list extension filter only showed matching file that had a lowercase extension. Now it shows all matches (#24).

NEW SETTINGS:
-RENDERER2
-FILE_ORDER_BY
-PRESET_ORDER
-GZDOOM_QUICKSAVE_FIX
-AUTOLOAD_PRESET

As for this version, the only tested sourceport are:
(Remember that as long as it follows the zdoom command line standard, any engine will work fine)
FULL COMPATIBILITY:
-GZdoom (v4.7.1), -height and -width do not work due to gzdoom way of handling resolution)
-LZdoom (v3.87c)
-Zandronum (3.1)
-Zdoom(2.8.1)
-QZDoom (2.1.0)
-Skulltag(98d)

PARTIAL COMPATIBILITY (Some DML features will not work):
-Chocolate Doom (3.0.1)
-PrBoom+ (2.6.2)
===============================HOW TO RUN DML 2.X ON WINDOWS/LINUX/MAC===============================================

-How to use the WINDOWS version:
The lateset version as been tested only on Windows 10 (21H2), but it should still work under older Windows 10 version and even 8.1/7 (If fully up to date!).
On XP it's not been tested, it should techincally work but you'll probably need install .net framework 3.5 manually, where the other os will do it for you automatically (after asking and if connected to the internet)
You will need Microsoft .net framework version 3.5 in order to use Doom Mod Loader 2.X!
If your system is up-to-date you should have it already.
If you don't have it or you're unsure if you have it installed, be sure to be connected to the internet the first time you open DML 2.X, so that Windows can prompt you to install it if yout don't have it already.

If you're on an older Windows version that does not automatically install it, you can find it here and install it manually:
https://www.microsoft.com/en-us/download/details.aspx?id=21

If the PC you wish to use DML 2.X cannot connect to the inernet, be sure to download the "Full Redistributable Package" that you'll find the link on the same page linked above under "Install Instructions".

The 2.5 version as been tested only in Windows 10 (21H2) but it should still run also on older windows version, like 8.1 or 7.

-How to use the mono version (Linux/Mac OS) 
What is mono? It's an open source implementation of Microsoft's .NET Framework. 
In order to use DML 2.X in Linux/Mac Os, you need to download and install the latest stable `mono-complete` for your operating system following the instruction on the official mono project website.

https://www.mono-project.com/download/stable/

If you're on a Linux based OS: 
You may have the mono-complete package available on your distro repos, but it's usually an older version so it's better that you still follow the instruction from the mono project website and install it that way.
Note that the mono version as been tested only Linux Mint 20.3 and Debian 11. It should work work fine on any debian based OS.
For Ubuntu/Ubuntu-based distro (like Linux Mint) follow the Ubuntu instructions.
For Debian/Debian-based distro (that are not Ubuntu/Ubuntu-based) follow the Debian instructions.
For CentOS, Red Hat Entriprise Linux or distro based on those, follow the CentOS/RHES instructions (note that DML 2.5 mono as NEVER been tested under those OS).
For Fedora/Fedora-based distro, you've guessed right! Follow the Fedora instructions. (note that DML 2.5 mono as NEVER been tested under Fedora).
For Arch/Arch-based system, like Manjaro etc... the official mono project does not have official packages for those distro. You may find something on your distro repos (note that DML 2.5 mono as NEVER been tested under Arch).  

If you're on a Mac OS system, the "mono-complete" package should be the only avaiable download for that platform. I call it "mono-complete" because on Linux it's modular.
While DML 2.X under mono should work as well as on Linux, I couldn't test it myself as I don't own a mac. It's even more "as is" under that OS. I've never even had the possibility too boot it up on a Mac, let alone fix bugs.
Also note that at 99.9% the 'Bind [KEY] "save quicksave.zds"' workaround will NOT work on Mac OS. 

Once `mono-complete` is installed, you should be able to open DML 2.X by simply double-clicking on the `.exe`. If that does not work you may open it trough your system terminal by navigating to the folder where the DML 2.X it's located, 
writing `mono "DML v2.5 mono.exe"` (you have to write the precise, full `.exe` name, writing "mono DML" and then pressing tab should autocomplete to the correct name) 
and pressing "enter" on your keyboard.

This version of DML 2.X is a slighted different version from the windows one: All the core functionality works and, as a plus,it follows the user dark/light theme (On Linux at least), but it may have some minor graphical issues
and the "check for update" functionality has been disabled as it would just crash DML 2.X, and I didn't bother find a solution as this version should be the last of the 2.X era (excluding an eventual bugfix release of course)

On Linux, to quickly found where a sourceport is installed (assuming you've installed trough your package manager) you can write in the console `whereis gzdoom` (where gzdoom is your sourceport name), which will output the path to the executable.

NOTE: The mono version may be less stable then the Windows one and if you use it on Mac OS keep in mind I've NEVER tested DML 2.X under Mac OS, as I don't own a mac.

-In order to use DML 2.X you need at least:
1)A modern Doom sourceport (Any that follow the zdoom command line parameters standard should be fine, read below for the tested ones)
2)An original game (IWAD) like "doom.wad", "freedoom.wad" etc... 
3)Microsoft Net Framework 3.5 (On Windows) / Latest "mono-complete" package (Linux/Mac OS)



============================"HOW-TO" QUICK START GUIDE============================
BEFORE YOU ADD ANY FILE:Starting from version 2.2, DML has become fully portable, meaning that you can also place your file in the relative subfolder inside the "FILE" folder next to "DML vX.X.exe" (X is the version number)  and they will be read. 
Importing file trough the "ADD" buttons and the file manager it's still supported but you cant take advantage of the portability. 
If you don't want to load a file in dml, write it's full name (with the extension, like "modidontwanttosee.wad") in the blacklist.txt file.
(for the exe file write just the name, eg. if you don't want to load "chocolate-midiproc.exe" write in the blacklist.txt inside the PORT folder "chocolate-midiproc")

NOTE:If you place a file inside a folder while DML is running, you have to click on "Reload resources", otherwise it will not show up!

Neither of the two methods have a max file number constraint like the old DML 1.0/1.1 had, so you can add as many file as you want!

-HOW TO PLAY JUST THE ORIGINAL GAME:
1)Add your iwad's to the "IWAD" folder inside the "FILE" folder next to "DML vX.X.exe" 
	NOTE: In order to be recognised you game must have one of the following extension: ".wad", ".pk3", ".zip", ".pak", ".pk7", ".grp", ".rff", ".deh", ".iwad", ".ipk3". 
   	1b)Add your iwad (original game) trough the "ADD" button in the IWAD section, you can add as many as you like, from any folder of your PC. 
   	NOTE:If your game is not in the .wad format you'll need to change the filter in the file dialog to see it. 
   	NOTE: If it does not follow the "IWAD 4 byte standard",a warning will pop-up,but you can still add it)
2)Add your sourceports to the PORT folder inside the "FILE" folder next to "DML vX.X.exe" 
	2b)Add your sourceports trough the "ADD" button in the Source Port section.
3)Select from the relative combobox the sourceport and the game you want to play. 
4)Hit "PLAY".
	NOTE: Your sourceport must be able to start using the "-iwad" parameter to set your original game in order to work. Note that not all sourceports may supports all types of file supported by DML 2.X

-HOW TO PLAY WITH MODS:
1)If you didn't have already, do step 1 to 3 of the previous how-to.
2)Add your mods to the "PWAD" folder inside the "FILE" folder next to "DML vX.X.exe" 
	2b)Add your mods through the "Open file manager" button in the MODS section, you can add single file or whole folders (and also include subfolders), drag & drop is supported.
3)Select them in the list on the left (click to select, click again to deselect)
4)Hit "PLAY", if it's just 1 mod it will start right away, if are multiple mods a window will pop up, if so:
	4b)Change the mod loading order. You can use the "UP" and "DOWN" button or the up/down arrow keys on your keyboard to move by one position a mod. 
	NOTE: You can use the arrow key to move the selected mod up/down, the delete key to remove it and pageUp/pageDown (Or the combo CTRL + UP/DOWN arrows/buttons) to move it to the top or the bottom of the list.

Files in the list will be loaded starting from the top, remember that each time a file is loaded it will replace any stuff loaded previously.
Let my try to explain it with a little example, you have the following setup:
Game: doom.wad
Mod A: GunsAndMonsters.wad
Mod B: JustGuns.wad

You want to play with the monsters of mod A , but with the guns of mod B. 
If you have mod B at the top of the list followed by mod A, mod B will replace Doom guns, mod A will replace doom monsters and mod B guns.
But if you move mod A at the top followed by mod B, mod A will replace doom monsters and guns, and mod B will replace mod A guns,  achieving what you were looking for!

File loading order really matters if the mods you're using replaces the same stuff or have some kind of dependencies.
If you have mod C that replace just the IMP, and mod D that replace just the Demon, it doesn't really matters what you load first as they have nothing in common.

If unsure follow the order suggested by the mods authors.

-HOW TO SAVE MODS IN PRESETS
If you play many mods togheter, you can save them in a preset. Next time you want to play again those mod just select the preset from the combobox.
1)Do step 1 to 3 of the previous how to.
2)Select at least 2 mods
3)Click on "play"
4)Adjust the files loading ordeR
5)Click on "SAVE PRESET"
6)Write a name for the preset
7)Check any additional info you want to save with preset (IWAD, SOURCEPORT, ALTERNATIVE CONFIGURATION, RENDERER and COMMANDLINE)
8)Click on "save as new..." if it's a new preset of you want to make a copy
	8b)Click on update if you want that any changes you made will overwrite the current preset data.
	8c)Click on "update and play" if you want to update the preset and launch the game right away.  
	NOTE: You can use the arrow key to move the selected mod up/down, the delete key to remove it and pageUp/pageDown (Or the combo CTRL + UP/DOWN arrows/buttons) to move it to the top or the bottom of the list.

-HOW TO START FROM LEVEL X
1)Fill with the level code (NOT the full name) the "start from level" field. 
On doom.wad  should be something like EYMX, where Y is the episode and X is the level (Ex: E1M4 in doom will load "Command Control").
On doom2.wad should be something like MAPXX, where XX is number of the level (Ex: MAP07 in doom 2 will load "Dead Simple").
If you're playng a custom iwad that does not follow neither of the previus scheme, follow the custom iwad scheme.

-HOW TO LOAD AN ALTERNATIVE SOURCEPORT CONFIGURATION FILE (.ini or .cfg)?
The configuration files stores any settings of the sourceport. Sometimes can be useful to quick switch between the sourceport default one and another.  
For example, I use the standard .ini in the sourceport folder to play modern-like doom mod, and i have an alternative .ini that i use to play classic doom mod.
This can be useful also to share the same configuration between compatible sourceport.
NOTE: Not all sourceport have this functionality.
1)Again, If you don't have already, do step 1 to 3 of the first how-to.
2)Tick the "Use alternative engine configuration file" in the alternative sourceport configuration file section.
3)Add your configuration to the "PORT_CONFIG" folder inside the "FILE" folder next to "DML vX.X.exe" 
	3b)Add the alternative/s .ini o .cfg trough the "ADD" button. 
(don't add the one in the same folder of the engine as it's already loaded by default, instead make a copy of it somewhere else and add that copy). 
4)Select the one you want to use from the combobox. 
5)Hit "play". Now any settings will be read and saved in that ini/cfg file. If you want to use again the original just untick the box.

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
2)Check/Uncheck all types of message you want/don't want to see. By default all type of messages are enabled.
3)Click on "Save".

-I USE SOMETHING LIKE 'BIND [KEY] "save QUICKSAVE.ZDS" ' TO MAKE MY QUICKSAVE, BUT WITH DML 2.X MY QUICKSAVE DISAPPEAR WHEN I RESTART GZDOOM!
NOTE: The following workaround as been tested only in recent Windows/Linux gzdoom/zandronum version, with the Linux version installed trough apt. It will NOT work on Mac OS, and probably will not work on older Linux version.
Gzdoom will place the "quicksave.zds" file in the DML v2.X folder (On Windows) or in the "home" folder (on Linux) instead of the gzdoom correct one when using this custom method of quicksaving. I don't know why. In order to solve this:
1)Go into the DML 2.X preferences and enable "Workaround for 'BIND [KEY] "save QUICKSAVE.ZDS" '". 
2)Every time you boot up gzdoom and wish to have a working quicksave, load your quicksave trough the "load" menu.
3)Right after it loads your quicksave, press right away "F6" (Or whatever [KEY] you've binded) in order to make a quicksave.
4)Done! If you follow these step, your quicksave/quickload will always point at the right save file.

With the workaround you will have 2 quicksave.zds, the "current" one in the dml 2.X and the "old" one in the gzdoom correct place.
The "current" one is the one thats gets updated each time you save for the current gzdoom session, the "old" one gets replaced  with the "current" one once you close gzdoom automatically by DML 2.X everytime you close your sourceport
This way the next time you open gzdoom your last quicksave will be available.  
If you don't quicksave after loading, and you try to quickload, gzdoom will now always quickload from the "old" quicksave until you close it.
Note that this as the name suggest, it's a *workaround* for something happening on the gzdoom side and in which I have *zero* control, it works for now but it may break with future updates.
 

-WHAT DOES DO THE "AUTOLOAD" FIELD DO?
It enables to automatically load a group of mods everytime you start any sourceport with any games or mods. Useful if you have some quality-of-life-improvements mods, that you use 99% of the times, that way you don't have to add them every time to each preset,
and if you update them and they change name you just have 1 preset to edit instead of N presets. 
For example I always load 3 mod, one that replace the dspistol sound with the doom 3 chaingun, one that replaces dsplasma with the doom 3 plasmagun sound, and one that change the Changunguy, SSWolfenstain and Spider Mastermind attack sound to use dspistol. 

In order to use it: 
1)Make a preset like you would normally do (if you don't know how, read the "HOW TO SAVE MODS IN PRESETS" section above)
2)Select it in the "autoload" field. From now on that preset will always load (after all the other mods) everytime you play. 

If you do not want to autoload anything anymore, just select "-" in the autoplay field. You can make multiple autoload preset and switch between them.
The only limitation is that you have to select at least 2 mod in order to make a preset, but you can always select a second random mod and then delete it from the preset from mod load order menu before saving it.
You can add/remove mods and edit the preset as it was a normal preset. Keep in mind that only the mod list will be used by the autoload and all other stored data in the preset will be ignored. 

===================INFO===================
Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)

If you like my work and you would like to support me, you can send monero to this address:
83XoYbCK9bZLF93kvY3RVHfWRtnLZAjLELUCP1foBMqoRi6zKF8NKXzTH2CobxvoZyREPcfgb6WwVaAu36iZDM72PYh2TCM

Donation will NEVER ne required, but are more than welcome ;) 
Don't worry if you can't/don't want to donate as it will not change the way I work. 
I would not make my software open source if I just wanted to profit from it.

If you're interested in my softwares, games, open source projects or just want to contact me, you can find me here:
🔗 Website: 		https://p36software.net
✉ Support e-mail: 	support@p36software.net (for reporting bug/give feedback/ask for help)
✉ Info e-mail: 		info@p36software.net (for anything else)
🐦 Twitter: 		https://twitter.com/p36software (@p36software, gets updated more often)
📄 Github: 		https://github.com/Premo36
🔧 ModDB: 		https://www.moddb.com/members/premo36
🎮 IndieDB: 		https://www.indiedb.com/members/premo36
🎥 Youtube: 		https://www.youtube.com/channel/UC9yqO2r6CJeLcKebDr142eA

=================LICENSE===================
BSD 3-Clause License

Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
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
