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
    }
}
