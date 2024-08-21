using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20;
    [SerializeField]
    private float _turnSpeed = 5;
    [SerializeField]
    private float _horizontalInput;
    [SerializeField]
    private float _forwardInput;

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        transform.Rotate(Vector3.up, _horizontalInput * _turnSpeed * Time.deltaTime);
    }
}
