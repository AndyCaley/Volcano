using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {
	
	public bool Fire = false;
	
	public MouseAimer Target;
	
	public float Power;
	
	public float Angle;
	
	public Rigidbody ProjectilePrefab;
	
	public GameObject TargetMarkerPrefab;
	
	public float Spin;
	
	public float Distance;
	
	float GRAVITY = 9.81f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Target.IsActive)
		{
			// simple delta direction from cannon to mouse pointer position
			Distance = Vector3.Distance(this.transform.position, Target.CurrentPosition);
			
//			Distance = distance;
			
			// Rotation around local X of the cannon 
			Angle = 0.5f * Mathf.Asin((GRAVITY*Distance)/(Power*Power)) * Mathf.Rad2Deg;
			Debug.Log (Angle);
			
			Angle = 90f - Angle;
			
			if(!float.IsNaN(Angle))
			{
				// vector relative to the cannon's position
				Vector3 lookToVector = Target.CurrentPosition - this.transform.position;
				// override y for angle logic
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
			
			newProjectile.transform.rotation = this.transform.rotation;
			
			newProjectile.AddRelativeForce(0, 0, Power, ForceMode.VelocityChange);
			newProjectile.AddRelativeTorque(Random.Range(0, Spin), Random.Range(0, Spin), Random.Range(0, Spin), ForceMode.Impulse);
			Fire=false;
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			Rigidbody newProjectile = Instantiate(ProjectilePrefab, Target.CurrentPosition, this.transform.rotation) as Rigidbody;
			
			newProjectile.transform.Translate(0, 10, 0, Space.World);
			
		}
		
	}
}
