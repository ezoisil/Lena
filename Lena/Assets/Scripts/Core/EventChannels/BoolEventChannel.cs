using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{

    public class BoolEventChannel : EventChannelBase
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }

}
