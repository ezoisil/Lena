using System;
using Save_System;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    public class PlayerSpawnPoint : MonoBehaviour, ISaveable
    {
        [SerializeField] private Vector3Variable _defaultSpawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerParent;

        private void Awake()
        {
            _defaultSpawnPoint.Value = transform.position;
        }

        private void Start()
        {
            GameObject player = Instantiate(_playerPrefab,transform.position,transform.rotation,_playerParent);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,.3f);
        }

        public object CaptureState()
        {
            throw new NotImplementedException();
        }

        public void RestoreState(object o)
        {
            throw new NotImplementedException();
        }
    }

}
