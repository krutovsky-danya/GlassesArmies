using System;
using System.Collections.Generic;
using System.Drawing;

namespace GlassesArmies
{
    public abstract class Creature
    {
        protected readonly double _dt = 1d / 60;
        
        //private int _healthPoints;

        public Game _Game;
        //projectiles set to place bullets
        //walls to not collide
        //ai
        private LinkedList<Turn> _turns;
        public Vector Location { get; protected set; }

        private Vector _step;
        //public Creature Copy() => new Creature(texture, Location.Copy);
        public Vector Velocity;
        protected Vector JumpAcceleration;
        
        //hit(horizontal/vertical) => Velocity.z = 0


        public Bitmap texture;

        public Creature(Bitmap texture, Vector location)
        {
            this.texture = texture;
            Location = location;
            _step = new Vector(5, 0);
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
        
        public virtual void MoveLeft()
        {
            Move(-_step);
            //MemorizeTurn(Turn.MoveLeft);
        }

        public virtual void MoveRight()
        {
            Move(_step);
            //MemorizeTurn(Turn.MoveRight);
        }

        public virtual void Jump()
        {
            //if not in flight
            Velocity += JumpAcceleration;
        }

        public abstract void Shoot(Vector target);

        public abstract void MakeAutoTurn();

        private void MemorizeTurn(Turn turn)
        {
            var currentTurn = _turns.Last.Value;
            if (turn.Type != Turn.Types.None && turn.Type != Turn.Types.MoveLeft && turn.Type != Turn.Types.MoveRight
                || currentTurn.Type != turn.Type)
            {
                _turns.AddLast(turn); // copy to not increase counter outside
            }
            else
            {
                currentTurn.Repetitions++;
            }
        }

        public abstract void MakeTurn(Turn turn);

        private void ValidateMove()
        {
            
        }

        public void Accelerate(Vector impulse)
        {
            Velocity += impulse;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Location, _step).GetHashCode();
        }
    }
}