using Godot;
using System;

public partial class LandState : PlayerLimboState
{
    float oldSpeed;

    public override void _Setup()
    {
        player = (Player)Agent;
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        base._Enter();
        // player.canMove = false;
        // oldSpeed = player.speed;
        // player.speed = speed;
        _animationPlayer.Play("Still Squat");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
        // animatedSprite2D.Play(animation);
        // animatedSprite2D.AnimationFinished += OnAnimatedSprite2DAnimationFinished;
    }

    public override void _Exit()
    {
        base._Exit();
        // player.speed = oldSpeed;
        // player.canMove = true;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
        // animatedSprite2D.AnimationFinished -= OnAnimatedSprite2DAnimationFinished;
    }

    public void _update(float delta)
    {
    }
    
    private void _on_animation_player_animation_finished(StringName animName)
    {
        if (!IsActive()) return;
        Dispatch("idle");
    }

    // public void OnAnimatedSprite2DAnimationFinished()
    // {
    //     // Exit state
    //     if (!IsActive()) return;
    //     Dispatch("idle_started");
    // }
}
