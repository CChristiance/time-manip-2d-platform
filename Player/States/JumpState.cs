using Godot;
using System;

public partial class JumpState : LimboState
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
        speed = player.speed;
        GD.Print("Jump");
        _animationPlayer.Play("Still Squat");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        // player.speed = speed;
        player.isJumping = false;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
    }

    public void _update(float delta)
    {
        if (player.IsOnFloor() && !player.isJumping)
        {
            Dispatch("land_started");
        }
        else if (player.Velocity.Y > 0)
        {
            Dispatch("fall_started");
        }
    }

    public void _on_animation_player_animation_finished(StringName animName)
    {
        if (!player.isJumping) return;
        player.isJumping = false;
        player.Velocity = new Vector2(player.Velocity.X, player.jumpHeight);
        _animationPlayer.Play("Still Air");
    }

    // public void OnAnimatedSprite2DAnimationFinished()
    // {
    //     if (!player.isJumping) return;
    //     player.isJumping = false;
    //     player.Velocity = new Vector2(player.Velocity.X, player.jumpHeight);
    //     animatedSprite2D.Play(animation2);
    // }
}
