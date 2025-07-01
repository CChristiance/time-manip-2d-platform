using Godot;
using System;
using System.Collections.Generic;

public abstract partial class State<T> : Node where T : CharacterBody2D
{
    // Store a reference to the state engine
    protected StateEngine<T> _stateEngine;
    public StateEngine<T> stateEngine => _stateEngine;
    public T Character { get; private set; }
    public void Initialize(T character, StateEngine<T> stateEngine)
    {
        Character = character;
        _stateEngine = stateEngine;
    }
    public State<T> nextState;
    public virtual bool canMove => true;

    public abstract void StateInput(InputEvent @event);
    public abstract void StateProcess(double delta);
    public abstract void OnEnter();
    public abstract void OnExit();
}
