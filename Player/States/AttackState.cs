using Godot;
using System;

public partial class AttackState : PlayerLimboState
{
    public override void _Enter()
    {
        base._Enter();
        _animationPlayer.Play("Kick 1");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        base._Exit();
        // player.isAttacking = false;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
    }

    private void _on_animation_player_animation_finished(StringName animName)
    {
        // Exit State
        if (!IsActive()) return;
        Dispatch("to_ground");
    }
}
