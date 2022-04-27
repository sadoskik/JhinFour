# Summary
This is a mod for Stardew Valley which plays the Jhin counting voiceline each time the sling shot is used. It keeps track of the last voiceline and uses the appropriate next one (ie. "One" then "Two"). 
# Motivation
I really enjoy the game and thought it would be a fun intersection of my two favorite things. It was a good introduction to modding in Stardew and will be a good stepping stone to a larger mod project I have in mind.
# Technical Details
The selection of events raised by SMAPI left a lot to be desired. I wanted an event at least for when the player uses a tool, but I did not find that. Instead, I wrote a handler for the GameTick event and checked if the player was "Using Slingshot" and keeps track of that value. The current value is compared against the previous one to detect a falling edge (Using -> not using). That triggers the playSound method which checks what the correct sound to play is.
# Challenges
* As mentioned before, the SMAPI does not offer a lot of events to bind handlers to. Whether that is a shortcoming of the extension or the base game, I cannot say. 
* The soundbytes for Jhin were obtained from the League of Legends fan wiki. There is no easy way to download the sound files, but inspecting the html source reveals the URL for each sound byte. These came in .ogg format.
* Through some error of the System.IO.FileStream() constructor, it was having issues opening the .ogg files. Luckily SV accepts .wav sound format as well. That worked fine.