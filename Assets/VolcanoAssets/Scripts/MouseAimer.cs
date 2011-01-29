using UnityEngine;
using System.Collections;

public class MouseAimer : MonoBehaviour {
	
	public GameObject CrossHairsPrefab;
	public GameObject TargetPlane;
	public Vector3 CurrentPosition;
	public bool IsActive;
	
	GameObject _currentCrossHairs;
	
	Plane _intersectionPlane;
	
	// Use this for initialization
	void Start () {
		_currentCrossHairs = Instantiate(CrossHairsPrefab) as GameObject;
		_intersectionPlane = new Plane(Vector3.up, TargetPlane.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
		float distance = 0;
		
		Debug.DrawRay(mouseRay.origin, mouseRay.direction);
	
		if(_intersectionPlane.Raycast(mouseRay, out distance))
		{
			IsActive = true;
			_currentCrossHairs.active = true;
			CurrentPosition = mouseRay.GetPoint(distance);
			_currentCrossHairs.transform.position = CurrentPosition;
			
		}
		else
		{
			IsActive = false;
			_currentCrossHairs.active = false;
		}

	}
}
