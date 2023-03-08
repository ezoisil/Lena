using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core.EventChannels;
using Core.Scene_Management;
using Core.Scriptable_Variables;
using UnityEngine;

namespace Save_System
{

    /// <summary>
    /// This component provides the interface to the saving system. It provides
    /// methods to save and restore a scene.
    ///
    /// This component should be created once and shared between all subsequent scenes.
    /// </summary>
    public class SavingSystem : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;

        [Header("Listening to")]
        [SerializeField] private GameSceneEventChannel _onSceneReady;

        [Header("Broadcasting on")]
        [SerializeField] private VoidEventChannel _onLoad;

        private StringVariable _saveFile;

        private void OnEnable()
        {
            _onSceneReady.OnEventRaised += LoadCurrentScene;
        }

        private void OnDisable()
        {
            _onSceneReady.OnEventRaised -= LoadCurrentScene;
        }

        /// <summary>
        /// Save the current scene to the provided save file.
        /// </summary>
        public void Save(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            CaptureState(state);
            SaveFile(saveFile, state);
        }

        /// <summary>
        /// Delete the state in the given save file.
        /// </summary>
        public void Delete(string saveFile)
        {
            File.Delete(GetPathFromSaveFile(saveFile));
        }

        // PRIVATE

        private void Load(string saveFile)
        {
            RestoreState(LoadFile(saveFile));
        }

        //TODO: fix
        private void LoadCurrentScene(GameScene gameScene)
        {
            if (gameScene.SceneType == GameSceneType.Location)
                Load(_saveFile.Value);
        }

        private Dictionary<string, object> LoadFile(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }

        private void SaveFile(string saveFile, object state)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.GetUniqueIdentifier()] = saveable.CaptureState();
            }

            state["lastSceneAssetReference"] = _sceneLoader.GetCurrentlyLoadedScene();
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                string id = saveable.GetUniqueIdentifier();
                if (state.ContainsKey(id))
                {
                    saveable.RestoreState(state[id]);
                }
            }
            _onLoad.RaiseEvent();
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }

}
