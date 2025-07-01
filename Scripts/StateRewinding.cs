using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class StateRewinding<T> : State<T> where T : CharacterBody2D
{
    State<T> lastState;
    public override bool canMove => false;

    public class RewindSnapshot
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public State<T> State { get; set; }

        public RewindSnapshot(Vector2 position, Vector2 velocity, State<T> state)
        {
            Position = position;
            Velocity = velocity;
            State = state;
        }
    }
    LinkedList<RewindSnapshot> rewindBuffer = [];

    public override void StateInput(InputEvent @event)
    {
        if (@event.IsActionReleased("ui_rewind"))
        {
            // Switch state to state stored in rewindBuffer
            nextState = lastState;
        }
    }

    public override void StateProcess(double delta)
    {
        if (rewindBuffer.Count > 0)
        {
            Character.Position = rewindBuffer.Last().Position;
            Character.Velocity = rewindBuffer.Last().Velocity;
            lastState = rewindBuffer.Last().State;
            rewindBuffer.RemoveLast();
        }
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        // Only add to pastPositions if not rewinding
        if (stateEngine.currentState is not StateRewinding<T>)
        {
            // Limit size of rewind duration
            if (rewindBuffer.Count >= 300)
            {
                rewindBuffer.RemoveFirst();
            }
            TakeSnapshot();
        }
    }

    // Store relevant player information at the time (position, animation frame, state, etc.)
    private void TakeSnapshot()
    {
        Vector2 position = Character.Position;
        Vector2 velocity = Character.Velocity;
        State<T> state = stateEngine.currentState;
        RewindSnapshot snapshot = new RewindSnapshot(position, velocity, state);
        rewindBuffer.AddLast(snapshot);
    }
}
