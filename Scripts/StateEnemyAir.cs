using Godot;
using System;
using System.Linq;

public partial class StateEnemyAir : State<Enemy>
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
        if (!Character.IsOnFloor())
        {
            nextState = stateEngine.states.OfType<StateEnemyGround>().FirstOrDefault();
        }
    }
}
