using System;
using System.Collections.Generic;
using System.Drawing;

namespace GlassesArmies
{
    public class Creature
    {
        private int healsPoints;

        public HashSet<Projectile> Projectiles { get; set; }
        //projectiles set to place bullets
        //walls to not collide
        //ai
        private LinkedList<Turn> _turns;
        public Vector Location { get; protected set; }

        private Vector step;
        public Creature Copy() => new Creature(_texture, Location.Copy);
        public Vector Velocity;
        protected Vector JumpAcceleration;
        
        //hit(horizontal/vertical) => Velocity.z = 0


        public Bitmap _texture;

        public Creature(Bitmap texture, Vector location)
        {
            _texture = texture;
            Location = location;
            step = new Vector(5, 0);
            _turns = new LinkedList<Turn>();
            Velocity = Vector.Zero;
            
        }

        public virtual void Move(Vector movement)
        {
            //check for collisions
            //maybe some acceleration
            Location += movement;
            //_turns.AddLast(Turn.Move(movement));
        }
        
        public void MoveLeft()
        {
            Move(-step);
            MemorizeTurn(Turn.TurnType.MoveLeft);
        }

        public void MoveRight()
        {
            Move(step);
            MemorizeTurn(Turn.TurnType.MoveRight);
        }

        public virtual void Jump()
        {
            //if not in flight
            Velocity += JumpAcceleration;
            Move(Vector.Zero);
        }

        public virtual void Shoot(int x, int y)
        {
            //_turns.AddLast(new Turn(Turn.TurnType.Shoot, creature => creature.Shoot(x, y)));
            //accelerate back
        }

        public virtual void Shoot(Vector target)
        {
            
        }

        public virtual void MakeAutoTurn()
        {
            
        }

        private void MemorizeTurn(Turn.TurnType type)
        {
            
        }

        private void ValidateMove()
        {
            
        }

        public void Accelerate(Vector impulse)
        {
            Velocity += impulse;
        }
    }
}