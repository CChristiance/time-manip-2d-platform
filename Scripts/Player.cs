using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // Player movement variables
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;

    // private Sprite2D sprite;
    StateEngine<Player> stateEngine;

    public override void _Ready()
    {
        gravity = Global.Instance.globalGravity;
        stateEngine = GetNode<StateEngine<Player>>("PlayerStateEngine");
        stateEngine.Initialize(this); // Set the Character property
        stateEngine.InitializeStates(); // Now initialize states with correct Character
    }

    public override void _PhysicsProcess(double delta)
    {
        // PlayerFSM fsm = GetNode<PlayerFSM>("StateEngine");
        // fsm._StateLogic(delta);
        if (stateEngine.CheckIfCanMove()) HorizontalMovement();
        Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * (float)delta);
        MoveAndSlide();
    }

    private void HorizontalMovement()
    {
        float horizontalInput = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        Velocity = new Vector2(horizontalInput * speed, Velocity.Y);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_left"))
        {
            // Velocity = new Vector2(-speed, Velocity.Y);
        }
        else if (@event.IsActionPressed("ui_right"))
        {
            // Velocity = new Vector2(speed, Velocity.Y);
        }
        // PlayerFSM fsm = GetNode<PlayerFSM>("StateEngine");
        // if (@event.IsActionPressed("ui_left") || @event.IsActionPressed("ui_right") && !IsOnFloor())
        // {
        //     fsm.SetState((int)PlayerFSM.States.WALK);
        // }
    }

    public void test()
    {
        GD.Print("test");
    }
}
