using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
	public int health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	
	void Update(){
		
		if(Input.GetButtonDown("Fire1")){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,100)){
				if(hit.collider.gameObject.tag == "leftShoulder"){
					hit.collider.gameObject.transform.root.gameObject.SendMessage("playShot","shotLeft");
					hit.collider.gameObject.transform.root.gameObject.SendMessage("takeHealth",20);
			}
				else if (hit.collider.gameObject.tag == "rightShoulder"){
					hit.collider.gameObject.transform.root.gameObject.SendMessage("playShot","shotRight");
				}
				
				else if (hit.collider.gameObject.tag == "zombie"){
					hit.collider.gameObject.SendMessage("takeHealth",20);
				}
		}
	}
}
	
	void OnCollisionEnter(Collision obj){
		
		if (obj.gameObject.tag == "zombie"){
			health -= 20;
			if (health <= 0){
				print ("dead");
			}
		}
	}
	/*
	void OnControllerColliderHit (ControllerColliderHit hit){
		if (hit.gameObject.tag == "leftShoulder"){
			hit.transform.root.gameObject.SendMessage("playShot");
		}
	}*/
}
