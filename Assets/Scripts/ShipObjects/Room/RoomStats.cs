﻿using UnityEngine;
using System.Collections;

public class RoomStats : MonoBehaviour {

	private float maxDurability;
	private float durability;
	private float fireLevel;
	private float radiationLevel;
	private float chemistryLevel;
	private float plantsLevel;
	private bool unelectryfied;
	private bool weatherThreat;
	private bool noGravity;

	private float MaxDurability { get { return maxDurability; } set { maxDurability = value; } }
	public float Durability { get { return durability; } set { durability = value; } }
	public float FireLevel { get { return fireLevel; } set { fireLevel = value; } }
	public float RadiationLevel { get { return radiationLevel; } set { radiationLevel = value; } }
	public float ChemistryLevel { get { return chemistryLevel; } set { chemistryLevel = value; } }
	public float PlantsLevel { get { return plantsLevel; } set { plantsLevel = value; } }
	public bool Unelectryfied { get { return unelectryfied; } set { unelectryfied = value; } }
	public bool WeatherThreat { get { return weatherThreat; } set { weatherThreat = value; } }
	public bool NoGravity { get { return noGravity; } set { noGravity = value; } }

	public void Awake ()
	{
		MaxDurability = 200f;
		Durability = MaxDurability;
		FireLevel = 0f;
		RadiationLevel = 0f;
		ChemistryLevel = 0f;
		PlantsLevel = 0f;
		Unelectryfied = false; 
		WeatherThreat = false; 
		NoGravity = false;
	}

	private void Update ()
	{
		Mathf.Clamp(durability, -1f, maxDurability);
		Mathf.Clamp(fireLevel, -1f, 100f);
		Mathf.Clamp(radiationLevel, -1f, 100f);
		Mathf.Clamp(chemistryLevel, -1f, 100f);
		Mathf.Clamp(plantsLevel, -1f, 100f);
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

	public bool IsPlantMutated ()
	{
		return PlantsLevel > 0f; 
	}

}
