using Godot;
using System;

public partial class StateDebugLabel : Label
{
    LimboHsm limboHsm;

    public override void _Ready()
    {
        limboHsm = GetNode<LimboHsm>("../LimboHSM");
    }

    public override void _Process(double delta)
    {
        Text = "State: " + limboHsm.GetActiveState().Name;
        // var temp = limboHsm.GetActiveState();
    }
}
