using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float leftbound;
    private float rightbound;
    Vector3 PlayerPos;
    Vector3 cameraPos;

    void Start()
    {
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

        leftbound -= cameraWidth / 3f;
        rightbound = cameraWidth / 3f;
    }

    void LateUpdate()
    {
        PlayerPos = target.position;
        cameraPos = transform.position;

        float newLeftBound = cameraPos.x + leftbound;
        float newRightBound = cameraPos.x + rightbound;

        if(PlayerPos.x <= newLeftBound)
        {
            transform.position = new Vector3(PlayerPos.x - leftbound, cameraPos.y, cameraPos.z);
        }

        if (PlayerPos.x >= newRightBound)
        {
            transform.position = new Vector3(PlayerPos.x - rightbound, cameraPos.y, cameraPos.z);
        }
    }
}
