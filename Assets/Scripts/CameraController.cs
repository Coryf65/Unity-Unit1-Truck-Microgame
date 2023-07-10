using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [SerializeField] private Camera _firstPersonCamera = null;
    [SerializeField] private Camera _thirdPersonCamera = null;
    [SerializeField] private GameObject _objectToFollow = null;

    [Tooltip("Offset Camera view from player vehicle")]
    public Vector3 cameraOffset = new Vector3(0, 0, 0);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // which camera is enabled 
            if (_firstPersonCamera.enabled)
            {
                ToggleCamera(_thirdPersonCamera, _firstPersonCamera);
            }
            else
            {
                ToggleCamera(_firstPersonCamera, _thirdPersonCamera);
            }
        }
    }

    private void LateUpdate()
    {
        // offset camera to see better
        transform.position = _objectToFollow.transform.position + cameraOffset;
    }

    /// <summary>
    /// Simple toggle for cameras between First and Third Person. Turns on one camera and off the other.
    /// </summary>
    /// <param name="viewToUse">Camera perspective to enable</param>
    /// <param name="viewToHide">Camera perspective to hide</param>
    private void ToggleCamera(Camera viewToUse, Camera viewToHide)
    {
        viewToUse.enabled = true;
        viewToHide.enabled = false;
    }
}