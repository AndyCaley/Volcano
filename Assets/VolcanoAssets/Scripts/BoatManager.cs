using UnityEngine;
using System.Collections;

public class BoatManager : MonoBehaviour {
	
	public GameObject[] SpawnLocations;
	public GameObject[] EndLocations;
	public float SpawnTime;
	public Movement BoatPrefab;
	
	float _timeSinceLastSpawn;
	
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

			Movement newBoat = Instantiate(BoatPrefab, spawnLocation, Quaternion.identity) as Movement;
			
			newBoat.Target = EndLocations[spawnNum];
			
			_timeSinceLastSpawn = 0;
		}
		else
		{
			_timeSinceLastSpawn += Time.deltaTime;
		}
	}
}
