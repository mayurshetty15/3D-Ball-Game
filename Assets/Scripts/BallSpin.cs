using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    [SerializeField] float spinspeed = 4;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))  
        {  
            this.transform.Rotate(Vector3.right,spinspeed); 
            //this.transform.Rotate(Vector3.up,1);  
        }  
         
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))  
        {  
            this.transform.Rotate(Vector3.left ,-spinspeed);
            //this.transform.Rotate(Vector3.up ,-1);  
        }  
         
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))  
        {  
            this.transform.Rotate(Vector3.right ,spinspeed);
            //this.transform.Rotate(Vector3.up ,-1);    
        }  
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))  
        {  
            this.transform.Rotate(Vector3.left ,-spinspeed);
            //this.transform.Rotate(Vector3.up ,-1);   
        } 
  
    }
}