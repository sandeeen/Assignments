using UnityEngine;

class EriSan : IRandomWalker
{
	//Add your own variables here.
	//Do not use processing variables like width or height
	int moveCounter = 0;
	int frameCounter;
	int everyThirdFrame = 3;
	
	public string GetName()
	{
		return "EriSan"; //When asked, tell them our walkers name
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		//Select a starting position or use a random one.
		float x = Random.Range(0, playAreaWidth);
		float y = Random.Range(0, playAreaHeight);

		//a PVector holds floats but make sure its whole numbers that are returned!
		return new Vector2(x, y);
	}

	public Vector2 Movement()
	{
		//add your own walk behavior for your walker here.
		//Make sure to only use the outputs listed below.

		frameCounter++;
		
		if (frameCounter % everyThirdFrame == 0)
        {
			moveCounter++;
			frameCounter = 0;
			everyThirdFrame += 3;
		}


		

		switch (moveCounter)
        {
            case 0:
                return  Vector2.down;
            case 1:
                return  Vector2.left;
            case 2:
                return  Vector2.up;
			default:
                return  Vector2.right;
			

        }





    }
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!


//Random movement for walker - saved in case 
//switch (Random.Range(0, 4))
//{
//	case 0:
//		return new Vector2(-1, 0);
//	case 1:
//		return new Vector2(1, 0);
//	case 2:
//		return new Vector2(0, 1);
//	default:
//		return new Vector2(0, -1);
//}