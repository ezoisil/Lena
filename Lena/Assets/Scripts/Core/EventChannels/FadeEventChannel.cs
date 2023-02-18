using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{
    [CreateAssetMenu(menuName = "Scene Management/Fade Event Channel")]


    public class FadeEventChannel : EventChannelBase
    {
        public UnityAction<bool, float> OnEventRaised;

        public void FadeIn(float duration)
        {
            Fade(true, duration);
        }

        public void FadeOut(float duration)
        {
            Fade(false, duration);
        }

        private void Fade(bool fadeIn, float duration)
        {
            OnEventRaised?.Invoke(fadeIn,duration);
        }
    }

}
