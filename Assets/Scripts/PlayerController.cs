using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 4)]
    public int playerNumber = 0;
    [Range(0, 20)]
    [SerializeField] private float _speed = 5.0f;
    [Range(0, 50)]
    [SerializeField] private float _turnSpeed = 2.0f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + playerNumber);
        forwardInput = Input.GetAxis("Vertical" + playerNumber);

        transform.Translate(Vector3.forward * Time.deltaTime * _speed * forwardInput);
        transform.Rotate(Vector3.up, _turnSpeed * horizontalInput * Time.deltaTime);
    }
}
