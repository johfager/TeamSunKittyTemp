using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEndScene : RoomScript<RoomEndScene>
{
	void OnEnterRoom()
	{
		
		
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		yield return C.Display("You eventually left the quaint house");
		yield return C.Display("Little Did you know that was only the beginning");
		yield return C.Display("Time got lost on you in your search");
		yield return C.Display("But it all lead you here");
		yield return C.Kettil.Say("“I’ve been asleep too long. Thank you for waking me. The stone… Must be fixed. We’re stuck here. Every day…. The same.”");
		yield return C.Display("“No! No! You’re going to kill me!”");
		yield return C.Display("*Sound for impeding doom playing*");
		yield return C.Display("“It’ll be your fault! You’ll doom me and everyone here!”");
		yield return C.Kettil.Say("“NO! WHAT HAVE YOU DONE!?”");
		Display:
		yield return E.Break;
	}
}