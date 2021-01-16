using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        //reset Lives
        LifeCount.Lives = 3;        
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GameOver()
    {
        //reset brick number
        Brick.NoOfBricksLeft = 0;

        //reset canStart and timeUntilStart
        ReadyGoCongrats.CanStart = false;
        ReadyGoCongrats.TimeUntilStart = 1;       
        
        //Load lose screen       
        SceneManager.LoadScene("Lose");
    }

    public void LoadNextLevel()
    {
        //reset canStart and timeUntilStart
        ReadyGoCongrats.CanStart = false;
        ReadyGoCongrats.TimeUntilStart = 1;

        //return the index of the scenes build index plus 1 (the next scene in the index)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if(Brick.NoOfBricksLeft <= 0)
        {
            LoadNextLevel();            
        }
    }
       
}
