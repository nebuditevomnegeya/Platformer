using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    private Vector3 startPos, targetPos;
    public Transform followTarget;
    public float CameraSpeed;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if(followTarget != null)
        {
            targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position)* CameraSpeed;
            transform.position = Vector3.SmoothDamp(
                transform.position, targetPos, ref velocity, 1f, Time.deltaTime);


        }
    }
}
