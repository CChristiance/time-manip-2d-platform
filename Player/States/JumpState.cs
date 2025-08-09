using Godot;
using System;

public partial class JumpState : PlayerLimboState
{
    bool isJumping = true;
    [Export] float jumpDecel = 2000f;
    float oldGravity;

    public override void _Enter()
    {
        oldGravity = player.gravity;
        speed = player.speed;
        // _animationPlayer.Play("Still Squat");
        _animationPlayer.Play("Still Air");
        player.Velocity = new Vector2(player.Velocity.X, player.jumpHeight);
        // _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        player.gravity = oldGravity;
        isJumping = true;
        // player.speed = speed;
        // player.isJumping = false;
        // _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
    }

    public void _update(float delta)
    {
        if (player.Velocity.Y > 0)
        {
            Dispatch("fall");
        }
        else if (!Input.IsActionPressed("jump"))
        {
            player.gravity = jumpDecel;
            // player.Velocity = new Vector2(player.Velocity.X, player.Velocity.Y + jumpDecel);
        }
    }

    // private void _on_animation_player_animation_finished(StringName animName)
    // {
    //     if (!IsActive()) return;
    //     // player.isJumping = false;
    //     player.Velocity = new Vector2(player.Velocity.X, player.jumpHeight);
    //     _animationPlayer.Play("Still Air");
    // }

    // public void OnAnimatedSprite2DAnimationFinished()
    // {
    //     if (!player.isJumping) return;
    //     player.isJumping = false;
    //     player.Velocity = new Vector2(player.Velocity.X, player.jumpHeight);
    //     animatedSprite2D.Play(animation2);
    // }
}
