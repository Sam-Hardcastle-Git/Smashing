using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //the x position of the mouse
    float mousePosXInWorldUnits;

    //the position of the paddle in its starting point
    Vector3 paddlePos = new Vector3(0.5f, 0f, 2.5f);

    //ball
    private Ball ball;

    //bool for autoplay
    public bool autoPlay = false;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }  

	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            if(ReadyGoCongrats.canStart)
            {
                MoveWithMouse();
            }            
        }
        else
        {
            AutoPlay();
        }
    }

    //use this function to make the paddle follow the mouse x postition
    void MoveWithMouse()
    {
        //Dividing by the width of the screen (Screen.Width is the width of the screen in pixels) gives a value between zero and one 
        //(multiple by 16 because the gamespace is 16 units wide)
        mousePosXInWorldUnits = (Input.mousePosition.x / Screen.width * 16f);

        //"this" represents the instance of the current script. If "this" were destroyed, the paddle script is what would be destoyed
        this.transform.position = paddlePos;

        //set paddle to mouse position, clamping between two values to stop it moving off the screen
        paddlePos = new Vector3(Mathf.Clamp(mousePosXInWorldUnits, 1f, 15f), 0.5f, 2.5f);
    }

    //use this function to autotest
    void AutoPlay()
    {
        //Dividing by the width of the screen (Screen.Width is the width of the screen in pixels) gives a value between zero and one 
        //(multiple by 16 because the gamespace is 16 units wide)
        float ballPos = ball.transform.position.x;

        //"this" represents the instance of the current script. If "this" were destroyed, the paddle script is what would be destoyed
        this.transform.position = paddlePos;

        //set paddle to mouse position, clamping between two values to stop it moving off the screen
        paddlePos = new Vector3(Mathf.Clamp(ballPos, 1f, 15f), 0.5f, 2.5f);
    }
}
