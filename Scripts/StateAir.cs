using Godot;
using System;
using System.Linq;

public partial class StateAir : State<Player>
{
    bool canDoubleJump;
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
        if (Character.IsOnFloor())
        {
            nextState = stateEngine.states.OfType<StateGround>().FirstOrDefault();
        }
    }

    public override void OnEnter()
    {
        canDoubleJump = true;
    }

    public override void OnExit()
    {
        canDoubleJump = true;
    }
    
    public void TryJump()
    {
        if (canDoubleJump)
        {
            Character.Velocity = new Vector2(Character.Velocity.X, Character.jumpHeight - 50f);
            canDoubleJump = false;
        }
    }
}
