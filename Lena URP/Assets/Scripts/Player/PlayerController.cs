using System;
using Holding;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _rHandTransform;
        [SerializeField] private Transform _lHandTransform;
      

        [SerializeField] private Vector3Variable _playerPosition;

        private void Update()
        {
            _playerPosition.Value = transform.position;
        }
        
    }

}
