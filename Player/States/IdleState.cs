using Godot;
using System;

// Child state of GroundState

public partial class IdleState : PlayerLimboState
{
    public override void _Setup()
    {
        base._Setup();
    }

    public override void _Enter()
    {
        base._Enter();
        _animationPlayer.Play("Idle");
        // hsm = GetParent().GetParent<LimboHsm>();
        // GD.Print(hsm.GetPreviousActiveState());
    }

    public void _update(float delta)
    {
        // if (player.IsOnFloor())
        // {
        //     if (player.isJumping)
        //     {
        //         Dispatch("jump_started");
        //     }
        //     else if (!player.Velocity.IsZeroApprox())
        //     {
        //         Dispatch("move_started");
        //     }
        // }
    }

    // public override void _Input(InputEvent @event)
    // {
    //     if (@event.IsActionPressed("ui_attack"))
    //     {
    //         Dispatch("attack_started");
    //     }
    // }
}
