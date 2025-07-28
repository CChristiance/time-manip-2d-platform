using Godot;
using System;

public partial class Hitbox : Area2D
{
    void OnAreaShapeEntered()
    {
        GD.Print("Hit!");
    }
}
