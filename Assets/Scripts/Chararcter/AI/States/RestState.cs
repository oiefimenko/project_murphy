﻿using UnityEngine;
using System.Collections;

public class RestState : StateBase {
	
	private int stateIndex = 14;
	private int tick;

	public RestState (CharacterMain character) : base(character) { }

	public override int StateKind { get { return stateIndex; } }

	public override bool CheckCondition (Room room) 
	{
		return true;
	}

	public override void Actualize () { 
		base.Actualize (); 
		character.Movement.Walk().ToFurniture(ShipState.Inst.specRooms[Enums.RoomTypes.LivingQuarters], "Random");
		tick = Random.Range(7, 10);
	}
	
	public override void ExecuteStateActions () 
	{
		if (character.Movement.IsMoving == false)
		{
			tick -= 1;
			character.View.SetSubState(1);
		}
		base.ExecuteStateActions ();
	}
	
	public override bool PurgeCondition () 
	{
		return tick <= 0;
	}
}