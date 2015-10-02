using System;
using System.Collections.Generic;
using System.Drawing;
using SE2Game.Sprites;
using SE2Game.Game;
using SE2Game.Utils;
using SE2Game.AI;

namespace SE2Game.Entities
{
    public abstract class Entity : IComparable<Entity>
    {
        protected Sprite sprite;
        protected Vector position = new Vector();
        protected Vector direction = new Vector();
        protected int maxSpeed = 100;

        /// <summary>
        /// The current position (center) of the sprite in the world.
        /// </summary>
        public Vector Position { get { return position; } }

        /// <summary>
        /// Gives the bounding box for the enemy. Not very smart, but it is
        /// sufficient for what is needed right now.
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                int hss = Sprite.Size / 2;
                int trim = 1; // Make the bounding box fit a little better
                return new Rectangle(Convert.ToInt32(Position.X) - hss + trim,
                                     Convert.ToInt32(Position.Y) - hss + trim,
                                     Sprite.Size - trim, Sprite.Size - trim);
            }
        }

        public Entity(Vector position)
        {
            this.position = position;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(sprite.Image, (Position - Sprite.Size / 2).ToPointF());
        }

        /// <summary>
        /// Function that determines which action the entity should take.
        /// </summary>
        protected abstract void Move();

        /// <summary>
        /// Updates the position of the entity.
        /// </summary>
        /// <param name="deltaTime">The number of seconds elapsed since the previous call.</param>
        public void Update(float dt)
        {
            // Let the derived classes update the direction
            foreach(Entity e in World.Instance.Entities)
            {
                e.Move();
            }

            

            // Update the sprite state to reflect that we are moving or not
            if (direction.X != 0 || direction.Y != 0)
            {
                sprite.ChangeState(Sprite.State.Moving);
            }
            else
            {
                sprite.ChangeState(Sprite.State.Idle);
            }

            if (sprite.SpriteState == Sprite.State.Moving)
            {
                Direction spriteDirection = Util.DetermineDirection(direction);
                Vector newPosition = new Vector(position);
                switch (spriteDirection)
                {
                    case Direction.Left: newPosition.X -= maxSpeed * dt; break;
                    case Direction.Right: newPosition.X += maxSpeed * dt; break;
                    case Direction.Up: newPosition.Y -= maxSpeed * dt; break;
                    case Direction.Down: newPosition.Y += maxSpeed * dt; break;
                }

                int hss = Sprite.Size / 2;
                newPosition.X = Math.Max(hss, Math.Min(World.Instance.Size.Width - hss, newPosition.X));
                newPosition.Y = Math.Max(hss, Math.Min(World.Instance.Size.Height - hss, newPosition.Y));

                Vector feetPosition = (newPosition + new Vector(0, Sprite.Size / 2.2));
                if (World.Instance.Map.Reachable(feetPosition))
                {
                    position = newPosition;
                }

                sprite.UpdateImage(spriteDirection);
            }
        }
        public int CompareTo(Entity other)
        {
            return position.Y.CompareTo(other.position.Y);
        }
    }
}
