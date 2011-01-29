using UnityEngine;
using System.Collections;

public class AnimalManager : MonoBehaviour {
	
	public GameObject[] Animals;
	
	public GameObject StartPoint;
	
	public GameObject EndPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(StartPoint.transform.position, "VolcanoAssets//Icons//StartIcon");
		Gizmos.DrawIcon(EndPoint.transform.position, "VolcanoAssets//Icons//EndIcon");
		Debug.DrawLine(StartPoint.transform.position, EndPoint.transform.position);
	}
}
