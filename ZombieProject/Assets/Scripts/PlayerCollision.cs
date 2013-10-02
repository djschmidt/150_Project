using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
	public int health = 100;
	private GameObject tip;
	private Vector3 fwd;
	private float t = 0;
	public  AudioClip machineGun;
	private bool isShooting = false;
	// Use this for initialization
	void Start () {
		tip = GameObject.Find("tip");
	}
	
	
	void Update(){
		
		if (!isShooting){
			GameObject.Find("ak47").animation.Play("idle");
		}
		
		if (isShooting){
			GameObject.Find("ak47").animation.Play("recoil");	
		}
		
		if(Input.GetButton("Fire1")){
			
			isShooting = true;
			
			if (!audio.isPlaying){
				audio.clip = machineGun;
				audio.Play();
				t = 0;
			}
		
			t+= Time.deltaTime;
			
			if (t > 0.8f){
			audio.Stop();
			audio.Play();
			t = 0;
			}
			
			RaycastHit hit;
			fwd = tip.transform.right;
			Debug.DrawRay(tip.transform.position,fwd, Color.blue,100);
			if(Physics.Raycast(tip.transform.position,fwd,out hit,100)){
				if(hit.collider.gameObject.tag == "leftShoulder"){
					hit.collider.gameObject.transform.root.gameObject.SendMessage("playShot","shotLeft");
					hit.collider.gameObject.transform.root.gameObject.SendMessage("takeHealth",20);
			}
				else if (hit.collider.gameObject.tag == "rightShoulder"){
					hit.collider.gameObject.transform.root.gameObject.SendMessage("playShot","shotRight");
				}
				else if (hit.collider.gameObject.tag == "zombie"){
						hit.collider.gameObject.SendMessage("takeHealth",2.5f);
					}
				}
		}
		if (Input.GetButtonUp("Fire1")){
			isShooting = false;	
			audio.Stop();
	}
	}

	
	void takeHealth (int hp){
		health -= hp;
		if (health <= 0){
			Destroy(gameObject);
	     }
	}
	/*
	void OnControllerColliderHit (ControllerColliderHit hit){
		if (hit.gameObject.tag == "leftShoulder"){
			hit.transform.root.gameObject.SendMessage("playShot");
		}
	}*/
}
