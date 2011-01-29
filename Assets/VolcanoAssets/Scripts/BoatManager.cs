using UnityEngine;
using System.Collections;

public class BoatManager : MonoBehaviour {
	
	public GameObject[] SpawnLocations;
	public GameObject[] EndLocations;
	public float SpawnTime;
	public Rigidbody BoatPrefab;
	
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
			int spawnNum = Random.Range(0, SpawnLocations.Length);
			Vector3 spawnLocation = SpawnLocations[spawnNum].transform.position;

			Quaternion rot = Quaternion.LookRotation(EndLocations[spawnNum].transform.position - spawnLocation);
			
			Rigidbody newBoat = Instantiate(BoatPrefab, spawnLocation, rot) as Rigidbody;
			
			newBoat.AddRelativeForce(Vector3.forward * 500f, ForceMode.Impulse);
			
			//newBoat.Target = EndLocations[spawnNum];
			
			_timeSinceLastSpawn = 0;
		}
		else
		{
			_timeSinceLastSpawn += Time.deltaTime;
		}
	}
}
