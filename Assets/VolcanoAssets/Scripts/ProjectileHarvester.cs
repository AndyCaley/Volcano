using UnityEngine;
using System.Collections;

/// <summary>
/// Attach to Collider triggers that indicate a projectile is outside of the playing field and should be destroyed
/// </summary>
public class ProjectileHarvester: MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		GameObject otherGo=other.gameObject;
		if (otherGo.tag=="Projectile") {
			Destroy(otherGo);
		}
	}
}
