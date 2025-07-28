using Godot;
using System;

public partial class FallState : LimboState
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
        player.canJump = false;
        GD.Print("Falling");
        _animationPlayer.Play("Still Air");
    }

    public override void _Exit()
    {
        player.canJump = true;
    }

    public void _update(float delta)
    {
        if (player.IsOnFloor())
            Dispatch("land_started");
    }
}
