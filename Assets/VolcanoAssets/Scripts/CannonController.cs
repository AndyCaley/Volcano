using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {
	
	public bool Fire = false;
	
	public MouseAimer Target;
	
	public float Power;
	
	public float Angle;
	
	public Rigidbody ProjectilePrefab;
	
	public GameObject TargetMarkerPrefab;
	
	float GRAVITY = 9.81f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Target.IsActive)
		{
			float distance = Vector3.Distance(this.transform.position, Target.CurrentPosition);
		
			Angle = .5f*Mathf.Asin((GRAVITY*distance)/(Power*Power)) * Mathf.Rad2Deg;
			
			Angle = 90f - Angle;
			
			if(!float.IsNaN(Angle))
			{
				
				Vector3 lookToVector = Target.CurrentPosition - this.transform.position;
				lookToVector.y = 0;
				this.transform.rotation = Quaternion.LookRotation(lookToVector);
				
				this.transform.rotation *= Quaternion.AngleAxis(-Angle, Vector3.right);

			}
			
		}	
		
		if(Input.GetMouseButtonDown(0))
		{
			Rigidbody newProjectile = Instantiate(ProjectilePrefab, this.transform.position, this.transform.rotation) as Rigidbody;
			
			if(TargetMarkerPrefab != null)
			{
				Instantiate(TargetMarkerPrefab, Target.CurrentPosition, Quaternion.identity);
			}
			
			newProjectile.AddRelativeForce(0, 0, Power, ForceMode.VelocityChange);
			
			Fire=false;
		}
		
	}
}
