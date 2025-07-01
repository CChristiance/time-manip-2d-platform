using Godot;
using System;

public partial class StateDebugLabel<T> : Label where T : CharacterBody2D
{
    StateEngine<T> stateEngine;

    public override void _Ready()
    {
        stateEngine = GetParent().GetNode<StateEngine<T>>("StateEngine");
    }

    public override void _Process(double delta)
    {
        Text = "State: " + stateEngine.currentState.Name;
    }
}
