using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Vector3 mov;
    [SerializeField]
    private float movVel, rotVel, jumpVel; // Velocidad de rotacion y movimiento

    private float grav, vertVel; // Velocidad vertical
    [SerializeField] private Transform target;  // en el editor, referencia a la cámara

    private enum PlayerStates {Idle, Run, Jump, Fall};
    
    private PlayerStates currentState;
    CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
       
        CC = GetComponent<CharacterController>();
        vertVel = 0f;
        currentState = PlayerStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {   
        // Physics.Raycast();

        currentState = PlayerStates.Idle;



        mov.x = Input.GetAxis("Horizontal");
        mov.z = Input.GetAxis("Vertical");
        mov.y = 0f;
        mov = Vector3.ClampMagnitude(mov, 1.0f);        

        Quaternion rot = Quaternion.Euler(0f, target.eulerAngles.y, 0f);
        mov = rot * mov;
        //transform.rotation = Quaternion.LookRotation(movement);
        Quaternion direction = Quaternion.LookRotation(mov);
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotVel * Time.deltaTime);

        

        switch (currentState)
        {
            case PlayerStates.Idle:
            case PlayerStates.Run:
            if(Input.GetButton("Jump"))
                {
                    vertVel = jumpVel;
                    currentState = PlayerStates.Jump;
                }

            break;

            case PlayerStates.Jump:
                vertVel = vertVel + Physics.gravity.y*Time.deltaTime;
            break;

            case PlayerStates.Fall:
                vertVel = vertVel + Physics.gravity.y*Time.deltaTime;
            break;

        }

        vertVel = Mathf.Max(vertVel + Physics.gravity.y/3*Time.deltaTime, -10);
        mov.y = vertVel;
        mov *= movVel;

        CC.Move(mov*Time.deltaTime*movVel);
    }
}
