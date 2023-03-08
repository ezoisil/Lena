using System;
using Save_System;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    public class PlayerSpawnPoint : MonoBehaviour, ISaveable
    {
        [SerializeField]
        private Vector3Variable _defaultSpawnPoint;

        private void Awake()
        {
            _defaultSpawnPoint.Value = transform.position;
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
