using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatControllerr : MonoBehaviour
{
   public FloatingJoystick _joystick;

    public float moveSpeed;
    public float rotateSpeed;

    public Rigidbody _rigidbody;
    private Vector3 _moveVector;

    [SerializeField] private float fuel = 100f;
    [SerializeField] private Slider fuelSlider;
    public float fuelBurnRate = 20f;
    private float currentFuel;

    private bool isMoving = false;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * moveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {

        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}
