using Godot;
using System;

public partial class Hitbox : Area2D
{
    [Export] public int damage;
    [Export] public Vector2 knockback;

    public CollisionShape2D shape2D;

    public override void _Ready()
    {
        shape2D = GetNode<CollisionShape2D>("CollisionShape2D");
        AreaEntered += _OnAreaEntered;
        CollisionLayer = 0;
        CollisionMask = 2;
        Position = new Vector2(0, 0);
        Scale = new Vector2(0, 0);
        Monitoring = false;
        Monitorable = false;
    }

    // Used to detect hurtboxes already overlapping upon entry
    private void _Hit()
    {
        foreach (var obj in GetOverlappingAreas())
        {
            if (obj is Hurtbox hurtbox)
            {
                // Owner must have public 'OnHit' method
                Vector2 trueKnockback = new Vector2(knockback.X * ((Node2D)Owner).Scale.Y, knockback.Y);
                hurtbox.Call("_GetHit", trueKnockback); 
            }
        }
    }

    // Lingering Hitbox
    private void _OnAreaEntered(Area2D area)
    {
        if (area is Hurtbox hurtbox)
        {
            Vector2 trueKnockback = new Vector2(knockback.X * ((Node2D)Owner).Scale.Y, knockback.Y);
            hurtbox.Call("_GetHit", trueKnockback);
        }
    }
}
