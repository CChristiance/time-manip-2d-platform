using Godot;
using System;

public partial class GroundHsm : LimboHsm
{
    Player player;
    public override void _Setup()
    {
        base._Setup();
        player = (Player)Agent;
    }

    public void _update(float delta)
    {
        // Handle grounded movement
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

        horizontalInput *= player.speed;
        player.Velocity = new Vector2(horizontalInput, player.Velocity.Y);

        // Handle which substate to be in
        switch (Math.Abs(player.Velocity.X))
        {
            case >= 200f:
                Dispatch("run");
                break;
            case > 0:
                Dispatch("walk");
                break;
            default:
                Dispatch("idle");
                break;
        }

        // Fall if not on ground
        if (!player.IsOnFloor())
        {
            Dispatch("to_air");
        }
    }
}
