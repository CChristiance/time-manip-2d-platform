using Godot;
using System;

public partial class IdleState : LimboState
{
    // [Export] AnimatedSprite2D animatedSprite2D;
    private AnimationPlayer _animationPlayer;
    // [Export] string animation;
    float speed = 200f;
    Player player;

    public override void _Setup()
    {
        player = (Player)Agent;
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        // pass;
        GD.Print("Idle");
        // animatedSprite2D.Play(animation);
        _animationPlayer.Play("Idle");
    }

    public void _update(float delta)
    {
        if (player.IsOnFloor())
        {
            if (player.isJumping)
            {
                Dispatch("jump_started");
            }
            else if (!player.Velocity.IsZeroApprox())
            {
                Dispatch("move_started");
            }
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_attack"))
        {
            Dispatch("attack_started");
        }
    }
}
