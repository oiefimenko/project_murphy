﻿using UnityEngine;
using System.Collections;

public interface IMovement
{
	Room CurrentRoom { get; }

	MovementTarget Target { get; }

	bool IsMoving { get; }

	IMovement Walk ();

	IMovement Run ();

	void ToRoom (Room room);

	void ToFurniture (Room room, string item);

	void ToCharacter (ICharacter character);
	
	void ToItem (Item item);

	void ToPoint (Vector3 point);

	void Pull (IMovable other);
	
	bool IsNearObject (GameObject exactObject);
	
	void AdjustPostion (Vector3 endPoint);
	
	void Purge ();
}
