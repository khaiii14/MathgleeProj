using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float Sensivity;
    public float CameraDistance = 2f;
    public LayerMask obstacleMask;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        XMove = LockAxis.x * Sensivity * Time.deltaTime;
        YMove = LockAxis.y * Sensivity * Time.deltaTime;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * XMove);

        HandleCameraCollision();
    }

    void HandleCameraCollision()
    {
        Vector3 desiredCameraPosition = PlayerBody.position - transform.forward * CameraDistance;
        RaycastHit hit;
        
        if (Physics.Raycast(PlayerBody.position, -transform.forward, out hit, CameraDistance, obstacleMask))
        {
            if (hit.collider.CompareTag("Obstacles"))
            {
                transform.position = hit.point + transform.forward * 0.2f;
            }
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}
