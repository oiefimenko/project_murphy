using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using E = Enums;

public class Room : MonoBehaviour {
	
	public E.RoomTypes roomType;

	// Room objects
	public Dictionary<Room, Neighbor> neighbors = new Dictionary<Room, Neighbor>();
	private List<ICharacter> characters = new List<ICharacter>();
	private Furniture[] furniture;
	
	// Room state
	public RoomStats State { get; set; } 
	
	// Use this for initialization
	void Awake () {
		State = new RoomStats();
		furniture = GetComponentsInChildren<Furniture>();
		foreach (Furniture item in furniture) item.currentRoom = this;
	}
	
	public void AddNeighbor (Room newNeighbor, Door betweenDoor)
	{
		if (!neighbors.ContainsKey(newNeighbor)) 
			neighbors.Add (newNeighbor, new Neighbor(newNeighbor, this, betweenDoor));
	}

	// Add Character to Rooms Character List
	void OnTriggerEnter2D (Collider2D otherCollider) 
	{
		ICharacter otherCharacter = otherCollider.GetComponent<CharacterMain>();
		if (otherCharacter != null && !characters.Contains(otherCharacter)) characters.Add(otherCharacter);
	}

	// Delete Character from Rooms Character List
	void OnTriggerExit2D (Collider2D otherCollider) 
	{
		ICharacter otherCharacter = otherCollider.GetComponent<CharacterMain>();
		if (otherCharacter != null && characters.Contains(otherCharacter)) characters.Remove(otherCharacter);
	}

	// Check if Room continse hostile Character
	public ICharacter ContainsHostile (ICharacter character) 
	{
		foreach (ICharacter visitor in characters)
		{
			if (character != visitor && SidesRelations.Instance.IsEnemies(character, visitor)) return visitor;
		}
		return null;
	}

	// Check if Room continse unconscious Character
	public ICharacter ContainsUnconscious ()
	{
		foreach (ICharacter character in characters)
		{
			if (character.Stats.IsUnconscious() && !character.Lock) return character;
		}
		return null;
	}

	// Check if Room continse dead Character
	public ICharacter ContainsDead ()
	{
		foreach (ICharacter character in characters)
		{
			if (character.Stats.IsDead() && !character.Lock) return character;
		}
		return null;
	}

	// Check if Room continse wounded Character
	public ICharacter ContainsWounded (ICharacter character)
	{
		foreach (ICharacter visitor in characters)
		{
			if (visitor.Stats.IsWounded() && visitor != character && !visitor.Lock) return visitor;
		}
		return null;
	}

	// Returns free room furniture object
	public Furniture GetUnoccupiedRoomObject ()
	{
		Furniture resultObject = null;
		List<Furniture> unoccypiedObjects = new List<Furniture>();
		foreach (Furniture item in furniture)
			if (item.isFree) unoccypiedObjects.Add (item);
		if (unoccypiedObjects.Count > 0) 
			resultObject = Helpers.GetRandomArrayValue<Furniture>(unoccypiedObjects);
		return resultObject;
	}

	public Vector3 GetRandomRoomPoint ()
	{
		Vector3 collCenter = collider2D.bounds.center;
		Vector3 collExt = collider2D.bounds.extents * 0.85f;
		float x = Random.Range(collCenter.x - collExt.x, collCenter.x + collExt.x);
		float y = Random.Range(collCenter.y - collExt.y, collCenter.y + collExt.y);
		return new Vector3(x, y, gameObject.transform.position.z);
	}

	public void Repair (float amount)
	{
		State.Durability += amount;
	}

	public void Extinguish (float amount)
	{
		State.FireLevel -= amount;
	}

	public void Deactivate (float amount)
	{
		State.RadiationLevel -= amount;
	}

	public void ChemistryClearing (float amount)
	{
		State.RadiationLevel -= amount;
	}

	public void Untrack (ICharacter character) {
		characters.Remove(character);
	}
}