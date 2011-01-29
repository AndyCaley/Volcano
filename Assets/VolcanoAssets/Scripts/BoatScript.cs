using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {
	private ArrayList contents=new ArrayList();
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter()
	{
		
	}
	
	bool IsContentObject(GameObject go)
	{
		return go.tag=="Projectile";
	}
	
	bool IsExitEdge(GameObject go)
	{
		return go.tag=="ExitEdge";
	}
	
	void OnCollisionEnter (Collision collisionInfo)
	{
		foreach (ContactPoint pt in collisionInfo) {
			GameObject other=pt.otherCollider.gameObject;
			if (IsContentObject(other)) {
				contents.Add(other);
				DebugContents();
			} else if (IsExitEdge(other)) {
				// TODO: Tally the score and do something
				// Destroy the contents and ourself
				DestroyBoat();
			}
		}
	}
	
	void OnCollisionExit (Collision collisionInfo)
	{
		foreach (ContactPoint pt in collisionInfo) {
			GameObject other=pt.otherCollider.gameObject;
			contents.Remove(other);
			DebugContents();
		}
	}
	
	void DestroyBoat()
	{
		Debug.Log("Destroying Boat");
		foreach (GameObject o in contents)
		{
			Destroy(o);
		}
		Destroy(this.gameObject);
	}
	
	void DebugContents()
	{
		Debug.Log("Boat contains " + contents.Count + " objects");
	}
}
