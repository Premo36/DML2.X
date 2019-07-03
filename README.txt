Thank you for downloading Doom Mod Loader version 2.0! (Please keep the .exe and the .dll in the same folder, otherwise DML will not work)

In order to use DML you need at least:
1)A modern Doom sourceport (Any that follow the zdoom command line parameters standard should be fine, read below for the tested ones)
2)An original game (IWAD) like "doom.wad", "freedoom.wad" etc... 

As for this version, the only tested source port are:
-Zdoom(2.8.1)
-GZdoom (4-1-2b, -height and -width do not work, see changelog below, "known bug" section, for more info)
-Zandronum (3.0)
-QZDoom (2.1.0)
-Skulltag(98d)
-Chocholate Doom (3.0.0, really BASIC compability, most of the DML features don't work. I'm planning to do a dedicate front end for "Vanilla" ports)

(Again, as long as it follows the zdoom command line standard any engine should work fine)

============================"HOW-TO" QUICK START GUIDE============================
NOTE: Remember that you can add multiple file at once! 

-HOW TO PLAY JUST THE ORIGINAL GAME:
1)Add your iwad/s (original games/s) trough the "ADD" button in the IWAD section, you can add as many as you like, from any folder of your PC. 
(If your game is not in the .wad format you'll need to change the filter in the file dialog to see it,if it does not follow the "IWAD 4 byte standard",a warning will pop-up,but you can still add it)
2)Add your favorite/s modern sourceport/s trough the "ADD" button in the Source Port section. Again no limitation of quantity or location. 
3)Select from the relative combobox the sourceport and the game you want to play. 
4)Hit "PLAY".

-HOW TO PLAY WITH MODS:
1)If you don't have already, do step 1 to 3 of the previous how-to.
2)Add your favourite/s mods through the "ADD" button in the MODS section
(If your mod is not in the .wad format you'll need to change the filter in the file dialog to see it)
3)Select them in the list on the left (click to select, click again to deselect)
4)Hit "play", if it's just 1 mod it will start right away, if are multiple mods a window will pop up, if so:
4b)Change the mod loading order as stated by the mod developer or at your discrection. 

Files in the list will be loaded starting from the top, rembember that each time a file is loaded it will replace any stuff loaded previously.
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
2)Click on "SAVE PRESET"
3)Enter a preset name and click OK.

-HOW TO START FROM LEVEL X
1)Flll with the level code (NOT the full name) the "start from level" field. 
On doom.wad and any wad that use episodes should be something like EYMX, where Y is the episode and X is the level (Ex: E1M4 in doom will load "Command Control").
On doom2.wad and any wad that dosen't have distinct episodes will be something like MAPXX, where XX is number of the level (Ex: MAP07 in doom 2 will load "Dead Simple").

-HOW TO LOAD AN ALTERNATIVE SOURCEPORT CONFIGURATION FILE (.ini or .cfg)?
The configuration files stores any settings of the sourceport. Sometimes can be useful to quick switch between the sourceport default one and another.  
For example, I use the standard .ini in the sourceport folder to play modern-like doom mod, and i have an alternative .ini that i use to play classic doom mod.
This can be useful also to share the same configuration between compatible sourceport.
1)Again, If you don't have already, do step 1 to 3 of the first how-to.
2)Tick the "Use alternative engine configuration file" in the alternative sourceport configuration file section.
3)Add the alternative/s .ini o .cfg trough the "ADD" button in the same section as step 1
(don't add the one in the same folder of the engine as it is already loaded by default, instead make a copy of if somewhere else and add that copy). 
4)Select the one you want to use from the combobox. 
5)Hit "play". Now any settings will be read and saved in that ini/cfg. If you want to use again the original just untick the box.

-HOW TO REMOVE STUFF?
1)Select the item you want to remove from the combobox
1b)Select the mod/s you want to remove from the list
2)Click "remove", a confirmation message will pop-up.

============================CHANGELOG===========================
[04/07/2019 | 2.0]
This is not just an update: It's a complete rewrite and redesign from scratch of the original VB.NET "Doom Mod Loader" in C#.
I've tried to keep the core functionality and user experience of the old one, but improving it.
Unfortunately due to the new more flexyble system I adopted to store any DML data, old .cfg are no longer compatible.
A lot of stuff has changed, I kept track of only of the most noticible difference.

New features:
-Added video render mode selection.
-Added multiple source port selection support.
-"Skill level" now display the actual skill display name used in the Doom family of games instead of a number.
-The launch options are now kept on application closing.
-PWADs now can be added from different directories, no more need to have all your mods in a single folder.
-IWADs now can be added from different directories, no more need wo have all your original games in a single folder.
-Added Dehacked (.deh) file support (Can be added trough the "MODS" section).
-Added more PWAD and IWAD extensions supports (wad, pk3, zip, pak, pk7, 7z, grp, and rff).
-Import multiple IWAD at once
-Import multiple PWAD at once
-Import multiple sourceport at once
-No longer IWAD and PWAD capacity limitation.
-DML can now check for update on application start, if a newer version is found, a box will pop-up with some info, the changelog and a button to download it. 
(Can be disabled by clicking on "Check for update" and unticking the "Always check for update on application start") 
-Now you can load alternative confguration file for the sourceport.

Bugfixes:
-Fixed IWAD check, now it will check if a game is an IWAD following the standard (reading the first 4 bytes of the file). and not by name, so you can play any IWAD that follow that standard (Hower if you iwad don't follow that standard, a message will pop up to warn you, but you can still add it).
-Fixed "Skill level" selection range from 0-4 to 1-5.
-The "Start from level(map)" now will work using the displayed "+map" command parameters instead of the "-warp" that the old DML was actually using.
-Fixed others minor bugs.

Known bug:
-"-width" and "-height" do not work in any recent gzdoom version.
This is a known issue thats been around since gzdoom changed the way the resolution is handled. 
This afflict any DML version, since the change has been made from the gzdoom side. 
Initially i was going to use "+win_w" and "+win_h" instead, 
but I soon scrapped the idea because this command will also change the stored the resolution in the gzdoom .ini, 
making the change permanent, so even if you removed the values from dml it will keep starting at that resolution. 
You can still change that way by writing it manually in the "Custom command line parameters" text area. Example: "+ win_w 1280 +win_h 720".

===================INFO===================
EMAIL: p36software@mail.com

Doom Mod Loader Copyright © 2016 - 2019 P36 Software, Matteo P.

