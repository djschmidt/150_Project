using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]

public class ZombieWalk : MonoBehaviour {
	
	public AudioClip iWillEatYou;
	public AudioClip zombieCry;
	public float health = 5.0f;
	public GameObject blood;
	private bool checkAudio = true;
	private Vector3 fwd;
	private GameObject me;
	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	static int walkState = Animator.StringToHash("Base Layer.ZombieWalk");
	static int biteState = Animator.StringToHash("Base Layer.Bite");
	
	
	// Use this for initialization
	void Start () {
		me = GameObject.Find("me");
		anim = GetComponent<Animator>();
		walkState = Animator.StringToHash("Base Layer.ZombieWalk");
		anim.SetBool("attack",false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hitinfo;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		transform.position = Vector3.Lerp(transform.position,GameObject.Find("pov").transform.position,0.0025f);
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

		
		fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position,fwd,out hitinfo,1)){
			//me.SendMessage("takeHealth",20);
			if (hitinfo.collider.gameObject.tag == "me"){
				playAnimations();
			    hitinfo.collider.gameObject.SendMessage("takeHealth",10);
			}
		}
		
		if (currentBaseState.nameHash == biteState){
			anim.SetBool("attack",false);	
		}
	}
	
	void playShot (string anim){
		animation[anim].layer = 1;
		Transform mix = transform.Find("Armature/Bone/Bone_001/Bone_002");
		animation[anim].AddMixingTransform(mix);
		animation.Play(anim);
	}
	
	void takeHealth(float points){
		health -= points;
		Instantiate(blood,GameObject.Find("Chest").transform.position,transform.rotation);
		if (health <= 0){
			Destroy(gameObject);
		}
	}
	
	void playAnimations(){
		if (currentBaseState.nameHash == walkState){
			anim.SetBool("attack",true);
		}
		
	}
}
