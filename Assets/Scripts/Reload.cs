using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{ 
//public GameObject Player;
  
    private void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Player")
        {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
     
}

    
