using Godot;
using System;

public partial class StateDebugLabel : Label
{
    StateEngine stateEngine;

    public override void _Ready()
    {
        stateEngine = GetParent().GetNode<StateEngine>("StateEngine");
    }

    public override void _Process(double delta)
    {
        Text = "State: " + stateEngine.currentState.Name;
    }
}
