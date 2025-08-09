using Godot;
using System;

public abstract partial class PlayerLimboState : LimboState
{
    protected AnimationPlayer _animationPlayer;
    [Export] protected float speed = 200f;
    float oldSpeed;
    protected Player player;

    public override void _Setup()
    {
        player = (Player)Agent;
        _animationPlayer = player?.GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _Enter()
    {
        // oldSpeed = player.speed;
        // player.speed = speed;
    }

    public override void _Exit()
    {
        // player.speed = oldSpeed;
    }
}
