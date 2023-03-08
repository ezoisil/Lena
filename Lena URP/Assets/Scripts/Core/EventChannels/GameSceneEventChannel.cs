using Core.Scene_Management;
using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{

    [CreateAssetMenu(menuName = "Events /Game Scene Event Channel")]

    public class GameSceneEventChannel : ScriptableObject
    {
        public UnityAction<GameScene> OnEventRaised;

        public void RaiseEvent(GameScene value)
        {
            OnEventRaised?.Invoke(value);
        }
    }

}
