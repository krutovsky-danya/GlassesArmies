using System;
using System.Collections.Generic;

namespace GlassesArmies
{
    public class Controller
    {
        public MainForm MainForm { get; set; }
        private readonly Stack<State> _previousState = new Stack<State>();
        private State _currentState = State.MainMenu;

        public Controller()
        {
            
        }

        public void ChangeState(State state)
        {
            if (state == State.Settings)
                _previousState.Push(_currentState);
            _currentState = state;
            switch (state)
            {
                case State.MainMenu:
                    MainForm.ShowMainMenu();
                    break;
                case State.GamePlay:
                    MainForm.ShowGamePlay();
                    break;
                case State.Settings:
                    MainForm.ShowSettings();
                    break;
                case State.Back:
                    ChangeState(_previousState.Pop());
                    break;
                case State.Exit:
                    MainForm.Close();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        
        public enum State
        {
            MainMenu,
            GamePlay,
            Settings,
            Back,
            Exit
        }
    }
}