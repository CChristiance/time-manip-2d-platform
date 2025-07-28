using Godot;
using System;

public partial class LandState : LimboState
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
        player.canMove = false;
        // pass;
        GD.Print("Land");
        _animationPlayer.Play("Still Squat");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
        // animatedSprite2D.Play(animation);
        // animatedSprite2D.AnimationFinished += OnAnimatedSprite2DAnimationFinished;
    }

    public override void _Exit()
    {
        player.canMove = true;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
        // animatedSprite2D.AnimationFinished -= OnAnimatedSprite2DAnimationFinished;
    }

    public void _update(float delta)
    {
    }
    
    private void _on_animation_player_animation_finished(StringName animName)
    {
        if (!IsActive()) return;
        Dispatch("idle_started");
    }

    // public void OnAnimatedSprite2DAnimationFinished()
    // {
    //     // Exit state
    //     if (!IsActive()) return;
    //     Dispatch("idle_started");
    // }
}
