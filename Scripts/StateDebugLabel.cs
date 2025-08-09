using Godot;
using System;

public partial class StateDebugLabel : Label
{
    [Export] public LimboHsm limboHsm;

    public override void _Process(double delta)
    {
        Text = "State: " + limboHsm.GetLeafState().Name;
        // var temp = limboHsm.GetActiveState();
    }
}
