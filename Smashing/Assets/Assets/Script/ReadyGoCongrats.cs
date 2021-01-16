using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyGoCongrats : MonoBehaviour
{
    //Statics
    public static bool CanStart = false;
    public static float TimeUntilStart = 1;

    //bool
    public bool timeToCallTryAgain = false;  

    //Canvases
    public Canvas begin;
    public Canvas tryAgain;    
        
    // Use this for initialization
    void Start ()
    {
        CreateBeginClone();              
	}

	// Update is called once per frame
    void Update ()
    {
        //countdown
        TimeUntilStart = (TimeUntilStart - (1 * Time.deltaTime));

        //when counter hits zero
        if (TimeUntilStart <= 0)
        {
            //player can launch ball
            CanStart = true;

            //reset timer
            TimeUntilStart = 0;

            //destroy message when time is up
            Destroy(GameObject.Find("Begin!(Clone)"));
            Destroy(GameObject.Find("TryAgain(Clone)"));
        }

        //when called, set the boolean to false to stop it being called every frame
        if (timeToCallTryAgain == true)
        {
            TryAgain();

            timeToCallTryAgain = false;
        }
        
    }

    void CreateBeginClone()
    {
        Canvas beginClone;
        beginClone = Instantiate(begin, transform.position, Quaternion.identity) as Canvas;              
    }

    void TryAgain()
    {
        Canvas tryAgainClone;
        tryAgainClone = Instantiate(tryAgain, transform.position, Quaternion.identity) as Canvas;
    }
}
