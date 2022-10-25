using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MouseExample : ProcessingLite.GP21
{
 

    
    public float diameter = 2;
    public int colorValue = 0;
    public Vector2 circleSpeed;
    public Vector2 mousePosition;
    public Vector2 circlePosition;
    public float maxSpeed;

    private void Start()
    {
        circlePosition = new Vector2(Width / 2, Height / 2);
    }


    void Update()
    {

        Background(0);
        
        Circle(circlePosition.x, circlePosition.y, diameter);

        if (Input.GetMouseButtonUp(0))
        {
            

            mousePosition = new Vector2(MouseX, MouseY);

            circleSpeed = mousePosition - circlePosition;

            circleSpeed = Vector2.ClampMagnitude(circleSpeed,maxSpeed);

            


            //circlePosition.x = MouseX;
            //circlePosition.y = MouseY;

            
        }

        circlePosition += circleSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Line(MouseX, MouseY, circlePosition.x, circlePosition.y);
        }


        if (circlePosition.x + diameter / 2 > Width)
        {
            circleSpeed = Vector2.Reflect(circleSpeed, Vector2.right);
        }


        if (circlePosition.x - diameter / 2 < 0)
        {
            circleSpeed = Vector2.Reflect(circleSpeed, Vector2.left);
        }


        if (circlePosition.y + diameter / 2 > Height)
        {
            circleSpeed = Vector2.Reflect(circleSpeed, Vector2.down);
        }


        if (circlePosition.y - diameter / 2 < 0)
        {
            circleSpeed = Vector2.Reflect(circleSpeed, Vector2.up);
        }

    }

}
