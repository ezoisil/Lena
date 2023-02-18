using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{
    [CreateAssetMenu(menuName = "Scene Management/Fade Event Channel")]


    public class FadeEventChannel : EventChannelBase
    {
        public UnityAction<bool, float, Color> OnEventRaised;

        public void FadeIn(float duration)
        {
            Fade(true, duration, Color.clear);
        }

        public void FadeOut(float duration)
        {
            Fade(false, duration, Color.black);
        }

        private void Fade(bool fadeIn, float duration, Color color)
        {
            OnEventRaised?.Invoke(fadeIn,duration,color);
        }
    }

}
