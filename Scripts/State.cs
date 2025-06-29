using Godot;
using System;
using System.Collections.Generic;

public abstract partial class State : Node
{
    public StateEngine stateEngine => GetParent<StateEngine>();
    public Player character;
    public State nextState;
    [Export] public bool canMove = true;

    public abstract void StateInput(InputEvent @event);
    public abstract void StateProcess(double delta);
    public abstract void OnEnter();
    public abstract void OnExit();
}
