using Godot;
using System;

public abstract partial class EnemyGeneric : CharacterBody2D
{
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;
    [Export] public float friction = 0.1f;

    [Export] public AnimatedSprite2D _animatedSprite;

    // Onready state machine variables
    public LimboHsm _hsm;
    private AnimationPlayer _animationPlayer;

    // Components
    public Health _health;
    public Posture _posture;

    public override void _Ready()
    {
        _health = GetNodeOrNull<Health>("Health");
        _posture = GetNodeOrNull<Posture>("Posture");

        gravity = Global.Instance.globalGravity;
        _hsm = GetNode<LimboHsm>("LimboHSM");
        _InitStateMachine();
    }

    // Set idle states, define state transitions, and initial state
    public abstract void _InitStateMachine();
    // hsm.Initialize(this);
    // hsm.SetActive(true);

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * (float)delta); // Add gravity
        Velocity = Velocity.Lerp(new Vector2(0, Velocity.Y), friction); // Friction
        MoveAndSlide();
    }

    public abstract void OnHit(int damage, int stagger, Vector2 knockback);
}
