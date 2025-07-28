using Godot;
using System;

public partial class MoveState : LimboState
{
    private AnimationPlayer _animationPlayer;
    [Export] float speed = 200f;
    Player player;

    public override void _Setup()
    {
        player = (Player)Agent;
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        GD.Print("Move");
        _animationPlayer.Play("Walk");
    }

    public void _update(float delta)
    {
        if (!player.IsOnFloor())
        {
            Dispatch("fall_started");
        }
        else if (player.isJumping)
        {
            Dispatch("jump_started");
        }
        else if (player.Velocity.IsZeroApprox())
        {
            Dispatch("idle_started");
        }
    }
}
