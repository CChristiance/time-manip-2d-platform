using Godot;
using System;

public partial class StompState : PlayerLimboState
{
    [Export] float stompGravity = 2000f;
    [Export] float stompForce = 500f;
    float oldGravity;

    public override void _Enter()
    {
        base._Enter();
        oldGravity = player.gravity;
        player.gravity = stompGravity;
        player.Velocity = new Vector2(player.Velocity.X, player.Velocity.Y + stompForce);
    }

    public override void _Exit()
    {
        base._Exit();
        player.gravity = oldGravity;
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        if (player.IsOnFloor())
        {
            if (Input.IsActionPressed("slide"))
            {
                Dispatch("slide");
            }
            else
            {
                Dispatch("to_ground");
            }
        }
        else
        {
            player.storedVelocity = player.Velocity.Y;
        }
    }
}
