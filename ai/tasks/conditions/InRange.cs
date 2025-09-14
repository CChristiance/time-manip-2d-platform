using Godot;
using System;

[Tool]
public partial class InRange : BTCondition
{
    [Export] float distanceMin;
    [Export] float distanceMax;
    [Export] StringName targetVar = "target";

    float _minDistanceSquared;
    float _maxDistanceSquared;
    Node2D _agentNode;

    CharacterBody2D target;

    public override string _GenerateName()
    {
        return string.Format("InRange ({0}, {1}) of {2}", distanceMin, distanceMax, LimboUtility.DecorateVar(targetVar));
    }

    public override void _Setup()
    {
        _minDistanceSquared = distanceMin * distanceMin;
        _maxDistanceSquared = distanceMax * distanceMax;
        _agentNode = Agent as Node2D;
    }

    public override void _Enter()
    {
        target = (CharacterBody2D)Blackboard.GetVar(targetVar);
    }

    public override Status _Tick(double delta)
    {
        Variant value = Blackboard.GetVar(targetVar);
        Node2D target = value.As<Node2D>();
        if (!IsInstanceIdValid(target.GetInstanceId()))
        {
            return Status.Failure;
        }

        float distSq = _agentNode.GlobalPosition.DistanceSquaredTo(target.GlobalPosition);

        if (distSq >= _minDistanceSquared && distSq <= _maxDistanceSquared)
        {
            return Status.Success;
        }
        else
        {
            return Status.Failure;
        }
    }
}
