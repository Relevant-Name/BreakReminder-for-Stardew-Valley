using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Menus;
using static StardewValley.Game1;
using StardewValley.Characters;

namespace StardewTest1
{
    internal sealed class ModEntry : Mod
    {

		private int daysPassed = -1;
		private DialogueBox stupidBox;
		private bool isBoxOpen = false;
		private TimeSpan t = TimeSpan.FromSeconds(0);
		private string timeFormatted;

		public override void Entry(IModHelper helper)
        {

            helper.Events.GameLoop.DayStarted += this.StopHavingFun;
            helper.Events.GameLoop.OneSecondUpdateTicked += this.Tickssad;
			helper.Events.Display.MenuChanged += this.fuckingboxdetect;


		}

		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		private void fuckingboxdetect(object sender, MenuChangedEventArgs menuchangearg) 
		{

			if (menuchangearg.NewMenu == stupidBox)
			{
				isBoxOpen = true;
			} 
			else 
			{ 
				isBoxOpen = false; 
			}
			
		}

		private void Tickssad(object sender, OneSecondUpdateTickedEventArgs onesecupdatetickarg)
        {

			
			timeFormatted = string.Format("{0:D2}h:{1:D2}m", //:{2:D2}s
							t.Hours,
							t.Minutes,
							t.Seconds);

			this.Monitor.Log(timeFormatted, LogLevel.Debug);
			
			if (!isBoxOpen)
			{
				t += TimeSpan.FromSeconds(1);
			}

		}
		
        

        private void StopHavingFun(object sender, DayStartedEventArgs daystartedargs) 
        {
			daysPassed++;

			if (Context.IsWorldReady)
            {
				stupidBox = new DialogueBox("You've played for " + daysPassed + " days,^with a total time of " + t + "^");
				Game1.activeClickableMenu = stupidBox;
			}
            

        }

    }
}


/*
 * TODO but not really im content with how it is:
 * 
 * probably don't have it tick on title screen
 * 
 * make config, preferablly changable in game and save but that might be too hard so just the config
 * flame user increasingly
 * maybe make option to alt f4 in text box
 * 
 */