using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/player")]
    public class PlayerSO : ScriptableObject
    {
        public float moveSpeed;
        public float turnSpeed;
        public float groundCheckDistance;

        public float boosterSpeed;
    }
}