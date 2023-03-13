using System;
using UnityEngine;

namespace Transform_Effects
{

    public class ContinuousRotation : MonoBehaviour
    {
        [SerializeField] private float _secondsPerRound = 1;
        private void Update()
        {
            transform.Rotate(Vector3.up,1/Time.deltaTime*(360*_secondsPerRound));
        }
    }

}
