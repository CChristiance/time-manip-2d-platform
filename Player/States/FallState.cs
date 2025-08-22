using Godot;
using System;

public partial class FallState : PlayerLimboState
{
    [Export] float fastFallGravity = 750f;
    float oldGravity;

    public override void _Enter()
    {
        // Increase gravity when falling
        base._Enter();
        player.canJump = false;
        oldGravity = player.gravity;
        player.gravity = fastFallGravity;
        _animationPlayer.Play("Still Air"); // TODO: Change to falling animation
        // _animationPlayer.AnimationFinished += _on_animation_player_animation_finished;
    }

    public override void _Exit()
    {
        base._Exit();
        player.gravity = oldGravity;
        // _animationPlayer.AnimationFinished -= _on_animation_player_animation_finished;
        player.canJump = true;
        player.storedVelocityX = 0f;
    }

    public void _update(float delta)
    {
        // Handle Landing
        if (player.IsOnFloor())
        { 
            // _animationPlayer.Play("Still Squat"); // Skipping landing animation
            Dispatch("to_ground");
        }
    }

    // private void _on_animation_player_animation_finished(StringName animName)
    // {
    //     if (!IsActive()) return;
    //     Dispatch("to_ground");
    // }
}
