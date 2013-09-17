using UnityEngine;
using System.Collections;

public class ZombieWalk : MonoBehaviour {
	
	public AudioClip iWillEatYou;
	public AudioClip zombieCry;
	public int health = 100;
	private bool checkAudio = true;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		animation.Play("zombieWalk");
		
		transform.position = Vector3.Lerp(transform.position,GameObject.Find("pov").transform.position,0.005f);
		transform.LookAt(GameObject.Find("pov").transform.position);
		if (checkAudio){
		audio.clip = iWillEatYou;
		audio.Play();
		checkAudio = false;
		}
		if(!audio.isPlaying){
			audio.clip = zombieCry;
			audio.Play();	
		}
	}
	
	void playShot (string anim){
		animation[anim].layer = 1;
		Transform mix = transform.Find("Armature/Bone/Bone_001/Bone_002");
		animation[anim].AddMixingTransform(mix);
		animation.Play(anim);
	}
	
	void takeHealth(int points){
		health -= points;
		if (health <= 0){
			Destroy(gameObject);
		}
	}
}
