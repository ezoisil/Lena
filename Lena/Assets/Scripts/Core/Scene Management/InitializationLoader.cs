using Core.AddressableExtensions;
using Core.EventChannels;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Core.Scene_Management
{

    public class InitializationLoader : MonoBehaviour
    {
        [SerializeField] private GameScene _managersScene;
        [SerializeField] private GameScene _menuScene;

        [SerializeField] private AssetReferenceEventChannel _mainMenuLoadEventChannel;

        private void Start()
        {
            _managersScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
        }

        private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
        {
            _mainMenuLoadEventChannel.LoadAssetAsync<LoadEventChannel>().Completed += LoadMainMenu;
        }

        private void LoadMainMenu(AsyncOperationHandle<LoadEventChannel> obj)
        {
            obj.Result.RaiseEvent(_menuScene, true);

            SceneManager.UnloadSceneAsync(0);
        }
    }

}
