using Godot;
using System;
using System.Linq;

public partial class StateAir : State
{
    public override void StateInput(InputEvent @event)
    {
        
    }

    public override void StateProcess(double delta)
    {
        if (character.IsOnFloor())
        {
            nextState = stateEngine.states.OfType<StateGround>().FirstOrDefault();
        }
    }

    public override void OnEnter()
    {

    }
    
    public override void OnExit()
    {

    }
}
