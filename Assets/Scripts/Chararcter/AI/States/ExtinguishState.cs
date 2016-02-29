﻿using UnityEngine;
using System.Collections;

public class ExtinguishState : StateBase {

	private int stateIndex = 7;
	
	public ExtinguishState (CharacterMain character) : base(character) { }
	
	public override int StateKind { get { return stateIndex; } }

	public override bool CheckCondition (Room room) 
	{
		return room.Stats.IsOnFire();
	}

	public override void Actualize () { 
		base.Actualize (); 
		character.Movement.Walk().ToPoint(character.Movement.CurrentRoom.Objects.GetRandomRoomPoint());
	}
	
	public override void ExecuteStateActions () 
	{
		character.Movement.CurrentRoom.Extinguish(character.Stats.FireExtinguish);
		if (character.Movement.IsMoving == false)
			character.View.SetSubState(1);
		base.ExecuteStateActions ();
	}
	
	public override bool PurgeCondition () 
	{
		return character.Movement.CurrentRoom.Stats.IsOnFire() == false;
	}
}
