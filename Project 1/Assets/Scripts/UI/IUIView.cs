using TMPro;
using UnityEditor;
using UnityEngine;

namespace UI
{
    public class IUIView : MonoBehaviour
    {
        public void ScaleButton(GameObject uiObject,Vector3 uiScale, float time)
        {
            LeanTween.scale(uiObject, uiScale, time).setEaseInOutBack();
        }

        public void SetTimerText(float elapsedTime, TextMeshProUGUI timerText)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
