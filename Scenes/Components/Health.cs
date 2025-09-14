using Godot;
using System;

public partial class Health : Node2D
{
    [Export] int maxHealth = 10;
    int currentHealth;

    public override void _Ready()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        if (damage > 0)
        {
            currentHealth = Math.Max(currentHealth - damage, 0);
            GD.Print(currentHealth);
        }
    }

    public void Heal(int restore)
    {
        if (restore > 0)
        {
            currentHealth = Math.Min(currentHealth + restore, maxHealth);
        }
    }
}
