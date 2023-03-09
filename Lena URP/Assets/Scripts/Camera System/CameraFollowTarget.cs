using System;
using Scriptable_Variables;
using UnityEngine;

namespace Camera_System
{

    public class CameraFollowTarget : MonoBehaviour
    {
        [SerializeField] private Vector3Variable _targetPosition;

        //TODO: make camera follow when game session has started instead of fixedUpdate.
        private void Update()
        {
            transform.position = _targetPosition.Value;
        }
    }

}
