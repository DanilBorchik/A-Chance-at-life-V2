using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeredvizhenieIgroka : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce = 7;
    public float Speed = 5;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;
    private int NomerAnimacii;
    private bool Prigok;
    private float timerPrigok;

    private CharacterController _characterController;
    public Animator _animator;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        Pritazhenie();
    }
    void Update()
    {
        Dvizhenie();
        ypravlenieAnimaciami();
    }

    private void ypravlenieAnimaciami()
    {
        _animator.SetInteger("movement", NomerAnimacii);
    }

    private void Dvizhenie()
    {
        NomerAnimacii = 1;
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            NomerAnimacii = 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            NomerAnimacii = 3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            NomerAnimacii = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            NomerAnimacii = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            Prigok = true;
            _animator.SetBool("Jump", true);
        }
        if (Prigok == true)
        {
            timerPrigok += Time.deltaTime;
            if (timerPrigok > 0.7f)
            {
                _fallVelocity = -JumpForce;
                timerPrigok = 0;
                Prigok = false;
            }
        }
    }
    private void Pritazhenie()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            if (Prigok != true)
            {
                _animator.SetBool("Jump", false);
            }
        }
    }
}
