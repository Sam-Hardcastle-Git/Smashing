using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTriggerScript : MonoBehaviour
{
    private LevelManager levelManager;
    private Ball ball;
    private ReadyGoCongrats readyGoCongrats;
            
    // Use this for initialization
    void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<Ball>();
        readyGoCongrats = GameObject.FindObjectOfType<ReadyGoCongrats>();
    }	

    void OnTriggerEnter2D(Collider2D collider)
    {
        //life subtract
        LifeCount.Lives = LifeCount.Lives - 1;

        //set up for the tryAgain function to execute
        ReadyGoCongrats.TimeUntilStart = 1;
        ReadyGoCongrats.CanStart = false;

        //it's time to call the Try Again function
        readyGoCongrats.timeToCallTryAgain = true;

        //reset ball position
        ball.hasBeenLaunched = false;

        //no lives? Game over
        if(LifeCount.Lives <= 0)
        {
            levelManager.GameOver();
        }        
    }
}
