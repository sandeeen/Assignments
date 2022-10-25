using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDemo : ProcessingLite.GP21
{
    Player player;
    Ball[] balls;
   
    //Number of total balls (excluding the player)
    int numberOfBalls = 10;

    // Start is called before the first frame update
    void Start()
    {     
        balls = new Ball[numberOfBalls];
        player = new Player();
        //Creates as many balls as places in the array
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(5, 5);
        }
        player.Start();
    }

    // Update is called once per frame
    void Update()
    {
         Background(255, 153, 204);   


        //Tell each ball to update it's position and draw them
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();

            if (CircleCollision(balls[i], player))
            {
                Debug.Log("You Died");            //player has collided with a ball
            }
        }
        player.Update();
    }







    
    //Check collision, 2 circles
    //x1, y1 is the position of the first circle
    //size1 is the radius of the first circle
    //then the same data for circle number two

    //function will return true (collision) or false (no collision)
    //bool is the return type

    bool CircleCollision(Ball ball, Player player)
    {
        float maxDistance = ball.diameter/2 + player.diameter/2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(ball.position.x - player.posX) > maxDistance || Mathf.Abs(ball.position.y - player.posY) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(ball.position, new Vector2(player.posX, player.posY)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
    //A better way to do this is to have a circle object and pass the objects in to the function,
    //then we just have to pass 2 objects instead of 6 different values.

}
