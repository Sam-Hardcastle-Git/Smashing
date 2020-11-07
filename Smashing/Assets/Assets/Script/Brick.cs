using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    #region initialize
    //ints
    public int maxHits;
    public int timesHit;

    //audio
    public AudioClip tink;
    public AudioClip shatter;

    //sprite
    public Sprite[] hitSprites;
 
    //Level Manager
    private LevelManager levelManager;

    //static int
    public static int noOfBricksLeft;

    //bool
    private bool isBreakable;

    //ball reference
    private Ball ball;

    //particle reference
    public GameObject breakParticle;

    #endregion initialize

    //Get the levelmanager object and add 1 to noOfBricksBroken if the tag of this brick is BrickTag
    void Start ()
    {
        //isBreakable is true if this tag has BrickTag attached to it
        isBreakable = (this.tag == "BrickTag");

        //if isBreakable is true, add one to noOfBricksBroken
        if (isBreakable)
        {
            noOfBricksLeft++;
        }

        //find the levelManager game object
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        //find the ball game object
        ball = GameObject.FindObjectOfType<Ball>();
    }
	   
	//Either destroy block or execute handleHits()
	void Update ()
    {       

        if (isBreakable)
        {
            handleHits();

            #region change texture

            if (timesHit == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            }

            else if (timesHit == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;


            }

            else if (timesHit == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            }

            else if (timesHit == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

            }

            else if (timesHit == 4)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            }

            #endregion change texture
        }
    }

    //add timesHit by one for each hit and play "shatter"
    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit = timesHit + 1;

        if(isBreakable)
        {
            if(ball.hasBeenLaunched)
            {
                //create a transform.position for the audio clip to play at, so it isn't attached to the object
                AudioSource.PlayClipAtPoint(tink, transform.position);
            }           
        }                        
    }

    void LoadSprites()
    {
        //only change the sprite if there exists a sprite in the array 
        //this is to stop a brick turning invisble if the sprite hasn't been filled in for whatever reason
        if (hitSprites[timesHit] != null)
        {
            //get this sprite renderer and fill it with a sprite from the array that matches the no of times the brick has been hit
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
        }
        else
            Debug.LogError("missing sprite");        
    }

    void handleHits()
    {
        if (timesHit >= maxHits)
        {
            //add to the breakableBlockCount
            noOfBricksLeft = noOfBricksLeft - 1;          

            //destroy this block
            DestroyObject(gameObject);

            //display particle effect
            Instantiate(breakParticle, transform.position, Quaternion.identity);

            //shatter
            AudioSource.PlayClipAtPoint(shatter, transform.position);

            //change scene if this is the last block to be destroyed
            levelManager.BrickDestroyed();
                                   
        }
        else
        {
            LoadSprites();
        }
    }
}
