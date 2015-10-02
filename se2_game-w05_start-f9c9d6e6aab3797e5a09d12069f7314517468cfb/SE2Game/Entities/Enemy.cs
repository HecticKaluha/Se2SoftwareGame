using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Utils;
using SE2Game.Game;
using SE2Game.AI;

namespace SE2Game.Entities
{
    public class Enemy : Entity
    {
        private Random r = new Random();
        //private int counter;
        private IMoveLogic moveLogic;

        //private int stap;

        public int DamagePerHit { get { return 10; } }

        public Enemy(Vector position, IMoveLogic moveLogic)
            : base(position)
        {
            sprite = new Sprite("sprites/sprites.png", new Point(3, 0));
            this.moveLogic = moveLogic;
        }
        public Enemy(Vector position, AIMove movelogic): base(position)
        {
            sprite = new Sprite("sprites/sprites.png", new Point(3, 0));
            this.moveLogic = movelogic;
        }

        /// <summary>
        /// Function that determines which action the enemy should take.
        /// </summary>
        protected override void Move()
        {
            direction = moveLogic.MakeMove(position, World.Instance.Player.Position);
            /*
            if (counter > 40)
            {
                counter = 0;
                direction.X = 0;
                direction.Y = 0;
                stap = r.Next(0, 4);
                if (stap == 0)
                {
                    direction.Y = -1;
                }
                if (stap == 1)
                {
                    direction.X = -1;
                }
                if (stap == 2)
                {
                    direction.Y = 1;
                }
                if (stap == 3)
                {
                    direction.X = 1;
                }
            }
            counter++;*/
        }
    }
}
