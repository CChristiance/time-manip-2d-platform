using Godot;
using System;
using System.Linq;

public partial class StateEnemyGround : State
{
    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void StateInput(InputEvent @event)
    {
    }

    public override void StateProcess(double delta)
    {
        if (!character.IsOnFloor())
        {
            nextState = stateEngine.states.OfType<StateEnemyAir>().FirstOrDefault();
        }
    }
}
