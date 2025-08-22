using Godot;
using System;

public partial class AttackState : PlayerLimboState
{
    float friction;
    double timer;

    public override void _Enter()
    {
        base._Enter();
        friction = 1f;
        timer = 0f;
        _animationPlayer.Play("Kick 1");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        base._Exit();
        // player.isAttacking = false;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
        timer += delta;
        float velocity = player.Velocity.X;
        friction = _easeOutCubic(timer);
        velocity *= friction;
        player.Velocity = new Vector2(velocity, player.Velocity.Y);
        // easeOutCubic
    }

    private void _on_animation_player_animation_finished(StringName animName)
    {
        // Exit State
        if (!IsActive()) return;
        Dispatch("to_ground");
    }

    private float _easeOutCubic(double x)
    {
        return (float)Math.Pow(1 - x, 3);
    }
}
