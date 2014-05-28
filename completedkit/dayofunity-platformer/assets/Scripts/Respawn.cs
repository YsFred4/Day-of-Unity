using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public GameObject splash;
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
			// ... reload the level.
			Application.LoadLevel(Application.loadedLevel);
		// Otherwise...
		else
		{

		

		}
	}
}