using Godot;
using System;

public partial class DashState : PlayerLimboState
{
    [Export] float dashSpeed = 200f;
    private Timer dashDuration;
    private float oldGravity = 0;

    public override void _Ready()
    {
        base._Ready();
        dashDuration = GetChild<Timer>(0);
        dashDuration.Timeout += _OnTimerTimeout;
    }

    public override void _Enter()
    {
        base._Enter();

        _animationPlayer.Play("Dash");
        oldGravity = player.gravity;
        player.gravity = 0;

        dashDuration.Start();

        if (player.Scale.Y > 0) // Facing right
        {
            player.Velocity = new Vector2(player.Velocity.X + dashSpeed, 0f);
        }
        else // Facing left
        {
            player.Velocity = new Vector2(player.Velocity.X - dashSpeed, 0f);
        }
    }

    public override void _Exit()
    {
        base._Exit();
        player.gravity = oldGravity;
    }

    private void _OnTimerTimeout()
    {
        Dispatch("to_air");
    }
}
