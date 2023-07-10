using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] private float _speed = 5.0f;
    [Range(0, 50)]
    [SerializeField] private float _turnSpeed = 2.0f;

    private PlayerInputActions playerInputActions;
    private InputAction movement;
    

    private void Awake()
    {
        playerInputActions = new();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player1.Movement;
        movement.Enable();
        
        //playerInputActions.Player1.
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player1.Movement.Disable();
    }

    private void Update()
    {
        Debug.Log($"Movement Values: {movement.ReadValue<Vector2>()}");
    }

    /*Vector3 forwardInput = playerInputActions.Player1.Movement.ReadValue<Vector3>();

       if (forwardInput.x > 0 || forwardInput.y > 0 || forwardInput.z > 0)
       {
           Debug.Log($"input: {forwardInput}");
       
           transform.Translate(forwardInput * Time.deltaTime * _speed);
       }*/
    
    /*
    public void HandleRotationMove(InputAction.CallbackContext context)
    {
        float horizontalInput = 0f;
        transform.Rotate(Vector3.up, _turnSpeed * horizontalInput * Time.deltaTime);
    }*/

    /*public void HandleForwardMove(InputAction.CallbackContext context)
    {
        float forwardInput = 0f;
        Debug.Log(context);
        
        if (context.performed)
        {
            Debug.Log(context.ReadValue<float>());
            transform.Translate(Vector3.forward * Time.deltaTime * _speed * forwardInput);
        }
    }*/
}
