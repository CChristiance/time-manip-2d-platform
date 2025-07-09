using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // Player movement variables
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;

    // Onready state machine variables
    private LimboHsm hsm;
    private LimboState idleState;
    private LimboState moveState;

    // private Sprite2D sprite;
    // StateEngine stateEngine;

    public override void _Ready()
    {
        gravity = Global.Instance.globalGravity;
        hsm = GetNode<LimboHsm>("LimboHSM");
        idleState = GetNode<LimboState>("LimboHSM/IdleState");
        moveState = GetNode<LimboState>("LimboHSM/MoveState");
        // stateEngine = GetNode<StateEngine>("StateEngine");
        _InitStateMachine();
    }

    public void _InitStateMachine()
    {
        hsm.InitialState = idleState;
        hsm.AddTransition(idleState, moveState, idleState.EVENTFINISHED);
        hsm.AddTransition(moveState, idleState, moveState.EVENTFINISHED);

        hsm.Initialize(this);
        hsm.SetActive(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        // PlayerFSM fsm = GetNode<PlayerFSM>("StateEngine");
        // fsm._StateLogic(delta);
        HorizontalMovement();
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
