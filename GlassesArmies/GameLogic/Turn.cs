using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Turn
    {
        public readonly Types Type;
        public readonly Action<Creature> Action;
        private int _repetition = 1;

        public int Repetitions {
            get => _repetition;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _repetition = value;
            }
        }

        public Turn(Types type, Action<Creature> action)
        {
            Type = type;
            Action = action;
        }

        public enum Types
        {
            None,
            MoveLeft,
            MoveRight,
            Jump,
            Shoot,
            Move
            //special
        }
        
        public static Turn None => new Turn(Types.None, creature => creature.Move(Vector.Zero));
        public static Turn MoveLeft => new Turn(Types.MoveLeft, creature => creature.MoveLeft());
        public static Turn MoveRight => new Turn(Types.MoveRight, creature => creature.MoveRight());
        public static Turn Jump => new Turn(Types.Jump, creature => creature.Jump());

        public static Turn Shoot(Vector target)
        {
            return new Turn(Types.Shoot, creature => creature.Shoot(target));
        }

        public static Turn Move(Vector movement)
        {
            return new Turn(Types.Move, creature => Move(movement));
        }
        
        //copy
    }
}