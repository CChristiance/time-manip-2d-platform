using Godot;
using System;

public partial class Posture : Node2D
{
    [Export] int maxPosture = 10;
    int currentPosture;

    public override void _Ready()
    {
        currentPosture = maxPosture;
    }

    public void Damage(int stagger)
    {
        if (stagger > 0)
        {
            currentPosture = Math.Max(currentPosture - stagger, 0);
            GD.Print(currentPosture);
        }

        if (currentPosture == 0)
        {
            GD.Print("staggered");
            currentPosture = maxPosture;
            GetParent().Call("Stagger");
        }
    }

    public void Recover(int restore)
    {
        if (restore > 0)
        {
            currentPosture = Math.Min(currentPosture + restore, maxPosture);
        }
    }
}
