using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace JhinFour
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        bool prevUsingSlingshot;
        bool usingSlingshot;
        int soundCount;
        CueDefinition one_cue = new CueDefinition();
        CueDefinition two_cue = new CueDefinition();
        CueDefinition three_cue = new CueDefinition();
        CueDefinition four_cue = new CueDefinition();

        // Adding the name for the cue, which will be
        // the name of the audio to play when using sound functions.


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += this.checkFiring;
            usingSlingshot = false;
            prevUsingSlingshot = false;
            soundCount = 1;

            one_cue.name = "One";
            two_cue.name = "Two";
            three_cue.name = "Three";
            four_cue.name = "Four";

            one_cue.instanceLimit = 1;
            two_cue.instanceLimit = 1;
            three_cue.instanceLimit = 1;
            four_cue.instanceLimit = 1;

            one_cue.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
            two_cue.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
            three_cue.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
            four_cue.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
            //------------First Shot Sound Cue-------------//
            SoundEffect audio;
            string filePathCombined = Path.Combine(this.Helper.DirectoryPath, "attackAudio", "BasicAttack_One.wav");
            this.Monitor.Log(filePathCombined, LogLevel.Debug);
            using (var stream = new System.IO.FileStream(filePathCombined, System.IO.FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
            // Setting the sound effect to the new cue.
            one_cue.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);

            // Adding the cue to the sound bank.
            Game1.soundBank.AddCue(one_cue);

            //------------Second Shot Sound Cue-------------//
            filePathCombined = Path.Combine(this.Helper.DirectoryPath, "attackAudio", "BasicAttack_Two.wav");
            using (var stream = new System.IO.FileStream(filePathCombined, System.IO.FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
            // Setting the sound effect to the new cue.
            two_cue.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);

            // Adding the cue to the sound bank.
            Game1.soundBank.AddCue(two_cue);

            //------------Third Shot Sound Cue-------------//
            filePathCombined = Path.Combine(this.Helper.DirectoryPath, "attackAudio", "BasicAttack_Three.wav");
            using (var stream = new System.IO.FileStream(filePathCombined, System.IO.FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
            // Setting the sound effect to the new cue.
            three_cue.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);

            // Adding the cue to the sound bank.
            Game1.soundBank.AddCue(three_cue);

            //------------Fourth Shot Sound Cue-------------//
            filePathCombined = Path.Combine(this.Helper.DirectoryPath, "attackAudio", "BasicAttack_Four.wav");
            using (var stream = new System.IO.FileStream(filePathCombined, System.IO.FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
            // Setting the sound effect to the new cue.
            four_cue.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);

            // Adding the cue to the sound bank.
            Game1.soundBank.AddCue(four_cue);
        }

        private void checkFiring(object sender, UpdateTickedEventArgs e)
        {
            usingSlingshot = Game1.player.usingSlingshot;
            if (usingSlingshot) this.Monitor.Log("Using slingshot", LogLevel.Debug);
            if (usingSlingshot == false && prevUsingSlingshot == true)
            {

                playSound();
            }
            prevUsingSlingshot = usingSlingshot;
        }

        private void playSound()
        {
            if (soundCount == 1) Game1.playSound("One");
            else if (soundCount == 2) Game1.playSound("Two");
            else if (soundCount == 3) Game1.playSound("Three");
            else if (soundCount == 4) Game1.playSound("Four");
            soundCount++;
            if(soundCount > 4) soundCount = 1;
            return;
        }

        
    }
}