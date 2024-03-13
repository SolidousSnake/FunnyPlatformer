using TMPro;
using UnityEngine;

namespace Source.Code.Runtime.MV.Timer
{
    public sealed class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _prefix = "Time: ";
        [SerializeField] private string _format = "{0:00}:{1:00}";
        
        public void SetValue(int minutes, int seconds)
        {
            _label.text = _prefix + string.Format(_format, minutes, seconds);
        }
    }
}