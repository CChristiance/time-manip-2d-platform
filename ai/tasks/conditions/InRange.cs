using Godot;
using System;

[Tool]
public partial class InRange : BTCondition
{
    [Export] public float distanceMin;
    [Export] public float distanceMax;
    [Export] public string targetVar = "target";

    float _minDistanceSquared;
    float _maxDistanceSquared;
    Node2D _agentNode;

    public override string _GenerateName()
    {
        //return string.Format("InRange ({0}, {1}) of {2}", distanceMin, distanceMax, LimboUtility.DecorateVar(targetVar));
        return "InRange";
    }

    public override void _Setup()
    {
        _minDistanceSquared = distanceMin * distanceMin;
        _maxDistanceSquared = distanceMax * distanceMax;
        _agentNode = Agent as Node2D;
    }

    public override Status _Tick(double delta)
    {
        Variant value = Blackboard.GetVar(targetVar, new Variant());
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
