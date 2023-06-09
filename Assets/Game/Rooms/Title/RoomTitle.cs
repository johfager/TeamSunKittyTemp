using UnityEngine;
using System.Collections;
using PowerScript;
using PowerTools.Quest;
using static GlobalScript;

public class RoomTitle : RoomScript<RoomTitle>
{
	public void OnEnterRoom()
	{
		
		// Hide the inventory in the title scene
		G.InventoryBar.Hide();
		G.Toolbar.Hide();
		// Later we could start some music here
		Audio.PlayMusic("SoundMain Theme [Mastered]", 1);
	}

	public IEnumerator OnEnterRoomAfterFade()
	{
		Cursor.Visible = true;
		// Start cutscene, so this can be skipped by pressing ESC
		E.StartCutscene();
		
		
		// Wait a moment
		yield return E.Wait(0.5f);
		
		// Check if we have any save games. If so, turn on the "continue" prop.
		if (  E.GetSaveSlotData().Count > 0 )
		{
			// Enable the "Continue" prop and start it fading in
			Prop("Continue").Enable();
			Prop("Continue").FadeBG(0,1,1.0f);
		}
		
		// Turn on the "new game" prop and fade it in
		Prop("New").Enable();
		yield return Prop("New").Fade(0,1,1.0f);
		
		// This is the point the game will skip to if ESC is pressed
		E.EndCutscene();
		
	}

	public IEnumerator OnInteractPropNew( Prop prop )
	{		
		// Turn on the inventory and info bar now that we're starting a game
		G.InventoryBar.Show();
		G.Toolbar.Show();
		Audio.Stop("SoundMain Theme [Mastered]", 1);
		// Move the player to the room
		E.ChangeRoomBG(R.Bedroom);
		
		yield return E.ConsumeEvent;
	}

	public IEnumerator OnInteractPropContinue( Prop prop )
	{
		// Restore most recent save game
		E.RestoreLastSave();
		yield return E.ConsumeEvent;
	}

}
