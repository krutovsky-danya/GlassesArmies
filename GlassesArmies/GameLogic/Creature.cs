using System.Collections.Generic;
using System.Drawing;

namespace GlassesArmies
{
    public abstract class Creature
    {
        public Game Game;
        public Game.CreatureSide Side { get; protected set; }

        protected Vector StartLocation { get; }
        protected Bitmap StartTexture { get; }
        
        public Vector Location { get; protected set; }
        public Bitmap Texture { get; protected set; }
        
        //ai

        protected readonly LinkedList<Turn> Turns;
        protected LinkedListNode<Turn> CurrentTurn { get; set; }
        protected int CurrentRepetition { get; set; }

        protected Vector Step;
        protected Vector Velocity;
        protected Vector JumpAcceleration;

        public int MaxHealth { get; protected set; }
        protected int HealthPoints { get; set; }
        public int HealthBarWidth { get; protected set; }
        
        public bool IsAlive { get; protected set; } = true;

        protected readonly double _dt = 1d / 60;

        protected Creature(Bitmap texture, Vector location)
        {
            StartTexture = texture;
            Texture = texture;
            
            StartLocation = location.Copy;
            Location = location.Copy;
            
            Step = new Vector(5, 0);
            Turns = new LinkedList<Turn>();
            Velocity = Vector.Zero;
        }

        protected void MemorizeTurn(Turn turn)
        {
            if (Turns.Last == null)
            {
                Turns.AddLast(turn.Copy());
                return;
            }
            var currentTurn = Turns.Last.Value;
            if (turn.Type != Turn.Types.None && turn.Type != Turn.Types.MoveLeft && turn.Type != Turn.Types.MoveRight
                || currentTurn.Type != turn.Type)
            {
                Turns.AddLast(turn.Copy()); // copy to not increase counter from outside
            }
            else
            {
                currentTurn.Repetitions++;
            }
        }
        
        public Rectangle ToRectangle()
        {
            return new Rectangle(Location.ToPoint(), new Size(Texture.Width, -Texture.Height));
        }
        
        public virtual void Reborn()
        {
            IsAlive = true;
        }
        
        public virtual void Accelerate(Vector impulse)
        {
            Velocity += impulse;
        }

        public abstract void Move(Vector movement);

        public abstract void MoveLeft();

        public abstract void MoveRight();

        public virtual void MoveUp()
        {
            
        }

        public virtual void MoveDown()
        {
            
        }

        public abstract void Jump();

        public abstract void Shoot(Vector target);

        public abstract void MakeAutoTurn();

        public abstract void MakeTurn(Turn turn);

        public abstract void TakeDamage(int damage);

        public abstract Creature Copy();

        public virtual CreatureData GetData(Vector bias)
        {
            var dataLocation = Location - bias;
            dataLocation.Y *= -1;
            return new CreatureData(Texture, dataLocation.ToPoint(), HealthPoints, MaxHealth, Texture.Width);
        }
    }
    
    public class CreatureData
    {
        public Bitmap Texture;
        public Point Location;
        public int Health;
        public int MaxHeath;
        public int HealthBarWidth;

        public CreatureData(Bitmap texture, Point location, int health, int maxHeath, int healthBarWidth)
        {
            Texture = texture;
            Location = location;
            Health = health;
            MaxHeath = maxHeath;
            HealthBarWidth = healthBarWidth;
        }
    }
}