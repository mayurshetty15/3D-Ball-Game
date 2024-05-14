using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public string LevelName;
    //public int LevelIndex;
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (playerInventory.NumberOfDiamonds==10)
        {
            if(other.gameObject.tag == "Player")
            { 
                SceneManager.LoadScene(LevelName); 
                //SceneManager.LoadScene(LevelIndex);
            }  
        }
    }
}