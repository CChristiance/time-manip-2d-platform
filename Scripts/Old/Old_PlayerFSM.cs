// using Godot;
// using System;
// using System.Collections.Generic;

// public partial class PlayerFSM : StateEngine
// {
//     public enum States
//     {
//         IDLE,
//         WALK,
//         RUN,
//         JUMP
//     }

//     public override void _Ready()
//     {
//         base._Ready();
//         curState = (int)States.IDLE;
//         prevState = (int)States.IDLE;
//         // States = new Dictionary<string, int>();
//         // AddState("Idle");
//         // AddState("Walk");
//     }

//     public override void _StateLogic(double delta)
//     {
//         Player player = parent as Player;
//         switch ((States)curState)
//         {
//             case States.IDLE:
//                 player.Idling();
//                 break;
//             case States.WALK:
//                 player.Walking();
//                 break;
//             default:
//                 break;
//         }
//     }

//     public override string _GetTransition(double delta)
//     {
//         return null;
//     }

//     public override void _EnterState(string newState, string oldState)
//     {
//         return;
//     }
// }
