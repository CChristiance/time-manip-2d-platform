// using Godot;
// using System;
// using System.Linq;

// public partial class StateGround : State
// {
//     public override void StateInput(InputEvent @event)
//     {
//         if (@event.IsActionPressed("ui_jump")) TryJump();

//         if (@event.IsActionPressed("ui_rewind"))
//         {
//             nextState = stateEngine.states.OfType<StateRewinding>().FirstOrDefault();
//         }
//     }

//     public override void StateProcess(double delta)
//     {
//         if (!character.IsOnFloor())
//         {
//             nextState = stateEngine.states.OfType<StateAir>().FirstOrDefault();
//         }
//     }

//     public override void OnEnter()
//     {

//     }

//     public override void OnExit()
//     {

//     }

//     public void TryJump()
//     {
//         if (character.IsOnFloor())
//         {
//             character.Velocity = new Vector2(character.Velocity.X, character.jumpHeight);
//         }
//     }
// }
