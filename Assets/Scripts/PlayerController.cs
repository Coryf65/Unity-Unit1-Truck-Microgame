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
    [Tooltip("Select which control scheme will be used to control this player")]
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
        movement = ChoosePlayerControls();
        movement.Enable();
    }

    /// <summary>
    /// Selects which Input Map will be used based on the Unity Editor selection
    /// </summary>
    /// <returns>a InputAction for which players controls to use, defaults to Player 1 if none selected</returns>
    private InputAction ChoosePlayerControls()
    {
        InputAction inputAction = playerInputActions.Player1.Movement;
        
        if (controlsForPlayer == ControlsForPlayer.Player2)
        {
            inputAction = playerInputActions.Player2.Movement;
        }

        return inputAction;
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