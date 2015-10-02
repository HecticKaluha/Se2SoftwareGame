using System;
using System.Drawing;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.AI
{
    public class AIMove : IMoveLogic
    {
        private Vector currentDirection;
        private long lastUpdate;
        public string Name { get; set; }
        public AIMove()
        {
            currentDirection = new Vector();
            lastUpdate = World.Instance.Time;
        }
        public Vector MakeMove(Vector currentPosition, Vector targetPosition)
        {
            
            // Change direction every half second
            if (World.Instance.Time - lastUpdate > World.Instance.RandomNumber(400, 600))
            {
                //go to player - Not working
                /*
                if(currentPosition.X >= targetPosition.X)
                {
                    currentDirection = new Vector(1,0);
                }
                if(currentPosition.Y >= targetPosition.Y)
                {
                    currentDirection = new Vector(0,1);
                }
                if(currentPosition.X <= targetPosition.X)
                {
                    currentDirection = new Vector(-1,0);
                }
                if(currentPosition.Y <= targetPosition.Y)
                {
                    currentDirection = new Vector(0,-1);
                }
                else
                {
                    currentDirection = new Vector(1,0);
                }*/

                switch (World.Instance.RandomNumber(4))
                {
                    case 0: currentDirection = new Vector(targetPosition.X-currentPosition.X, 0); break;
                    case 1: currentDirection = new Vector(0, currentPosition.Y-targetPosition.Y); break;
                    case 2: currentDirection = new Vector(-(targetPosition.X-currentPosition.X), 0); break;
                    case 3: currentDirection = new Vector(0, -(currentPosition.Y-targetPosition.Y)); break;
                    default: currentDirection = new Vector(0, 0); break;
                }

                lastUpdate = World.Instance.Time;
            }

            return currentDirection;
        }
    }
}
