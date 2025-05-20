using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "UISO", menuName = "ScriptableObjects/UISO")]
    public class UISO : ScriptableObject
    {
        public Vector3 screenOffsetPosition;
        public float titleAnimationDelay;
        public Vector3 originalScale;
        public float scaleFactor;
        public float animationTime;
    }
}