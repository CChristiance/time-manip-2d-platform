using Godot;
using System;

[Tool]
public partial class Pursue : BTAction
// Move towards the target
{
    CharacterBody2D _agentNode;

    // How close to get before stopping
    // const float TOLERANCE = 30.0f;

    [Export] StringName targetVar = "target";
    [Export] StringName speedVar = "speed";

    // Desired distance from target
    [Export] float approachDistance = 100f;

    CharacterBody2D target;

    public override string _GenerateName()
    {
        return string.Format("Pursue {0}", LimboUtility.DecorateVar(targetVar));
    }

    public override void _Setup()
    {
        _agentNode = Agent as CharacterBody2D;
    }

    public override void _Enter()
    {
        target = (CharacterBody2D)Blackboard.GetVar(targetVar);
        if (IsInstanceValid(target))
        {
            // _SelectNewWaypoint(_GetDesiredPosition(target));
        }
    }

    public override Status _Tick(double delta)
    {
        // CharacterBody2D target = (CharacterBody2D)Blackboard.GetVar(targetVar);
        if (!IsInstanceValid(target))
        {
            return Status.Failure;
        }

        // Stop pursuit when actor is within the tolerance
        Vector2 desiredPos = _GetDesiredPosition(target);


        // --------------------------------------------
        // var circle = new Node2D();
        // circle.Position = desiredPos;

        // circle.Draw += () =>
        // {
        //     circle.DrawCircle(Vector2.Zero, 10, Colors.Red); // radius 10 at position
        // };

        // // Add it to the scene so Godot can render it
        // _agentNode.GetTree().CurrentScene.AddChild(circle);
        // var timer = new Timer();
        // timer.WaitTime = 0.05f;  // seconds before erase
        // timer.OneShot = true;
        // timer.Timeout += () => circle.QueueFree();
        // circle.AddChild(timer);
        // timer.Start();
        // ----------------------------------------

        if (_agentNode.GlobalPosition.DistanceTo(target.GlobalPosition) < approachDistance)
        {
            _agentNode.Velocity = new Vector2(0f, _agentNode.Velocity.Y);
            return Status.Success;
        }

        // float speed = (float)Blackboard.GetVar(speedVar, 200.0f);
        float speed = 200f;
        float side = Mathf.Sign(target.GlobalPosition.X - _agentNode.GlobalPosition.X);
        Vector2 desiredVelocity = new Vector2(side * speed, _agentNode.Velocity.Y);

        _agentNode.Velocity = desiredVelocity;
        _agentNode.Scale = new Vector2(1, side);
        _agentNode.RotationDegrees = 90 - 90 * side;

        // _agentNode.MoveAndSlide();

        return Status.Running;
    }

    private Vector2 _GetDesiredPosition(CharacterBody2D target)
    {
        // Find if agent is to left or right of target
        float side = Mathf.Sign(_agentNode.GlobalPosition.X - target.GlobalPosition.X);

        // Sets desired position to the coords of the target
        Vector2 desiredPos = target.GlobalPosition;

        // Sets desired position to 'approachDistance' units away from target
        desiredPos.X += approachDistance * side;
        return desiredPos;
    }
}
