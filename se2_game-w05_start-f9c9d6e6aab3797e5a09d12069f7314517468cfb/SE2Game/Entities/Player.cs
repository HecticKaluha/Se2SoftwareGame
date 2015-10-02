using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game.Entities
{
    public class Player : Entity
    {
        public int Hitpoints
        {
            get;
            private set;
        }

        public Player(Vector position)
            : base(position)
        {
            sprite = new Sprite("sprites/sprites.png", new Point(0, 0));
            Hitpoints = 100;
        }

        public int Hit(Enemy hitBy)
        {
            int damageDealt = Math.Min(Hitpoints, hitBy.DamagePerHit);
            Hitpoints -= damageDealt;
            return damageDealt;
        }

        /// <summary>
        /// Function that determines which action the player should take.
        /// </summary>
        protected override void Move()
        {
            direction.X = 0;
            direction.Y = 0;

            if (Util.IsKeyDown(Key.Up)) direction.Y = -1;
            else if (Util.IsKeyDown(Key.Left)) direction.X = -1;
            else if (Util.IsKeyDown(Key.Down)) direction.Y = 1;
            else if (Util.IsKeyDown(Key.Right)) direction.X = 1;
        }
    }
}
