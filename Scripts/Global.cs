using Godot;
using System;

public partial class Global : Node
{
    public static Global Instance;
    [Export] public float globalGravity = 500f;
    
    public override void _Ready()
    {
		Instance = this;
    }
}
