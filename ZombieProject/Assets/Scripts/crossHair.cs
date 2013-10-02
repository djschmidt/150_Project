using UnityEngine;
using System.Collections;

public class crossHair : MonoBehaviour {
	
	public GUITexture crosshair;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
				crosshair.enabled = true;
			
		}
	}
}
