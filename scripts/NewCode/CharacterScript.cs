using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

    public float MaxSpeed = 10.0f;

    public float JumpForce = 1200.0f;

    //is facing right  
    private bool isFacingRight = true;

    //groundCheckObject
    private GroundChecker groundCheckScript;

    //cached version of our rigidbody
    private Rigidbody2D cachedBody = null;

    //cached version of the animator
    private Animator cachedAnimator = null;

    //first initialization phase
    private void Awake()
    {
        this.cachedBody = this.GetComponent<Rigidbody2D>();
        this.cachedAnimator = this.GetComponent<Animator>();
    }

	// 2nd initialization phase
	private void Start () 
    {
        this.groundCheckScript = GameObject.Find("Player/GroundCheck").GetComponent<GroundChecker>();
	}
	
	// Update is called once per frame
	private void Update () 
    {
        bool grounded = this.groundCheckScript.IsGrounded();
        this.cachedAnimator.SetBool("Ground", grounded);
        if (Input.GetButtonDown("Jump")
            && grounded)
        {
            this.cachedBody.AddForce(new Vector2(0, this.JumpForce));
        }
	}

    //Fixed update is used to keep in sync with physics
    private void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float zSpeed = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(xSpeed * this.MaxSpeed, this.cachedBody.velocity.y);

        this.cachedBody.velocity = newVelocity;
        this.cachedAnimator.SetFloat("Speed", Mathf.Abs(newVelocity.x));
        this.cachedAnimator.SetFloat("vSpeed", this.cachedBody.velocity.y);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + zSpeed * .5f);


        if(newVelocity.x > 0
            && !this.isFacingRight)
        {
            this.FlipFacing();
        }else if(newVelocity.x < 0
            && this.isFacingRight)
        {
            this.FlipFacing();
        }
    }

    private void FlipFacing()
    {
        this.isFacingRight = !this.isFacingRight;
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
    }
}
