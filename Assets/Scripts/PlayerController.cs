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
    //public T<PlayerInputActions> inputActions = null;
    private PlayerInputActions playerInputActions;
    private InputAction movement;
    [SerializeField] private ControlsForPlayer controlsForPlayer;

    private enum ControlsForPlayer
    {
        Player1,
        Player2
    }


    private void Awake()
    {
        playerInputActions = new();
    }

    /// <summary>
    /// Called when this GameObject is enabled
    /// </summary>
    private void OnEnable()
    {
        movement = ChoosePlayer();
        movement.Enable();
    }

    private InputAction ChoosePlayer()
    {
        if (controlsForPlayer == ControlsForPlayer.Player1)
        {
            return playerInputActions.Player1.Movement;
        }

        if (controlsForPlayer == ControlsForPlayer.Player2)
        {
            return playerInputActions.Player2.Movement;
        }

        return playerInputActions.Player1.Movement;
    }

    /// <summary>
    /// Called when this GameObject is Disabled
    /// </summary>
    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player1.Movement.Disable();
    }

    /// <summary>
    /// Update Loop called every frame
    /// </summary>
    private void Update()
    {
        HandleMovement(movement.ReadValue<Vector2>());
    }

    /// <summary>
    /// Handle the player movement. forwards, backwards, rotating left and right.
    /// Translates Y input into Z output, and X input into Rotational movement.
    /// </summary>
    /// <param name="inputMovement">Input Vector2 data, from the New Unity Input System.</param>
    void HandleMovement(Vector2 inputMovement)
    {
        transform.Translate(0, 0, inputMovement.y * Time.deltaTime * _speed);
        transform.Rotate(Vector3.up, _turnSpeed * inputMovement.x * Time.deltaTime);
    }
}