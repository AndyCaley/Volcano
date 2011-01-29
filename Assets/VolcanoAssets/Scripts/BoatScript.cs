using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter()
	{
		
	}
	
	void OnCollisionEnter (Collision collisionInfo)
	{
		Debug.Log("collision");
		foreach (ContactPoint pt in collisionInfo) {
			//GameObject other=pt.otherCollider.gameObject;
			//Debug.Log("Other: " + typeof(other).Name + ": " + other);
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("Trigger");
	}
}
