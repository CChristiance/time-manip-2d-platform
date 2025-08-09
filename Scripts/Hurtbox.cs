using Godot;
using System;

public partial class Hurtbox : Area2D
{
    public override void _Ready()
    {
        CollisionLayer = 2;
        CollisionMask = 0;
    }

    private void _GetHit(Vector2 knockback)
    {
        Owner.Call("OnHit", knockback); // Owner must have public 'OnHit' method
    }
}
