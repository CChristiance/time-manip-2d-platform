using Godot;
using System;

public partial class Swordman : EnemyGeneric
{
    private BTState _patrol;
    private BTState _hostile;
    private LimboState _stagger;

    // private Health _health;
    // private Posture _posture;

    public override void _Ready()
    {
        _patrol = GetNode<BTState>("LimboHSM/Patrol");
        _hostile = GetNode<BTState>("LimboHSM/Hostile");
        _stagger = GetNode<LimboState>("LimboHSM/Stagger");

        // _health = GetNode<Health>("Health");
        // _posture = GetNode<Posture>("Posture");

        base._Ready();
    }

    public override void OnHit(int damage, int stagger, Vector2 knockback)
    {
        Velocity = knockback;
        _health.Damage(damage);
        _posture.Damage(stagger);
        MoveAndSlide();
    }

    public override void _InitStateMachine()
    {
        _hsm.InitialState = _patrol;
        _hsm.AddTransition(_hsm.ANYSTATE, _hostile, "hostile");
        _hsm.AddTransition(_hsm.ANYSTATE, _patrol, "patrol");
        _hsm.AddTransition(_hsm.ANYSTATE, _stagger, "stagger");

        _hsm.Initialize(this);
        _hsm.SetActive(true);
    }

    public void Patrol()
    {
        _hsm.Dispatch("patrol");
    }

    public void Hostile()
    {
        _hsm.Dispatch("hostile");
    }

    public void Stagger()
    {
        _hsm.Dispatch("stagger");
    }
}
