using Godot;
using System;

public partial class Hurtbox : Area2D
{
    [Export] public bool isGuarding = false;
    [Export] public bool isParrying = false;

    public override void _Ready()
    {
        // CollisionLayer = 2;
        // CollisionMask = 0;
    }

    private void _GetHit(int damage, int stagger, Vector2 knockback, Hitbox hitbox)
    {
        // GD.Print("Hit received");
        if (!isGuarding && !isParrying)
        {
            Owner.Call("OnHit", damage, stagger, knockback); // Owner must have public 'OnHit' method
        }
        else if (isParrying)
        {
            // Uno reverse - hitbox owner's parent called instead
            GD.Print("Get parried idiot");
            hitbox.Owner.Call("OnHit", 0, 10, 0);
        }
        else if (isGuarding)
        {
            GD.Print("BLOCK");
            // Guard behavior goes here
            // Still call OnHit, but lower damage, stagger, and knockback
        }
    }
}
