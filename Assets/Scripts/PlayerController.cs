using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] private float _speed = 5.0f;
    [Range(0, 50)]
    [SerializeField] private float _turnSpeed = 2.0f;

    private void Update()
    {
        
    }

    public void HandleRotationMove(InputAction.CallbackContext context)
    {
        float horizontalInput = 0f;
        transform.Rotate(Vector3.up, _turnSpeed * horizontalInput * Time.deltaTime);
    }

    public void HandleForwardMove(InputAction.CallbackContext context)
    {
        float forwardInput = 0f;
        Debug.Log(context);
        
        if (context.performed)
        {
            Debug.Log(context.ReadValue<float>());
            transform.Translate(Vector3.forward * Time.deltaTime * _speed * forwardInput);
        }
    }
}
