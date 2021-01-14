using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Reference to the rigidbody of the object
    private Rigidbody2D rb;     
      
    //A variable of type Paddle. In the start function, this variable will have the paddle gameObject passed into it
    private Paddle paddle;

    //The vector3 that represents the distance between the ball and the paddle
    public Vector3 paddleToBallVector;

    //bool to check if the ball has been launched
    public bool hasBeenLaunched = false;

	// Use this for initialization
    void Start ()
    {
        //find paddle
        paddle = GameObject.FindObjectOfType<Paddle>();

        //Find the distance between ball and paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;              
    }
	
	// Update is called once per frame
	void Update ()
    {
        //when clicking, if the begin/try again message is done and if the ball has launched, change hasBeenLaunched to true
        #region hasBeenLaunched turns true
        if (Input.GetMouseButtonDown(0))
        {
            if(ReadyGoCongrats.canStart)
            {
                if (hasBeenLaunched == false)
                {
                    hasBeenLaunched = true;
                    ballLaunch();
                }                                    
            }            
        }
        #endregion hasBeenLaunched turns true

        //if hasBeenLaunched is false, stick ball to paddle
        #region hasBeenLaunched is false
        if (hasBeenLaunched == false)
        {
            //There is a bug in Unity where the collider will fall and touch the Lose Collider even though it seems to stay on the paddle
            //To fix this, disable the rigidbody2d physics simulation when the ball sits on the paddle and re-activate it when it launches
            this.rb = this.gameObject.GetComponent<Rigidbody2D>();

            this.rb.gravityScale = 0;

            //Launch ball
            ballOnPaddle();
        }
       #endregion hasBeenLaunched is false

        //if hasBeenLaunched is true, launch ball, rigidbody simulated becomes true
        #region hasBeenLaunched is true
        if (hasBeenLaunched == true)
        {            
            this.rb.gravityScale = 1;
        }
        #endregion hasBeenLaunched is true        
    }

    void ballOnPaddle()
    {
        //Set the transform of the ball to the paddle plus the difference between the ball and paddle 
        //So, if you position the ball on top of the paddle, it'll stay there as you move the paddle in-game
        this.transform.position = paddle.transform.position + paddleToBallVector;
    }

    void ballLaunch()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 6f);
    }

    public void Shatter()
    {         
        GetComponent<AudioSource>().Play();                              
    }

    //Randomise bounce direction and spin ball with paddle
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + tweak;

        #region when ball hits paddle
        if (collision.transform.tag == "Paddle")
        {
            if (Input.GetAxis("Mouse X") < -0.4)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 6f);
            }

            else if

            (Input.GetAxis("Mouse X") > 0.4)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 6f);
            }        
        }
        #endregion when ball hits paddle
    }
}
