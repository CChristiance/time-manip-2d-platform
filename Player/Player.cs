using Godot;
using System;

public partial class Player : CharacterBody2D
{
    // Player movement variables
    [Export] public float speed = 300f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;
    public float storedVelocityX;
    public float storedVelocityY;

    public bool canJump = true;
    public bool canMove = true;
    // public bool isJumping = false;
    // public bool isAttacking = false;

    private AnimationPlayer _animationPlayer;
    private Sprite2D _sprite;

    // Onready state machine variables
    private LimboHsm _hsm;

    private LimboHsm _groundHsm;
    private LimboState _idleState;
    private LimboState _walkState;
    private LimboState _runState;

    private LimboHsm _airHsm;
    private LimboState _fallState;
    private LimboState _jumpState;
    private LimboState _stompState;

    private LimboState _attackState;
    private LimboState _slideState;
    private LimboState _dashState;
    private LimboState _wallState;

    public override void _Ready()
    {
        // Instantiate states
        _hsm = GetNode<LimboHsm>("LimboHSM");

        _groundHsm = GetNode<LimboHsm>("LimboHSM/GroundHSM");
        _idleState = GetNode<LimboState>("LimboHSM/GroundHSM/IdleState");
        _walkState = GetNode<LimboState>("LimboHSM/GroundHSM/WalkState");
        _runState = GetNode<LimboState>("LimboHSM/GroundHSM/RunState");

        _airHsm = GetNode<LimboHsm>("LimboHSM/AirHSM");
        _fallState = GetNode<LimboState>("LimboHSM/AirHSM/FallState");
        _jumpState = GetNode<LimboState>("LimboHSM/AirHSM/JumpState");
        _stompState = GetNode<LimboState>("LimboHSM/AirHSM/StompState");

        _attackState = GetNode<LimboState>("LimboHSM/AttackState");
        _slideState = GetNode<LimboState>("LimboHSM/SlideState");
        _dashState = GetNode<LimboState>("LimboHSM/DashState");
        _wallState = GetNode<LimboState>("LimboHSM/WallState");

        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _sprite = GetNode<Sprite2D>("Sprite2D");
        gravity = Global.Instance.globalGravity;
        AddToGroup("player");
        _InitStateMachine();
    }

    public void _InitStateMachine()
    {
        _hsm.InitialState = _groundHsm;
        _groundHsm.InitialState = _idleState;
        _airHsm.InitialState = _fallState;

        _hsm.AddTransition(_hsm.ANYSTATE, _airHsm, "to_air");
        _hsm.AddTransition(_hsm.ANYSTATE, _groundHsm, "to_ground");

        _hsm.AddTransition(_groundHsm, _attackState, "attack");
        _hsm.AddTransition(_groundHsm, _slideState, "slide");
        _hsm.AddTransition(_airHsm, _slideState, "slide");
        _hsm.AddTransition(_groundHsm, _dashState, "dash");
        _hsm.AddTransition(_airHsm, _dashState, "dash");
        _hsm.AddTransition(_airHsm, _wallState, "wall");

        _airHsm.AddTransition(_jumpState, _fallState, "fall");
        _airHsm.AddTransition(_airHsm.ANYSTATE, _stompState, "stomp");

        _groundHsm.AddTransition(_groundHsm.ANYSTATE, _idleState, "idle");
        _groundHsm.AddTransition(_groundHsm.ANYSTATE, _walkState, "walk");
        _groundHsm.AddTransition(_groundHsm.ANYSTATE, _runState, "run");

        _hsm.Initialize(this);
        _hsm.SetActive(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * (float)delta);
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        // if (canMove && (@event.IsActionPressed("left") || @event.IsActionPressed("right")))
        // {
        //     _groundHsm.Dispatch("walk");
        // }
        if (canJump && @event.IsActionPressed("jump"))
        {
            _airHsm.InitialState = _jumpState;
            _hsm.Dispatch("to_air");
            _airHsm.InitialState = _fallState;
        }
        else if (@event.IsActionPressed("attack"))
        {
            _hsm.Dispatch("attack");
        }
        else if (@event.IsActionPressed("slide"))
        {
            _hsm.Dispatch("stomp");
        }
        else if (@event.IsActionPressed("dash"))
        {
            _hsm.Dispatch("dash");
        }
        else if (@event.IsActionPressed("rewind"))
        {
            // _hsm.Dispatch("rewind");
        }

    }
}
