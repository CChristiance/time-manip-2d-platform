using Godot;
using System;

public partial class SlideState : PlayerLimboState
{
    [Export] float slideFriction;

    public override void _Enter()
    {
        base._Enter();

        // Add Y velocity to x velocity, flip sprite if necessary
        float newVelocity = 0f;
        if (player.Velocity.X > 0) // Moving Right
        {
            newVelocity = player.Velocity.X + player.storedVelocityX/4;
        }
        else if (player.Velocity.X < 0) // Moving left
        {
            newVelocity = player.Velocity.X - player.storedVelocityX/4;
        }
        else
        {
            Dispatch("to_ground");
        }

        _animationPlayer.Play("Slide");
        player.Velocity = new Vector2(newVelocity, player.Velocity.Y);
    }

    public override void _Exit()
    {
        base._Exit();
        player.storedVelocityX = 0f;
        // TODO: Only exit if there's room for the player to stand
        _animationPlayer.Play("RESET");
        _animationPlayer.Advance(0);
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
