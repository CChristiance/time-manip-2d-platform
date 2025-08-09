// using Godot;
// using System;
// using System.Linq;
// using System.Collections.Generic;

// public partial class StateRewinding : State
// {
//     State lastState;
//     public override bool canMove => false;

//     public class RewindSnapshot
//     {
//         public Vector2 Position { get; set; }
//         public Vector2 Velocity { get; set; }
//         public State State { get; set; }

//         public RewindSnapshot(Vector2 position, Vector2 velocity, State state)
//         {
//             Position = position;
//             Velocity = velocity;
//             State = state;
//         }
//     }
//     LinkedList<RewindSnapshot> rewindBuffer = [];

//     public override void StateInput(InputEvent @event)
//     {
//         if (@event.IsActionReleased("ui_rewind"))
//         {
//             // Switch state to state stored in rewindBuffer
//             nextState = lastState;
//         }
//     }

//     public override void StateProcess(double delta)
//     {
//         if (rewindBuffer.Count > 0)
//         {
//             character.Position = rewindBuffer.Last().Position;
//             character.Velocity = rewindBuffer.Last().Velocity;
//             lastState = rewindBuffer.Last().State;
//             rewindBuffer.RemoveLast();
//         }
//     }

//     public override void OnEnter()
//     {

//     }

//     public override void OnExit()
//     {

//     }

//     public override void _PhysicsProcess(double delta)
//     {
//         // Only add to pastPositions if not rewinding
//         if (stateEngine.currentState is not StateRewinding)
//         {
//             // Limit size of rewind duration
//             if (rewindBuffer.Count >= 300)
//             {
//                 rewindBuffer.RemoveFirst();
//             }
//             TakeSnapshot();
//         }
//     }

//     // Store relevant player information at the time (position, animation frame, state, etc.)
//     private void TakeSnapshot()
//     {
//         Vector2 position = character.Position;
//         Vector2 velocity = character.Velocity;
//         State state = stateEngine.currentState;
//         RewindSnapshot snapshot = new RewindSnapshot(position, velocity, state);
//         rewindBuffer.AddLast(snapshot);
//     }
// }
