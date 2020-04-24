using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Turn
    {
        public readonly TurnType Type;
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

        public Turn(TurnType type, Action<Creature> action)
        {
            Type = type;
            Action = action;
        }

        public enum TurnType
        {
            None,
            MoveLeft,
            MoveRight,
            Jump,
            Shoot,
            Move
            //special
        }
        
        public static Turn None => new Turn(TurnType.None, creature => creature.Move(Vector.Zero));
        public static Turn MoveLeft => new Turn(TurnType.MoveLeft, creature => creature.MoveLeft());
        public static Turn MoveRight => new Turn(TurnType.MoveRight, creature => creature.MoveRight());
        public static Turn Jump => new Turn(TurnType.Jump, creature => creature.Jump());

        public static Turn Shoot(Point target)
        {
            return new Turn(TurnType.Shoot, creature => creature.Shoot(target.X, target.Y));
        }

        public static Turn Move(Vector movement)
        {
            return new Turn(TurnType.Move, creature => Move(movement));
        }
    }
}