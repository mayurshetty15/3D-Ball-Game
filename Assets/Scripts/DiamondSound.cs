using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSound : MonoBehaviour
{
    //public GameObject Player;
    //private AudioSource source;
    public AudioClip dSound;
    void Start()
    {
        //source = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter()
	{
		//if(other.gameObject == Player)
        {
            AudioSource.PlayClipAtPoint(dSound, transform.position , 100.0f);  
            //source = GetComponent<AudioSource>();
            //source.Play();
        }	
	}
}
