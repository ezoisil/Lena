using Core.Scene_Management;
using UnityEngine;
using UnityEngine.Events;

namespace Core.EventChannels
{

    public class LoadEventChannel : EventChannelBase
    {
        public UnityAction<SceneLoadingSettings> OnLoadingRequested;

        public void RaiseEvent(SceneLoadingSettings sceneLoadingSettings)
        {
            if (OnLoadingRequested != null)
            {
                OnLoadingRequested.Invoke(sceneLoadingSettings);
            }
            else
            {
                Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                                 "Check why there is no SceneLoader already present, " +
                                 "and make sure it's listening on this Load Event channel.");
            }
        }
    }

}
