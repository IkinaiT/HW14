using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField, Range(0, 30)]
    private float _speed;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerStatus>().GetSize() == PlayerSize.Big)
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * _speed, ForceMode.Force);
        }
    }
}
