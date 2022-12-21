using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] Vector3 offSet;

    [SerializeField] public float rotateSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offSet;
    }
}
