using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Scene_Management
{

    public class GameScene : ScriptableObject
    {
        public GameSceneType SceneType;
        public AssetReference SceneReference;
    }

}
