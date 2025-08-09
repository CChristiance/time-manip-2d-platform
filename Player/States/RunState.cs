using Godot;
using System;

// Child state of IdleState

public partial class RunState : PlayerLimboState
{
    public override void _Enter()
    {
        base._Enter();
        _animationPlayer.Play("Run");
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        if (Input.IsActionPressed("slide"))
        {
            Dispatch("slide");
        }
    }
}
