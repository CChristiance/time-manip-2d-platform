using Godot;
using System;

public partial class AttackState : LimboState
{
    private AnimationPlayer _animationPlayer;
    [Export] float speed = 200f;
    Player player;

    public override void _Setup()
    {
        player = (Player)Agent;
        _animationPlayer = GetNode<AnimationPlayer>("../../AnimationPlayer");
    }

    public override void _Enter()
    {
        GD.Print("Attack");
        _animationPlayer.Play("Kick 1");
        _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        player.isAttacking = false;
        _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
    }

    private void _on_animation_player_animation_finished(StringName animName)
    {
        // Exit State
        if (!IsActive()) return;
        Dispatch("idle_started");
    }
}
