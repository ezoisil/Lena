using System;
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
        [SerializeField] private GameSceneSO _managersScene;
        [SerializeField] private GameSceneSO _menuScene;

        [SerializeField] private AssetReference _menuLoadEventChannel;

        private void Start()
        {
            _managersScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
        }

        private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
        {
            _menuLoadEventChannel.LoadAssetAsync<LoadEventChannelSO>().Completed += LoadMainMenu;
        }

        private void LoadMainMenu(AsyncOperationHandle<LoadEventChannelSO> obj)
        {
            obj.Result.RaiseEvent(_menuScene, true);

            SceneManager.UnloadSceneAsync(0);
        }
    }

}
