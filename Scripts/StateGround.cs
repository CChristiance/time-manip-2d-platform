using Godot;
using System;
using System.Linq;

public partial class StateGround : State<Player>
{
    public override void StateInput(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_jump")) TryJump();

        if (@event.IsActionPressed("ui_rewind"))
        {
            nextState = stateEngine.states.OfType<StateRewinding<Player>>().FirstOrDefault();
        }
    }

    public override void StateProcess(double delta)
    {
        if (!Character.IsOnFloor())
        {
            nextState = stateEngine.states.OfType<StateAir>().FirstOrDefault();
        }
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public void TryJump()
    {
        if (Character.IsOnFloor())
        {
            Character.Velocity = new Vector2(Character.Velocity.X, Character.jumpHeight);
        }
    }
}
