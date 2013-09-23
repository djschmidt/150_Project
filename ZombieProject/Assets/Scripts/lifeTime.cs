using UnityEngine;
using System.Collections;

public class lifeTime : MonoBehaviour {
	
	public float bloodLife = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bloodLife += Time.deltaTime;
		if (bloodLife > 0.4)
		{
		    Destroy(gameObject);	
		}	
	}
}
