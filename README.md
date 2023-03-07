# PRESS YOUR LUCK APPLICATION 
 School Assignment - Faux Gambling Card Matching App
 Inline-style: ![alt text](https://github.com/A-Mac2513/A-Mac2513-Press_Your_LucK.github.io/blob/main/Images/icon.ico "Icon Logo")
 ___
 # ABOUT

 > This app a simple betting game that uses sessions, serialization and cookies to keep track of most of the information in this game.
 
 > ### The following highlights some of the techniques you will be employing in this assignment.  
 >	The current player name and their total number of current coins will be stored in a cookie so that it can persist across sessions
 >	The current game state (for the current player) will be stored in a Session
 >	Essentially a game consists of a List of (randomly generated) Tile objects. 
 >  You will use the `NewtonSoft.Json` package to serialize/deserialize the current game to/from the session as Json strings.
 >	You will implement some static helper methods along the way to make it easier to interact with the required Session & Cookie data
 >	__NOT IMPLEMENTED YET__ Once that is all working you will build on the solution to store an audit trail in a SQL server database


 ___
  # Game Play
 > To start with, you enter your Name and the number of coins you’re starting with.
 > To start playing, you choose how many coins to bet, then 12 tiles are shuffled face down.
 > Each round you either choose a tile or take the coins you’ve won so far.  
 > If you choose a tile and it shows 0, you bust and lose your bet.  
 > If it has a number, your bet is multiplied by that number and the remaining tile values are doubled.
 > Once you choose to take the coins, the amount is added to your total coins, and you can start a new game or cash out and stop playing.
 > In addition to this, you’ll also create audit records to keep track of winnings and losings.

 ## Repository
 > 




 The Reader “about the project”
o The Reader about “navigating your repo”
o The Developer how to:
? Adhere to any guidelines for the project
? TEST the component and project (i.e. unit testing, processes, Issue handling, etc.)
? Build the project and “get it out live”
? Create the LINK for the installed project
o The Reader about
? how future enhancements and bug-fixing will be handled (ie. “Version Control”)
o The user about
? HOW TO RUN project
• (i.e. “now that I see the link, NOW what do I do with it??)