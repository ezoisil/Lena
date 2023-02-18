using Core.Addressable_Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Scene_Management
{

    [CreateAssetMenu(menuName = "Scene Management/Game Scene")]

    public class GameScene : ScriptableObject
    {
        public GameSceneType SceneType;
        public AssetReference SceneReference;
    }

}
