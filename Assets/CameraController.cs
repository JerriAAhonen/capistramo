using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTm;
    [SerializeField] private float speed;

    private void LateUpdate()
    {
        var playerPos = playerTm.position;
        transform.position = Vector3.Slerp(transform.position, playerPos, Time.deltaTime * speed);
    }
}
