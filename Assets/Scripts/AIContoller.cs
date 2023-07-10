using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIContoller : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
