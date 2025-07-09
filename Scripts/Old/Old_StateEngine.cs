// using Godot;
// using System;
// using System.Collections.Generic;

// public abstract partial class StateEngine : Node
// {
//     // Child classes must define their own enum for possible states.
//     public int curState;
//     public int prevState;
//     public Node parent;

//     public override void _Ready()
//     {
//         parent = GetParent();
//     }

//     public abstract void _StateLogic(double delta);
//     public abstract string _GetTransition(double delta);
//     public abstract void _EnterState(string newState, string oldState);

//     public void SetState(int stateName)
//     {
//         prevState = curState;
//         curState = stateName;
//     }

//     // public void AddState(string stateName)
//     // {
//     //     States[stateName] = States.Count;
//     // }
// }
