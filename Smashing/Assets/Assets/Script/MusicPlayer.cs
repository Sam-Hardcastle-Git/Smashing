using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //a static of type MusicPlayer called "instance". 
    //Because it's static, this variable only belongs to this class and not any class instances
    static MusicPlayer Instance = null; 

    // Use this for initialization
    void Start ()
    {

        #region destroy the music player gameObject if there's already an instance of the MusicPlayer class
        //if any music player instance exists
        if (Instance != null)
        {
            //destroy self
            Destroy(gameObject);
        }
        #endregion destroy the music player gameObject if there's already an instance of the MusicPlayer class

        #region if there is no MusicPlay instance, make this one the "instance"
        //however if there is no music player instance
        else
        {
            //make this particular instance of the music player class the "instance" 
            Instance = this;

            //"gameObject" refers to the gameObject that this component is attached to.
            //"Don't Destroy On Load keeps the instance of the gameObject there when a new scene is loaded, along with its components
            GameObject.DontDestroyOnLoad(gameObject);        
        }
        #endregion if there is no MusicPlay instance, make this one the "instance"
    }
}
