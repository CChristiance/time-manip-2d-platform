using Godot;
using System;

public partial class GBlockState : PlayerLimboState
{
    float friction;
    double timer;

    public override void _Enter()
    {
        base._Enter();
        friction = 1f;
        timer = 0f;
        _animationPlayer.Play("Block");
    }

    public override void _Exit()
    {
        _animationPlayer.Play("RESET");
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        timer += delta;
        float velocity = player.Velocity.X;
        friction = _easeOutCubic(timer);
        velocity *= friction;
        player.Velocity = new Vector2(velocity, player.Velocity.Y);

        if (!Input.IsActionPressed("block"))
        {
            Dispatch("to_ground");
        }
    }

    private float _easeOutCubic(double x)
    {
        return (float)Math.Pow(1 - x, 3);
    }
}
