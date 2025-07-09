using Godot;
using System;

public partial class IdleState : LimboState
{
    [Export] AnimatedSprite2D animatedSprite2D;
    [Export] string animation;
    float speed = 200f;

    public override void _Setup()
    {
    }

    public override void _Enter()
    {
        // pass;
        GD.Print("Idle");
        animatedSprite2D.Play(animation);
    }

    public void _update(float delta)
    {
        if (!((Player)Agent).Velocity.IsZeroApprox())
            GetRoot().Dispatch(EVENTFINISHED);
    }
}
