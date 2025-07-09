using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class StateEngine : Node
{
    [Export] Player character;
    public State currentState;

    public List<State> states;

    public override void _Ready()
    {
        states = new List<State>();
        foreach (Node child in GetChildren())
        {
            if (child is State state)
            {
                states.Add(state);
                state.character = character;
            }
        }
        if (currentState == null && states.Count > 0)
        {
            SwitchStates(states[0]);
        }
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

    public void SwitchStates(State nextState)
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
