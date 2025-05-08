using StateMachine;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : GenericStateMachine<PlayerController, PlayerState>
    {
        public PlayerStateMachine(PlayerController owner, Rigidbody playerRB) : base(owner)
        {
            CreateStates(playerRB);
            SetOwner();
        }

        private void CreateStates(Rigidbody playerRB)
        {
            AddState(PlayerState.Idle, new IdleState());
            AddState(PlayerState.Move, new MoveState(playerRB));
            AddState(PlayerState.Dead, new DeadState());
        }
    }

    public enum PlayerState
    {
        Idle,
        Move,
        Dead,
    }
}