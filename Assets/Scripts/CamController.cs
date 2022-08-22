using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offSet;
    [Range(-100f, 100f)]
    public float smoothFactor;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = targetPosition;
    }
}