using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{

    public float posY = 0;
    public float posX = 0;
    public float diameter = 1;
    public float v = 5;
    public Vector2 move;

    public void Start()
    {
        posX = Width / 2;
        posY = Height / 2;
    }

    
    public void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        posX += move.x * v * Time.deltaTime;
        posY += move.y * v * Time.deltaTime;
        

        Fill(0);
        Stroke(255, 255, 255);
        Circle(posX, posY, diameter);
        
    }
}
