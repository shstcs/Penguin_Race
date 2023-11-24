using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float smoothSpeed = 0.125f;
    private Vector3 offset;
    private void LateUpdate()
    {
        //Vector3 desiredPosition = player.transform.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        //transform.LookAt(player.transform);
    }
}
