using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // Player movement variables
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;

    public bool canJump = true;
    public bool canMove = true;
    public bool isJumping = false;
    public bool isAttacking = false;

    // [Export] public AnimatedSprite2D _animatedSprite;
    private AnimationPlayer _animationPlayer;
    private Sprite2D _sprite;

    // Onready state machine variables
    private LimboHsm hsm;
    private LimboState idleState;
    private LimboState moveState;
    private LimboState jumpState;
    private LimboState fallState;
    private LimboState landState;
    private LimboState attackState;

    // private Sprite2D sprite;
    // StateEngine stateEngine;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _sprite = GetNode<Sprite2D>("Sprite2D");

        gravity = Global.Instance.globalGravity;
        hsm = GetNode<LimboHsm>("LimboHSM");
        idleState = GetNode<LimboState>("LimboHSM/IdleState");
        moveState = GetNode<LimboState>("LimboHSM/MoveState");
        jumpState = GetNode<LimboState>("LimboHSM/JumpState");
        fallState = GetNode<LimboState>("LimboHSM/FallState");
        landState = GetNode<LimboState>("LimboHSM/LandState");
        attackState = GetNode<LimboState>("LimboHSM/AttackState");
        // stateEngine = GetNode<StateEngine>("StateEngine");
        _InitStateMachine();
    }

    public void _InitStateMachine()
    {
        hsm.InitialState = idleState;
        hsm.AddTransition(hsm.ANYSTATE, moveState, "move_started");
        hsm.AddTransition(hsm.ANYSTATE, idleState, "idle_started");
        hsm.AddTransition(hsm.ANYSTATE, jumpState, "jump_started");
        hsm.AddTransition(hsm.ANYSTATE, fallState, "fall_started");
        hsm.AddTransition(hsm.ANYSTATE, landState, "land_started");
        hsm.AddTransition(hsm.ANYSTATE, attackState, "attack_started");

        hsm.Initialize(this);
        hsm.SetActive(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        // PlayerFSM fsm = GetNode<PlayerFSM>("StateEngine");
        // fsm._StateLogic(delta);
        if (canMove) HorizontalMovement();
        Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * (float)delta);
        MoveAndSlide();
    }

    private void HorizontalMovement()
    {
        float horizontalInput = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

        if (horizontalInput < 0)
        {
            _sprite.FlipH = true;
        }
        else if (horizontalInput > 0)
        {
            _sprite.FlipH = false;
        }
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
        else if (@event.IsActionPressed("ui_jump") && canJump)
        {
            // Velocity = new Vector2(Velocity.X, jumpHeight);
            isJumping = true;
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
