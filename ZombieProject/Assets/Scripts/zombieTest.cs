using UnityEngine;
using System.Collections;


public class zombieTest : MonoBehaviour {
	Transform mix;
	// Use this for initialization
	void Start () {
	mix = transform.Find("Armature/Bone_0/Bone_001");
	}
	
	// Update is called once per frame
	void Update () {
	 	animation.Play("shotLeft");
	}
	
	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.name == "me"){
			animation.Play("flipOff");		
		}
	}
}
