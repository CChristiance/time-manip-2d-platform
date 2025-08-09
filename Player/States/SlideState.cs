using Godot;
using System;

public partial class SlideState : PlayerLimboState
{
    public override void _Enter()
    {
        base._Enter();
        _animationPlayer.Play("Slide");
        float newVelocity = player.Velocity.X >= 0 ? player.Velocity.X + player.storedVelocity : player.Velocity.X - player.storedVelocity;
        player.Velocity = new Vector2(newVelocity, player.Velocity.Y);
    }

    public override void _Exit()
    {
        base._Exit();
        player.storedVelocity = 0f;
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        if (!Input.IsActionPressed("slide"))
        {
            Dispatch("to_ground");
        }
    }
}
