using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {


    public float maxSpeed;

    bool grounded = false;
    float groundcheckRad = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float JumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool fRight;
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        fRight = true;
	
	}

    public GameController gameController;

    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("Grounded", grounded);
            myRB.AddForce(new Vector2(0, JumpHeight));
        }
    }
	
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRad, groundLayer);
        myAnim.SetBool("Grounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !fRight)
        {
            flip();
        }
        else if(move<0&&fRight)
        {
            flip();

        }
	}

    void flip()
    {
        fRight = !fRight;
        Vector3 tScale = transform.localScale;
        tScale.x *= -1;
        transform.localScale = tScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            this.gameController.ScoreValue += 100;
        }

        if (other.gameObject.CompareTag("laser 01"))
        {
            this.gameController.LivesValue -= 1;
        }

    }
}
