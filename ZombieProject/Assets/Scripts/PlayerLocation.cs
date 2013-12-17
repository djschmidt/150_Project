using UnityEngine;
using System.Collections;

public class PlayerLocation : MonoBehaviour {
	
	//This script is accessed by the ZombieAI script which retrieves the following variables every frame
	
	public bool playerInRoom1;
	public bool playerInRoom2;
	public bool playerInRoom3;
	public bool playerInRoom4;
	public bool playerInHall;
	public bool playerInChurchTower;
	
	
	void OnTriggerEnter (Collider obj) //This function triggers whenever the player is entering a room
	{
		
		string colliderTag = obj.gameObject.tag; //Gets the tag from the object that the player passed through
		
		if (colliderTag == "Room1")		//If the player entered room 1
		{
			playerInRoom1 = true;
		 	playerInRoom2 = false;
			playerInRoom3 = false;
			playerInRoom4 = false;
			playerInHall  = false;
		}
		
		else if (colliderTag == "Room2")	//If the player entered room 2
		{
			playerInRoom1 = false;
			playerInRoom2 = true;
			playerInRoom3 = false;
			playerInRoom4 = false;
			playerInHall  = false;
		}
		
		else if (colliderTag == "Room3")	//If the player entered room 3
		{
			playerInRoom1 = false;
			playerInRoom2 = false;
			playerInRoom3 = true;
			playerInRoom4 = false;
			playerInHall  = false;
		}
		
		else if (colliderTag == "Room4")	//If the player entered room 4
		{
			playerInRoom1 = false;
			playerInRoom2 = false;
			playerInRoom3 = false;
			playerInRoom4 = true;
			playerInHall  = false;
		}

		else if (colliderTag == "TopOfTower") //If the player has reached the top of the abandoned church tower
		{
			playerInRoom1 = false;
			playerInRoom2 = false;
			playerInRoom3 = false;
			playerInRoom4 = false;
			playerInHall  = false;
			playerInChurchTower = true;
		}
		

		
		
	}
	
	void OnTriggerExit (Collider obj) //This function triggers whenever the player is exiting a room
	{
		string colliderTag = obj.gameObject.tag; //Gets the tag from the object that the player passed through
		
		if (colliderTag == "Room1" || colliderTag == "Room2" || colliderTag == "Room3" || colliderTag == "Room4")
		{
			playerInRoom1 = false;
			playerInRoom2 = false;
			playerInRoom3 = false;
			playerInRoom4 = false;
			playerInHall  = true;
		}
			
	}
}
