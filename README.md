<p align="center">
<img src="https://media.moddb.com/images/mods/1/44/43024/DML2_logo.1.png"/>
</p>

# ABOUT DML 2.X
<strong> Doom Mod Loader 2.X </strong> is a launcher for Doom (and also for Doom 2, Heretic, Hexen, Chex Quest, Strife etc...) mods!<br>
It's the revamped and updated <strong>C#</strong> version of the <a href="https://github.com/Premo36/DML_LEGACY">old VB.NET Doom Mod Loader</a>
<p align="center">
  <img src="https://user-images.githubusercontent.com/50420475/154163929-637cb73c-1fee-4a6e-ac2d-a273b29f4ffa.gif">
</p>

# MAIN FEATURES!

<ul>
<li>Works with most of modern doom sourceport (like <a href="http://zdoom.org/Download" target="_blank" rel="noopener">zdoom</a>, <a href="http://www.skulltag.com/download/" target="_blank" rel="noopener">skulltag</a>, <a href="http://gzdoom.drdteam.org/page.php?page=download" target="_blank" rel="noopener">gzdoom</a>, <a href="https://zandronum.com/download" target="_blank" rel="noopener">zandronum</a> etc... see below the tested ones)</li>
<li>Saves groups of mod you want to play togheter in presets.</li>
<li>Writes <a href="http://zdoom.org/wiki/command_line_parameters">engine console parameters</a> for you (Or even add other ones if you know them!)</li>
<li>Change mod loading order, so you can load different mods without let them replace each other stuff without control.</li>
<li>Change launching options such as the starting level, the skill level, chose if play with faster monster, let them respawn (like in NIGHTMARE! difficulty) or just remove them.</li>
<li>Change the video renderer mode.</li>
<li>Use an alternative sourceport .ini file without the need of swapping them manually.</li>
</ul>

# TESTED SOURCEPORTS (v2.6)
#### FULL COMPATIBILITY:
<ul>
<li>GZdoom (v4.14), -height and -width do not work due to gzdoom way of handling resolution)</li>
<li>LZdoom (v3.87c)</li>
<li>Zandronum (3.2)</li>
<li>Zdoom(2.8.1)</li>
<li>QZDoom (2.1.0)</li>
<li>Skulltag(98d)</li>
</ul>

#### PARTIAL COMPATIBILITY (Some DML features will not work):
<ul>
<li>Chocolate Doom (3.0.1)</li>
<li>PrBoom+ (2.6.2)</li>
</ul>

# HELP!
Take a look at [HELP.txt](HELP.txt), it's a comprehensive guide that should answer to most of your question.  
An offline version of this file is included with your dml download.

# WORKAROUDS FOR KNOWN ISSUE:
<strong>Q:</strong> I use a custom save function like 'BIND [KEY] "save QUICKSAVE.ZDS" '" in order to save my game in gzdoom/zandronum, but after I exit the game my save is gone! </br>
<strong>A:</strong> Your save is not gone, it's just saved in the wrong folder due to a weird behavior of gzdoom (or Zandronum) when you save a game this way while you started the sourceport from DML 2.X. Your missing save is in the same folder as the DML 2.X exe in Windows or in your "home" folder in Linux, move it to where your sourceport usually store your saves and then follow <a href="https://github.com/Premo36/DML2.X/issues/14#issuecomment-1066148267">this steps</a> so you dont have to always manually move the saves.<br><br>
<strong>Q:</strong> I use woof! on Windows as a sourceport but when I start it through DML 2.X using the fluidsinth backend I get an error and it reset to the system default one.</br>
<strong>A:</strong> Follow the workaround section <a href="https://github.com/Premo36/DML2.X/issues/28">here</a>. Please also note that woof! it's not a sourceport that I personally tested, although it seems to work good enough to be considered partially compatible, it's not officially supported for the time being.<br><br>
<strong>Q:</strong> I use woof! on Windows as a sourceport but when I start it through DML 2.X I get an error that says "No such option '+fullscreen'"</br>
<strong>A:</strong> Woof! will not start if an unknown argument is supplied. I've made a ad-hoc build that will not pass the +fullscreen flag. You can find the download link and more info <a href="https://github.com/Premo36/DML2.X/issues/32">here</a>. Please also note that woof! it's not a sourceport that I personally tested, although it seems to work good enough to be considered partially compatible, it's not officially supported for the time being.<br><br>
Take a look to the readme .txt bundled with DML 2.X for more Q/A.

# LICENSE
You can use the DML 2.X source code in any way you like as long as you follow the <a href ="https://github.com/Premo36/DML2.X/blob/master/LICENSE.txt"> BSD 3-Clause "New" or "Revised" License</a> terms.

# DOWNLOADS
Note: On windows requires <a href="https://www.microsoft.com/en-US/download/details.aspx?id=21">Microsoft .Net Framework 3.5</a> to work.  
Note: On Linux requires <a href="https://www.mono-project.com/download/stable/">mono-complete</a> to work.
<p>You can read stuff about the 2.6 version <a href="https://www.moddb.com/mods/doom-mod-loader/news/doom-mod-loader-v26-is-out-security-fixes-and-launch-presets-from-desktop-shortcuts">here on moddb</a> and on  <a href="https://p36software.net/blog/doom-mod-loader-v2-6">my website</a>.</p>

<p>You can find the latest stable for all supported platforms <a href ="https://github.com/Premo36/DML2.X/releases/tag/v2.6">here on github</a> and on ModDB:</p>
<p><a href="https://www.moddb.com/mods/doom-mod-loader/downloads/doom-mod-loader-v26" title="Download Doom Mod Loader v2.6 - ModDB" target="_blank"><img src="https://button.moddb.com/download/medium/294387.png" alt="Doom Mod Loader v2.6" /></a></p>


<p><a href="https://www.moddb.com/mods/doom-mod-loader" target="_blank" title="View Doom Mod Loader on Mod DB" rel="noopener"><img src="https://button.moddb.com/rating/medium/mods/43024.png" alt="Doom Mod Loader"></a></p>
<p><a href="https://www.moddb.com/mods/doom-mod-loader" target="_blank" title="View Doom Mod Loader on Mod DB" rel="noopener"><img src="https://button.moddb.com/popularity/medium/mods/43024.png" alt="Doom Mod Loader"></a></p>
<p>You can find the beta releases <a href ="https://github.com/Premo36/DML2.X/releases">here on github</a>.</p>

# CREDITS
See <a href="https://github.com/Premo36/DML2.X/blob/master/CREDITS.md">CREDITS.md</a>

# CONTACTS
If you're interested in my softwares, games, open source projects or just want to contact me, you can find me here:<br>
🔗 Website: <a href="https://p36software.net">https://p36software.net</a> <br>
✉ Info e-mail: <a href="mailto:info@p36software.net">info@p36software.net</a> <br>
🐦 Twitter: <a href="https://twitter.com/p36software">https://twitter.com/p36software</a> (@p36software)  <br>
📄 Github: <a href="https://github.com/Premo36">https://github.com/Premo36 </a><br>
🔧 ModDB: <a href="https://www.moddb.com/members/premo36">https://www.moddb.com/members/premo36</a><br>
🎮 IndieDB: <a href="https://www.indiedb.com/members/premo36">https://www.indiedb.com/members/premo36</a><br>
🎥 Youtube: <a href="https://www.youtube.com/channel/UC9yqO2r6CJeLcKebDr142eA">https://www.youtube.com/channel/UC9yqO2r6CJeLcKebDr142eA</a><br>
