using Godot;
using System;

[Tool]
public partial class Pursue : BTAction
// Move towards the target
{
    CharacterBody2D _agentNode;

    // How close to get before stopping
    const float TOLERANCE = 30.0f;

    [Export] StringName targetVar = "target";
    [Export] StringName speedVar = "speed";

    // Desired distance from target
    [Export] float approachDistance = 100f;

    Vector2 _waypoint;

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
        CharacterBody2D target = (CharacterBody2D)Blackboard.GetVar(targetVar);
        if (IsInstanceValid(target))
        {
            _SelectNewWaypoint(_GetDesiredPosition(target));
        }
    }

    public override Status _Tick(double delta)
    {
        CharacterBody2D target = (CharacterBody2D)Blackboard.GetVar(targetVar);
        if (!IsInstanceValid(target))
        {
            return Status.Failure;
        }

        // Stop pursuit when actor is within the tolerance
        Vector2 desiredPos = _GetDesiredPosition(target);
        if (_agentNode.GlobalPosition.DistanceTo(desiredPos) < TOLERANCE)
        {
            return Status.Success;
        }

        if (_agentNode.GlobalPosition.DistanceTo(_waypoint) < TOLERANCE)
        {
            _SelectNewWaypoint(desiredPos);
        }

        float speed = (float)Blackboard.GetVar(speedVar, 200.0f);
        Vector2 desiredVelocity = _agentNode.GlobalPosition.DirectionTo(_waypoint) * speed;
        _agentNode.Velocity = desiredVelocity;
        _agentNode.MoveAndSlide();

        return Status.Running;
    }

    private Vector2 _GetDesiredPosition(CharacterBody2D target)
    {
        // GD.Print(target);
        // GD.Print(target.GlobalPosition);
        // GD.Print(_agentNode);
        // GD.Print(_agentNode.GlobalPosition);
        float side = Mathf.Sign(_agentNode.GlobalPosition.X - target.GlobalPosition.X);
        Vector2 desiredPos = target.GlobalPosition;
        desiredPos.X += approachDistance * side;
        return desiredPos;
    }

    private void _SelectNewWaypoint(Vector2 desiredPosition)
    {
        Vector2 distanceVector = desiredPosition - _agentNode.GlobalPosition;
        float angleVariation = (float)GD.RandRange(-0.2, 0.2);
        _waypoint = _agentNode.GlobalPosition + distanceVector.LimitLength(150.0f).Rotated(angleVariation);
    }
}
