using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class RewindState : PlayerLimboState
{
    public class RewindSnapshot
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public LimboState State { get; set; }

        public RewindSnapshot(Vector2 position, Vector2 velocity, LimboState state)
        {
            Position = position;
            Velocity = velocity;
            State = state;
        }
    }

    LinkedList<RewindSnapshot> rewindBuffer = [];

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Enter()
    {
        base._Enter();
    }

    public override void _Exit()
    {
        base._Exit();
    }

    public override void _Update(double delta)
    {
        base._Update(delta);
    }
}
