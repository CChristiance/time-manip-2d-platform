using Godot;
using System;

public partial class Stagger : LimboState
{
    Timer timer = new();
    [Export] float staggerDuration = 0.5f;
    [Export] private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        // _animationPlayer = Agent.GetNode<AnimationPlayer>("AnimationPlayer");

        // timer = new Timer();
        AddChild(timer);
        timer.Timeout += _TimerEnd;
        timer.OneShot = true;
        timer.WaitTime = staggerDuration;
    }

    public override void _Enter()
    {
        GD.Print("starting stagger");
        GD.Print(timer.WaitTime);
        timer.Start();
        _animationPlayer.Play("Unsteady");
    }

    public override void _Update(double delta)
    {
        // GD.Print(timer.TimeLeft);
    }

    private void _TimerEnd()
    {
        Dispatch("hostile");
    }
}
