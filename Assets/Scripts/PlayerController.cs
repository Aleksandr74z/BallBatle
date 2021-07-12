using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private FocalPoint _focalPoint;

    private Rigidbody _playerRb;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * _speed);
    }
}
