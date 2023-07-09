using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private GameObject _objectToFollow = null;

    [Tooltip("Offset Camera view from player vehicle")]
    public Vector3 cameraOffset = new Vector3(0, 0, 0);

    private void LateUpdate()
    {
        // offset camera to see better
        transform.position = _objectToFollow.transform.position + cameraOffset;
    }
}