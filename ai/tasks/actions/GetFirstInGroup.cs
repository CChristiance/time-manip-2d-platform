using Godot;
using Godot.Collections;
using System;

[Tool]
public partial class GetFirstInGroup : BTAction
// Stores first node of the member group on the blackboard
// Returns a SUCCESS if the group is valid and a node is found
{
    Node2D _agentNode;

    [Export] StringName group;
    [Export] StringName outputVar = "target";

    public override string _GenerateName()
    {
        return string.Format("GetFirstNodeInGroup {0} -> {1}", group, LimboUtility.DecorateVar(outputVar));
    }

    public override void _Setup()
    {
        _agentNode = Agent as Node2D;
    }

    public override Status _Tick(double delta)
    {
        Array<Node> nodes = _agentNode.GetTree().GetNodesInGroup(group);
        if (nodes.Count == 0)
        {
            return Status.Failure;
        }
        Blackboard.SetVar(outputVar, nodes[0]);
        return Status.Success;
    }
}
