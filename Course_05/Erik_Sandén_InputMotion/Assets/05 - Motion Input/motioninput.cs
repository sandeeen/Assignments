using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class motioninput : ProcessingLite.GP21
{
    float posY = 0;
    float posX = 0;
    float diameter = 1;
    public float v = 1;
    public float a = 1;
    public float d = 10;
    public float minV = 0;
    public float maxV = 10;
    public Vector2 lastDir;
    
    void Start()
    {
        posX = Width / 2; 
        posY = Height / 2; 
    }

    
    void Update()
    {

        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
       

        

        Background(50, 166, 240);

       
        if(move.magnitude != 0)
        {
            lastDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }

        if (move.magnitude != 0)
        {
            v += a * Time.deltaTime;
        }
        else
        {
            v -= d * Time.deltaTime;
        }

        if(v < 0)
        {
            v = minV;
        }

        if(v > maxV)
        {
            v = maxV;
        }
        
        
      

        posY += lastDir.y * v * Time.deltaTime;
        posX += lastDir.x * v * Time.deltaTime;

        Circle(posX, posY, diameter);
    }
}
