using System;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    public class DefaultSpawnPoint : MonoBehaviour
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
    }

}
