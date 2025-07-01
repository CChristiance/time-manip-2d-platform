using Godot;
using System;
using System.Linq;

public partial class StateEnemyGround : State<Enemy>
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
            nextState = stateEngine.states.OfType<StateEnemyAir>().FirstOrDefault();
        }
        TryJump();
    }

    public void TryJump()
    {
        if (Character.IsOnFloor())
        {
            // Character.Velocity = new Vector2(Character.Velocity.X, Character.jumpHeight);
        }
    }
}
