using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [SerializeField] private Camera _firstPersonCamera = null;
    [SerializeField] private Camera _thirdPersonCamera = null;
    [SerializeField] private GameObject _objectToFollow = null;

    [Tooltip("Offset Camera view from player vehicle")]
    public Vector3 cameraOffset = new Vector3(0, 0, 0);
    [Tooltip("Select which control scheme will be used to control this player")]
    [SerializeField] private ControlsForPlayer controlsForPlayer;
    
    private enum ControlsForPlayer
    {
        Player1,
        Player2
    }

    private void Start()
    {
        if (controlsForPlayer == ControlsForPlayer.Player1)
        {
            _firstPersonCamera.rect = new Rect(-0.5f, 0f, 1f, 1f);
            _thirdPersonCamera.rect = new Rect(-0.5f, 0f, 1f, 1f);
        }
        
        if (controlsForPlayer == ControlsForPlayer.Player2)
        {
            _firstPersonCamera.rect = new Rect(0.5f, 0f, 1f, 1f);
            _thirdPersonCamera.rect = new Rect(0.5f, 0f, 1f, 1f);
        }
        
    }

    private void Update()
    {
        if (controlsForPlayer == ControlsForPlayer.Player1 && Input.GetKeyDown(KeyCode.C))
        {
            ToggleCameraView();
        }
        
        if (controlsForPlayer == ControlsForPlayer.Player2 && Input.GetKeyDown(KeyCode.Keypad0))
        {
            ToggleCameraView();
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
    private void ToggleCameraView()
    {
        // which camera is enabled 
        if (_firstPersonCamera.enabled)
        {
            _thirdPersonCamera.enabled = true;
            _firstPersonCamera.enabled = false;
        }
        else
        {
            _thirdPersonCamera.enabled = false;
            _firstPersonCamera.enabled = true;
        }
    }
}