using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;  // en el editor, referencia a la cámara
    public float rotationSpeed = 15.0f;

    public float moveSpeed = 6.0f;
    private CharacterController _charController;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;

    private float _vertSpeed;

    private ControllerColliderHit _contact;

    private Animator _animator;



    private void Start()
    {

        _animator = GetComponent<Animator>();

        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput;
            movement.z = vertInput;
            movement = Vector3.ClampMagnitude(movement, 1.0f);
            movement *= moveSpeed;

            Quaternion rot = Quaternion.Euler(0, target.eulerAngles.y, 0);
            movement = rot * movement;
            //transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotationSpeed * Time.deltaTime);
        }

        _animator.SetFloat("Speed", movement.sqrMagnitude);
        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        ////
        //if (_charController.isGrounded)
        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;

                _animator.SetBool("Jumping", false);
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }

            if (_contact != null) {
                _animator.SetBool("Jumping", true);
            }

            if (_charController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                    movement += _contact.normal * moveSpeed;
                }
            }
        }
        movement.y = _vertSpeed;

        ////
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }



    private void OnControllerColliderHit
          (ControllerColliderHit hit)
    {
        _contact = hit;
    }


    private void OnDrawGizmos()
    {
        if (_charController != null)
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (_charController.height + _charController.radius) / 1.9f);
        }
    }
}
