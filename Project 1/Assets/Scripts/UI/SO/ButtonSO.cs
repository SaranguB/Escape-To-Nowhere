using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "MainMenuSO", menuName = "ScriptableObjects/MainMenuSO")]
    public class MainMenuSO : ScriptableObject
    {
        public Vector3 screenOffsetPosition;
        public float titleAnimationDelay;
        public Vector3 originalScale;
        public float scaleFactor;
        public float animationTime;
    }
}