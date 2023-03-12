using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    private List<MeshRenderer> _meshesInTrigger = new List<MeshRenderer>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController p))
        {
            MeshRenderer m = p.GetComponentInChildren<MeshRenderer>();
            _meshesInTrigger.Add(m);
            m.material.SetFloat("_Suck_Amount",.5f);
            m.material.SetVector("_Target_Point",transform.position);
        }
    }
}
