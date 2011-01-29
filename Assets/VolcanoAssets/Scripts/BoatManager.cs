using UnityEngine;
using System.Collections;

public class BoatManager : MonoBehaviour {
	
	public GameObject[] SpawnLocations;
	public GameObject[] EndLocations;
	public float SpawnTime;
	public Rigidbody BoatPrefab;
	public float MinPower=300;
	public float MaxPower=1000;
	
	float _timeSinceLastSpawn = 100f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SpawnLocations.Length == 0)
			return;
		
		if(SpawnLocations.Length != EndLocations.Length)
			Debug.Log("Number of spawn locations and end locations aren't equal");
				
		if(_timeSinceLastSpawn > SpawnTime)
		{
			float power=Random.value*(MaxPower-MinPower)+MinPower;
			int spawnNum = Random.Range(0, SpawnLocations.Length);
			Debug.Log("Sending boat out from location " + spawnNum);
			
			Vector3 spawnLocation = SpawnLocations[spawnNum].transform.position;
			
			Vector3 startVector= EndLocations[spawnNum].transform.position - spawnLocation;
			startVector.y=0;
			
			Quaternion rot = Quaternion.LookRotation(startVector);
			
			Rigidbody newBoat = Instantiate(BoatPrefab, spawnLocation, rot) as Rigidbody;
			
			newBoat.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
			
			//newBoat.Target = EndLocations[spawnNum];
			
			_timeSinceLastSpawn = 0;
		}
		else
		{
			_timeSinceLastSpawn += Time.deltaTime;
		}
	}
}
