using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;

    [Export] public AnimatedSprite2D _animatedSprite;

    // Onready state machine variables
    private LimboHsm hsm;
    private LimboState idleState;
    // private LimboState moveState;
    private LimboState hurtState;
    private LimboState downedState;
    // private LimboState moveState;
    // private LimboState jumpState;
    // private LimboState fallState;
    // private LimboState landState;
    // private LimboState attackState;

    public override void _Ready()
    {
        gravity = Global.Instance.globalGravity;
        hsm = GetNode<LimboHsm>("LimboHSM");
        idleState = GetNode<LimboState>("LimboHSM/EnemyIdleState");
        hurtState = GetNode<LimboState>("LimboHSM/EnemyHurtState");
        downedState = GetNode<LimboState>("LimboHSM/EnemyDownedState");
        _InitStateMachine();
    }

    public void _InitStateMachine()
    {
        hsm.InitialState = idleState;
        hsm.AddTransition(hsm.ANYSTATE, idleState, "idle_started");
        hsm.AddTransition(hsm.ANYSTATE, hurtState, "hurt_started");
        hsm.AddTransition(hsm.ANYSTATE, downedState, "downed_started");

        hsm.Initialize(this);
        hsm.SetActive(true);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector2(Velocity.X * 0.99f, Velocity.Y + gravity * (float)delta);
        MoveAndSlide();
    }

    public void OnHit(Vector2 knockback)
    {
        Velocity = new Vector2(knockback.X, knockback.Y);
        hsm.Dispatch("hurt_started");
    }
}
