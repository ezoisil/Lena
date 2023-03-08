using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{
    [CreateAssetMenu(menuName = "Events /Bool Event Channel")]

    public class BoolEventChannel : EventChannelBase
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }

}
