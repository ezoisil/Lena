using Core.Addressable_Extensions;
using Core.EventChannels;
using UnityEngine;
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
        
        private SceneLoadingSettings _sceneLoadingSettings;

        private void Start()
        {
            _sceneLoadingSettings =
                new SceneLoadingSettings(_menuScene, true, true, _menuScene.SceneType);

            _managersScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadMainMenuEventChannel;
        }

        private void LoadMainMenuEventChannel(AsyncOperationHandle<SceneInstance> obj)
        {
            _mainMenuLoadEventChannel.LoadAssetAsync<LoadEventChannel>().Completed += LoadMainMenu;
        }

        private void LoadMainMenu(AsyncOperationHandle<LoadEventChannel> obj)
        {
            obj.Result.RaiseEvent(_sceneLoadingSettings);

            SceneManager.UnloadSceneAsync(0);
        }
    }

}
