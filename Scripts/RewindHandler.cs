// using Godot;
// using System;
// using System.Collections.Generic;

// public partial class RewindHandler : Node
// {
//     LinkedList<Vector2> pastPositions = [];
//     CharacterBody2D character;
//     StateEngine stateEngine;
//     State stateRewinding;
//     public bool isRewinding = false;

//     public override void _Ready()
//     {
//         Node current = GetParent();
//         while (current != null && current is not CharacterBody2D)
//         {
//             current = current.GetParent();
//             if (current is CharacterBody2D)
//             {
//                 character = current as CharacterBody2D;
//             }
//             else if (current is StateEngine)
//             {
//                 stateEngine = current as StateEngine;
//             }
//             else if (current is StateRewinding)
//             {
//                 stateRewinding = current as StateRewinding;
//             }
//         }
//     }

//     public override void _PhysicsProcess(double delta)
//     {
//         // Only add to pastPositions if not rewinding
//         if (stateEngine.currentState is not StateRewinding)
//         {
//             // Limit size of rewind duration
//             if (pastPositions.Count >= 300)
//             {
//                 pastPositions.RemoveFirst();
//             }

//             Vector2 currentPosition = character.Position;
//             pastPositions.AddLast(currentPosition);
//         }
//     }

//     // public override void _Input(InputEvent @event)
//     // {
//     //     if (@event.IsActionPressed("ui_rewind") && pastPositions.Count > 0)
//     //     {
//     //         isRewinding = true;
//     //     }
//     //     else if (@event.IsActionReleased("ui_rewind"))
//     //     {
//     //         isRewinding = false;
//     //     }
//     // }

//     // private void Rewind()
//     // {
//     //     if (pastPositions.Count > 0)
//     //     {
//     //         character.Position = pastPositions.Last.Value;
//     //         pastPositions.RemoveLast();
//     //     }
//     // }
// }
