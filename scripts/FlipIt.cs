using UnityEngine;

public class FlipIt : MonoBehaviour
{
	public void flipIt()
	{
		transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
	}
}
