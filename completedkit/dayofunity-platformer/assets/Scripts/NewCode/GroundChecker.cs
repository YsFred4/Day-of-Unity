using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    public float checkRadius = .65f;
    private bool grounded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
        Vector2 posV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        this.grounded = Physics2D.OverlapCircle(posV2, this.checkRadius, 1 << this.gameObject.layer);

	}

    public bool IsGrounded()
    {
        return this.grounded;
    }
}
