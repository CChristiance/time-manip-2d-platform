using Godot;
using System;

public partial class EnemyHurtState : LimboState
{
    private AnimationPlayer _animationPlayer;
    [Export] float speed = 0;
    Enemy enemy;
    [Export] int hitstun = 100;
    int timer;

    public override void _Setup()
    {
        enemy = (Enemy)Agent;
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        timer = hitstun;
        if (enemy.Velocity.X < 0)
        {
            GD.Print(enemy.Velocity.X);
            _animationPlayer.Play("Hurt Back");
        }
        else
        {
            GD.Print(enemy.Velocity.X);
            _animationPlayer.Play("Hurt Front");
        }
    }

    public override void _Update(double delta)
    {
        if (timer-- <= 0)
        {
            Dispatch("idle_started");
        }
    }
}
