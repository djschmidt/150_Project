using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {
	
	private bool zombieInRoom1;
	private bool zombieInRoom2;
	private bool zombieInRoom3;
	private bool zombieInRoom4;
	private bool zombieInHall;
	private bool zombieDead;
	
	private bool playerInRoom1;
	private bool playerInRoom2;
	private bool playerInRoom3;
	private bool playerInRoom4;
	private bool playerInHall;
	
	private GameObject player;
	private PlayerLocation script;
	
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("me"); //gets the player object and initializes it to the player variable
		script = player.GetComponent<PlayerLocation>();	//get the script playerLocation so that we can access its variables
		zombieDead = false; 				//The zombie begins the game alive, well kinda...
	}
	
// Update is called once per frame
	void Update () {
		getPlayerLocation();			//Update the players location every frame
		target = getTarget();			//Based on the different situation target will equal where the zombie should be running towards
		
		if (!zombieDead)				//If zombie isn't dead, look at target
			lookAt(target);				//A function that points the zombie to look at its target
	}
	
//This function gets the current place the player is in by accessing the playerLocation script
	void getPlayerLocation ()
	{
		this.playerInRoom1 = script.playerInRoom1;
		this.playerInRoom2 = script.playerInRoom2;
		this.playerInRoom3 = script.playerInRoom3;
		this.playerInRoom4 = script.playerInRoom4;
		this.playerInHall  = script.playerInHall;
	}
	
//This funcition is called by another script when the zombie is killed
	void markZombieDead ()
	{
		zombieDead = true;	
	}
	
//The getTarget function simply returns the Game Object the zombie should be running toward based on the
//differnt scenarios of where the zombie is and where the player is.
	GameObject getTarget ()
	{
		GameObject player1 = GameObject.FindGameObjectWithTag("POV");	//The player object
		
		//These are the objects the zombie follows when it is in the hallway entering a door
		GameObject Door1In   = GameObject.FindGameObjectWithTag("Door1In");
		GameObject Door2In   = GameObject.FindGameObjectWithTag("Door2In");
		GameObject Door3In   = GameObject.FindGameObjectWithTag("Door3In");
		GameObject Door4In   = GameObject.FindGameObjectWithTag("Door4In");
		
		//These are the object the zombie follows when it is in exiting a room into the hallway
		GameObject Door1Out = GameObject.FindGameObjectWithTag("Door1Out");
		GameObject Door2Out = GameObject.FindGameObjectWithTag("Door2Out");
		GameObject Door3Out = GameObject.FindGameObjectWithTag("Door3Out");
		GameObject Door4Out = GameObject.FindGameObjectWithTag("Door4Out");

		if (zombieInRoom1)		//If zombie is in room number 1
		{
			if (playerInRoom1)	return player1;	//and the player is in room 1, chase the player
			else                return Door1Out; //otherwise leave room 1
		}
		
		else if (zombieInRoom2)	//If zombie is in room number 2
		{
			if (playerInRoom2)  return player1;	//and the player is in room 2, chase the player
			else   				return Door2Out; //and the player is in room 2, chase the player
		}
		
		else if (zombieInRoom3)	//If zombie is in room number 3
		{
			if (playerInRoom3)  return player1;	//and the player is in room 3, chase the player
			else                return Door3Out; //and the player is in room 3, chase the player
		}
		
		else if (zombieInRoom4)	//If zombie is in room number 4
		{
			if (playerInRoom4)  return player1;	//and the player is in room 4, chase the player
			else                return Door4Out; //and the player is in room 4, chase the player
		}
		
		else if (zombieInHall) //If the zombie is in the hallway
		{
			if (playerInHall)		return player1; //and if the player is in the hallway, chase the player
			
			else if (playerInRoom1) return Door1In; //or if the player is currently in room 1 head towards door 1
			
			else if (playerInRoom2) return Door2In;	//or if the player is currently in room 2 head towards door 2
			
			else if (playerInRoom3) return Door3In;	//or if the player is currently in room 3 head towards door 3
			
			else      	            return Door4In;	//or if the player is currently in room 4 head towards door 4
		}
		else
			return Door1In;	//If none of these conditions meet return null, hopefully that doesn't happen
	}

//This function that faces the zombie in the direction it should be moving towards
	void lookAt(GameObject obj)	
	{
		Quaternion rot = Quaternion.LookRotation(obj.transform.position - transform.position);
		transform.rotation = rot;
	}
	
//This function triggers whenever a zombie is entering a room
	void OnTriggerEnter (Collider obj)	
	{
		string colliderTag = obj.gameObject.tag; //Gets the tag from the object that the zombie passed through
		
		if (colliderTag == "Room1")	//If zombie enters room number 1.
		{
			zombieInRoom1 = true;
			zombieInRoom2 = false;
			zombieInRoom3 = false;
			zombieInRoom4 = false;
			zombieInHall  = false;
		}
		
		else if (colliderTag == "Room2") //If zombie enters room number 2.
		{
			zombieInRoom1 = false;
			zombieInRoom2 = true;
			zombieInRoom3 = false;
			zombieInRoom4 = false;
			zombieInHall  = false;
		}
		
		else if (colliderTag == "Room3") //If zombie enters room number 3.
		{
			zombieInRoom1 = false;
			zombieInRoom2 = false;
			zombieInRoom3 = true;
			zombieInRoom4 = false;
			zombieInHall  = false;
		}
		
		else if (colliderTag == "Room4") //If zombie enters room number 4.
		{
			zombieInRoom1 = false;
			zombieInRoom2 = false;
			zombieInRoom3 = false;
			zombieInRoom4 = true;
			zombieInHall  = false;
		}
	}
	
//This function is triggered whenever a zombie is leaving a room
	void OnTriggerExit (Collider obj)	
	{
		//For every door zombieInHall variable is initialized
		//to true, this is because no matter what room the zombie is 
		//exiting it will be entering the hallway, this is simply due 
		//to the structure of the map.
		
		string colliderTag = obj.gameObject.tag; //Get the tag from the object that the zombie passed through
		
		if (colliderTag == "Room1" || colliderTag == "Room2" || colliderTag == "Room3" || colliderTag == "Room4")
		{
			zombieInRoom1 = false;
			zombieInRoom2 = false;
			zombieInRoom3 = false;
			zombieInRoom4 = false;
			zombieInHall  = true;
		}
	}
}
