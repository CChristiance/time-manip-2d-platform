using Godot;
using System;

public partial class Target : Area2D
{
    AnimationPlayer _animationPlayer;
    Sprite2D _sprite2D;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animationPlayer.Play("Intact");
        // _animationPlayer.AnimationFinished += _OnAnimationFinished;
        _sprite2D = GetNode<Sprite2D>("Sprite2D");
    }

    public void OnHit(Vector2 knockback)
    {
        _animationPlayer.Play("Break");
    }

    // private void _OnAnimationFinished(StringName animName);
    // {
        
    // }
}
