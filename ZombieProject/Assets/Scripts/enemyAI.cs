using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {
	
	public Transform me;
	private float distance;
	private float lookAtDistance = 25.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(me.position, transform.position);
		
		if (distance < lookAtDistance)
		{
			renderer.material.color = Color.yellow;
		}
	}
}
