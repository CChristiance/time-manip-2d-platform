using Godot;
using System;

public partial class AirHsm : LimboHsm
{
    Player player;
    [Export] float drift = 20f;

    public override void _Setup()
    {
        base._Setup();
        player = (Player)Agent;
    }

    public override void _Enter()
    {
        base._Enter();
        // Flip based on what input is held during call
        float horizontalInput = Input.GetActionStrength("right") - Input.GetActionStrength("left");

        if (horizontalInput < 0)
        {
            player.Scale = new Vector2(1, -1);
            player.RotationDegrees = 180;
        }
        else if (horizontalInput > 0)
        {
            player.Scale = new Vector2(1, 1);
            player.RotationDegrees = 0;
        }
    }

    public void _update(float delta)
    {
        // Handle aerial movement
        float horizontalInput = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        float newVelocity = player.Velocity.X;
        switch (horizontalInput)
        {
            case < 0:
                newVelocity -= drift;
                break;
            case > 0:
                newVelocity += drift;
                break;
            default:
                break;
        }

        // newVelocity = Math.Clamp(newVelocity, -player.speed, player.speed);
        if (newVelocity > -player.speed && newVelocity < player.speed)
        {
            player.Velocity = new Vector2(newVelocity, player.Velocity.Y);
        }

        // Check if touching wall
        if (player.IsOnWall())
        {
            if (player.GetWallNormal().X == -1) // Face sprite left
            {
                player.Scale = new Vector2(1, -1);
                player.RotationDegrees = 180;
            }
            else // Face sprite right
            {
                player.Scale = new Vector2(1, 1);
                player.RotationDegrees = 0;
            }

            Dispatch("wall");
        }

        // Store Y velocity
        player.storedVelocityY = player.Velocity.X;
    }
}
