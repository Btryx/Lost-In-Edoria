Prog 2 project dokumentáció
=============

Platformer game, where you control a little girl. Collect strawberries, avoid traps, kill monsters, and try not to die :)

2021.09.18.
----------

* Created Player Character in PixelStudio
* Also an ugly test platform 
* Made a sprite for the player character
* Character moves when pressing A and D
* Character jumps when pressing space
* Character image flips when player turns around
* Created Walk and Jump "animation"

2021.09.19.
----------

* Camera follows Player at all times
* Drew enemy1 -> very ugly
* Enemy moves on x
* Enemy patrols platforms
* Added basic bg
* made another two monsters
* Enemies kill player immediatelly

2021.09.20.
----------

* Got free to use unity asset: [Pixel Adventure](https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360)
* Made level 1
* Player now has 3 lives
* Drew a heart
* the hearts disappear when taking damage
* player gets pushed away from enemy when taking damage
* Made basic main menu
* Flag is a finish line, if you cross it, next level pops up
* you need to pick up key object before you can get to the next level
* collectible strawberries
* moveable box that helps you onto platform

2021.09.21.
----------

* Counter on screen tells you how much strawberries you have
* Edited main menu

2021.09.27.
---------

* You can now kill enemies buy jumping on their head
* Not the ghost tho. That's a feature. You can't jump on ghosts, obviously
* Fixed a bug with the strawberry counter (it actually works now)
* Home and Restart button
  
2021.09.30.
----------

* [Background music asset](https://assetstore.unity.com/packages/audio/music/free-music-tracks-for-games-156413)
* Background music: Potato by Brave Warrior [Youtube link](https://www.youtube.com/watch?v=-rAHaAmSGpM&t=3s)
* [Other Sounds](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)
* Jump sound when jumping, collect sounds when picking smt up, death sound when player dies, and victory sound if player touches the finishline
* Added background music
* Player gets thrown back to start of level 1 when they die even if they are on an another level, but they get maxlife every start of every level
* Started making level 2 but it looks ugly so far, will work on it later
* Updated Main Menu with monster walking around
* Made some traps if you touch them you die so don't do that
* Made some trampolins now you can jump onto higher platforms that you wouldn't be able to reach otherwise

2021.10.01.
----------
* Tried to fix trampoline bug for 2 hours, realised the mistake was in an another script. Its working now.

2021.10.04.
----------
* Made level 3 with some new features
* Made eye of sight restricted in level 3
* if you die, you get thrown back to the start of current level, but you take your lifes to the next level, they dont regenerate
* fixed moving platform bug

2021.10.07
---------
* Drew a door and a triggerbutton
* If player steps on triggerbutton, the door ahead slowly opens
* WHen player jumps off of button the door slowly closes so player has to hurry to reach it

2021.10.11.
------------
* Made a dialoguge system. Dialogues trigger when player reaches certain points/areas in the game.
* You can't move during dialogue
* You can skip to next dialogue by pressing the continue button on the dialogue box
  
2021.10.20.
-----------
* Finished dialogue
* Added an npc that talks to you sometimes, but he's not very helpful honestly
* House, tree, background and bush assets from : [here](https://assetstore.unity.com/packages/2d/characters/sunny-land-103349)
* Fixed the restart and the home button

2021.10.25.
----------
* Pressing home button will pop up a question, asking if you are sure you want to quit, because your progress will be lost(it really will)
* Added a timer and a score system that keeps tabs on your score/time until the end of the game, and displays it
* the faster you finish the game, and the more fruits you collect, the more your score will be
* When you finish the game, a new scene shows you the sum of all your scores, and the time it took you to finish the game
* Added credits at end of game

2021.10.28.
-----------
* Options menu GUI
  
2021.10.29.
----------
* Options menu settings: you can set the resolution, the volume, and there's a fullscreen option as well