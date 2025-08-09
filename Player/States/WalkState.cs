using Godot;
using System;

// Child state of IdleState

public partial class WalkState : PlayerLimboState
{
    public override void _Enter()
    {
        base._Enter();
        _animationPlayer.Play("Walk");
    }
}
