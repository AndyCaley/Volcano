using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public GameObject Target;
	public float Speed;
	public bool DestroyOnFinish;
	
	float MIN_DIST = 0.0001f;
	
	// Use this for initialization
	void Start () {
	}
	
	
	void Update()
	{
		
		
	}
	
	/*
	 * //Old not so cool movement
	// Update is called once per frame
	void Update () {
		if(Target == null)
			return;
		
		Debug.DrawLine(this.transform.position, Target.transform.position);
		float distance = Vector3.Distance(this.transform.position, Target.transform.position);
		if(distance < MIN_DIST)
			Destroy(this.gameObject);
		this.transform.position = Vector3.MoveTowards(this.transform.position, Target.transform.position, Time.deltaTime * Speed);
		
		Quaternion rot = Quaternion.LookRotation(Target.transform.position - this.transform.position);
		this.transform.rotation = rot;

	}
	*/
}
