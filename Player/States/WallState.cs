using Godot;
using System;

public partial class WallState : PlayerLimboState
{
    float oldGravity;
    float wallJump = 100f;

    public override void _Enter()
    {
        base._Enter();
        oldGravity = player.gravity;
        _animationPlayer.Play("Wallcling");

        // Player maintains Y velocity as well as a portion of X velocity added to Y
        // TODO: Fix it, doesn't feel good atm
        player.Velocity = new Vector2(0f, player.Velocity.Y - Math.Abs(player.storedVelocityY)/4);
        player.storedVelocityY = 0f;
    }

    public override void _Exit()
    {
        base._Exit();

        // Flips player away from wall
        player.gravity = oldGravity;
        if (player.Scale.Y > 0) // Facing right
        {
            player.Velocity = new Vector2(wallJump, player.Velocity.Y);
        }
        else // Facing left
        {
            player.Velocity = new Vector2(-wallJump, player.Velocity.Y);
        }
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        // Slow player to a stop
        if (player.gravity != 0 && player.Velocity.Y > 0)
        {
            player.gravity = 0;
            player.Velocity = new Vector2(0f, 0f);
        }
    }
}
