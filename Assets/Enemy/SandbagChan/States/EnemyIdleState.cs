using Godot;
using System;

public partial class EnemyIdleState : LimboState
{
    private AnimationPlayer _animationPlayer;
    [Export] float speed = 200f;

    public override void _Setup()
    {
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        _animationPlayer.Play("Combat Idle");
    }
}
