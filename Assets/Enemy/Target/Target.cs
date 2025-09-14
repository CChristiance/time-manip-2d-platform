using Godot;
using System;

public partial class Target : EnemyGeneric
{
    private AnimationPlayer _animationPlayer;
    public override void _Ready()
    {
        gravity = 0f;
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animationPlayer.Play("Intact");
        base._Ready();
    }

    public override void OnHit(int damage, int stagger, Vector2 knockback)
    {
        _animationPlayer.Play("Break");
    }

    public override void _PhysicsProcess(double delta)
    {
        return;
    }

    public override void _InitStateMachine()
    {
        // throw new NotImplementedException();
    }
}
