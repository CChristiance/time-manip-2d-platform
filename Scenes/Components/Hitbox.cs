using Godot;
using System;

public partial class Hitbox : Area2D
{
    [Export] public int damage = 0;
    [Export] public int stagger = 0;
    [Export] public Vector2 knockback = Vector2.Zero;

    public override void _Ready()
    {
        AreaEntered += _OnAreaEntered;
    }

    // Used to detect hurtboxes already overlapping upon entry
    private void _Hit()
    {
        // GD.Print("hit called");
        foreach (var obj in GetOverlappingAreas())
        {
            if (obj is Hurtbox hurtbox && hurtbox.GetParent() != GetParent())
            {
                // GD.Print("Hit sent");
                // Owner must have public 'OnHit' method
                Vector2 trueKnockback = new Vector2(knockback.X * ((Node2D)Owner).Scale.Y, knockback.Y);
                hurtbox.Call("_GetHit", damage, stagger, trueKnockback, this);
            }
        }
    }

    // Lingering Hitbox
    private void _OnAreaEntered(Area2D area)
    {
        if (area is Hurtbox hurtbox && hurtbox.GetParent() != GetParent())
        {
            // GD.Print("Hit sent");
            Vector2 trueKnockback = new Vector2(knockback.X * ((Node2D)Owner).Scale.Y, knockback.Y);
            hurtbox.Call("_GetHit", damage, stagger, trueKnockback, this);
        }
    }
}
