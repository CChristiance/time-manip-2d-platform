using Godot;
using System;

public partial class MoveState : LimboState
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
        GD.Print("Move");
        animatedSprite2D.Play(animation);
    }

    public void _update(float delta)
    {
        if (((Player)Agent).Velocity.IsZeroApprox())
            GetRoot().Dispatch(EVENTFINISHED);
    }
}
