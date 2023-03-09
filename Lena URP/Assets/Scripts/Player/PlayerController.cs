using System;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Vector3Variable _playerPosition;

        private void Update()
        {
            _playerPosition.Value = transform.position;
        }
    }

}
