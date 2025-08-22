using Godot;
using System;

public abstract partial class EnemyGeneric : CharacterBody2D
{
    [Export] public float speed = 200f;
    [Export] public float gravity;
    [Export] public float jumpHeight = -300f;

    [Export] public AnimatedSprite2D _animatedSprite;

    // Onready state machine variables
    private LimboHsm _hsm;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        gravity = Global.Instance.globalGravity;
        _hsm = GetNode<LimboHsm>("LimboHSM");
        _InitStateMachine();
    }

    // Set idle states, define state transitions, and initial state
    public abstract void _InitStateMachine();
    // hsm.Initialize(this);
    // hsm.SetActive(true);

    public abstract void OnHit(Vector2 knockback);
}
