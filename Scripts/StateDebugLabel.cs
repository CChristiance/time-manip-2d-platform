using Godot;
using System;

public partial class StateDebugLabel : Label
{
    [Export] public LimboHsm limboHsm;

    public override void _Process(double delta)
    {
        Text = "State: " + limboHsm.GetActiveState().Name;
        // var temp = limboHsm.GetActiveState();
    }
}
