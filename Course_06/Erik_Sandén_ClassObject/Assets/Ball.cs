using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite, so we get access to all functions
class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 position; //Ball position
    public Vector2 velocity; //Ball direction
    public float diameter = Random.Range(1, 3); //Ball Size

    // Random colors 
    int r = Random.Range(0, 255);
    int g = Random.Range(0, 255);
    int b = Random.Range(0, 255);

    int r2 = Random.Range(0, 255);
    int g2 = Random.Range(0, 255);
    int b2 = Random.Range(0, 255);



    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(y, x);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(1, 11) - 5;
        velocity.y = Random.Range(1, 11) - 5;

    }

    //Draw our ball
    public void Draw()
    {
        
        //Position of the ball
        Circle(position.x, position.y, diameter);

        Fill(r, g, b);

        //Give the balls a random color
        Stroke(r2, g2, b2);

    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        if (position.x + diameter / 2 > Width)
        {
            velocity = Vector2.Reflect(velocity, Vector2.right);
        }

        if (position.x - diameter / 2 < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.left);
        }

        if (position.y + diameter / 2 > Height)
        {
            velocity = Vector2.Reflect(velocity, Vector2.down);
        }

        if (position.y - diameter / 2 < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.up);
        }



        //Background color for later
        
    }



}
