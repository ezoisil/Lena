using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{
    /// <summary>
    /// This class is used for Events that have no arguments.
    /// </summary>
    
    [CreateAssetMenu(menuName = "Events /Void Event Channel")]
    public class VoidEventChannel : EventChannelBase
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }

}
