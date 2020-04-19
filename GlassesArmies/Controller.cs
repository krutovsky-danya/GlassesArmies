using System;
using System.Collections;
using System.Collections.Generic;

namespace GlassesArmies
{
    public class Controller
    {
        public MainForm MainForm { get; set; }
        private Stack<State> priviousState = new Stack<State>();
        private State currentState = State.MainMenu;

        public Controller()
        {
            
        }

        public void ChangeState(State state)
        {
            if (state == State.Settings)
                priviousState.Push(currentState);
            currentState = state;
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
                    ChangeState(priviousState.Pop());
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