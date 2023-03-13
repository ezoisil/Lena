using Core.EventChannels;
using Core.Scene_Management;
using UnityEngine;

namespace Gameplay
{

    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameScene _sceneToLoad;
        [SerializeField] private LoadEventChannel _channel;
        private void OnTriggerEnter(Collider other)
        {
            SceneLoadingSettings settings = new SceneLoadingSettings(_sceneToLoad, true, true);
            _channel.RaiseEvent(settings);
        }
    }

}
