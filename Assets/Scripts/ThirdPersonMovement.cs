using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement:  MonoBehaviour
{

    public CharacterController controller;
    public Transform Camera;

    public bool debug = false;

    public float speed = 6.0f;
    public float turnSpeed = 0.1f;
    float turnVel;
   
    private void Start()
    {

    }
    
    private void Update() 
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (debug)
            Debug.Log(h);

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >=0.12f) 
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg 
                                + Camera.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(
                    transform.eulerAngles.y,
                    targetAngle,
                    ref turnVel,
                    turnSpeed
                );

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }


    }
 
    private void LateUpdate()
    {

    }


}