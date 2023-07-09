using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private GameObject _objectToFollow = null;

    private void Update()
    {
        transform.position = _objectToFollow.transform.position;
    }
}