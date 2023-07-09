using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _turnSpeed = 2.0f;
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _forwardInput;
    
    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}
