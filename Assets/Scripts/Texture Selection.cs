using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSelection : MonoBehaviour
{
    public Material[] material;
    public int x;
    public static int n;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        x=n;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
         rend.sharedMaterial = material[x];
    }

    public void NextColor()
    {
        if(x<7)
        {
            x++;
        }
        else 
        {
            x=0;
        }
    }
    public void PreviousColor()
    {
        if(x>0)
        {
            x--;
        }
        else 
        {
            x=7;
        }
    }
    public void Select()
    {
        n=x;
    }
}
