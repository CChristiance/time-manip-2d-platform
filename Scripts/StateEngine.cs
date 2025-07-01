using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract partial class StateEngine<T> : Node where T : CharacterBody2D
{
    // [Export] CharacterBody2D character;
    public T Character { get; private set; }
    public void Initialize(T character)
    {
        Character = character;
    }

    public State<T> currentState;
    public List<State<T>> states;

    public void InitializeStates()
    {
        states = new List<State<T>>();
        foreach (Node child in GetChildren())
        {
            if (child is State<T> state)
            {
                states.Add(state);
                state.Initialize(Character, this);
            }
        }
        if (currentState == null && states.Count > 0)
        {
            SwitchStates(states[0]);
        }
    }

    public override void _Ready()
    {
        // Do nothing here; initialization is now manual from Player.cs
    }

    // Use state's input function
    public override void _Input(InputEvent @event)
    {
        currentState.StateInput(@event);
    }

    // Use state's physics function
    public override void _PhysicsProcess(double delta)
    {
        if (currentState.nextState != null)
        {
            SwitchStates(currentState.nextState);
        }
        currentState.StateProcess(delta);
    }

    public void SwitchStates(State<T> nextState)
    {
        // State exits with its exit effect before switching
        if (currentState != null)
        {
            currentState.OnExit();
            currentState.nextState = null;
        }

        currentState = nextState;
        currentState.OnEnter();
    }

    public bool CheckIfCanMove()
    {
        return currentState.canMove;
    }
}
