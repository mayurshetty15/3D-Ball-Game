using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public string LevelName;
    //public int LevelIndex;
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(LevelName);
        //SceneManager.LoadScene(LevelIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
