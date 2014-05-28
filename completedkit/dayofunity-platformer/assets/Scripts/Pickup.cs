using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
		
	static float score = 0f;
	public GUIText guiText;

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		
		{
			Destroy (gameObject);	
			score++;
			guiText.text = "Points: " + score + "/8";
		}

	}
}