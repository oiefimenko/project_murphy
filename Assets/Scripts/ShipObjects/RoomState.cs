﻿using UnityEngine;
using System.Collections;

public class RoomState {

	public float MaxDurability { get; set; }
	public float Durability { get; set; } 
	public float FireLevel { get; set; }
	public float RadiationLevel { get; set; }
	public float ChemistryLevel { get; set; }

	public RoomState ()
	{
		MaxDurability = 200f;
		Durability = MaxDurability;
		FireLevel = 0f;
		RadiationLevel = 0f;
		ChemistryLevel = 0f;
	}

	public bool IsBroken ()
	{
		return Durability < MaxDurability;
	}

	public bool IsOnFire ()
	{
		return FireLevel > 0f;
	}

	public bool IsRadioactive ()
	{
		return RadiationLevel > 0f;
	}

	public bool IsHazardous ()
	{
		return ChemistryLevel > 0f;
	}
}
