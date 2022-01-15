using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KaiKoriController : MonoBehaviour
{
    public bool activePlayer;

    [SerializeField]
    Transform spawnPoint;
    private Vector3 mov, lastPos;
    [SerializeField]
    private float movVel, rotVel, jumpVel; // Velocidad de rotacion y movimiento

    private float grav, vertVel; // Velocidad vertical

    [SerializeField]
    private Transform target;  // en el editor, referencia a la cámara

    private enum playerStates {Idle, Run, Jump, Fall};
    [SerializeField]
    //private playerStates currentState;
    CharacterController CC;
    Rigidbody rb;
    RaycastHit hit;
    public Animator animacion;
    private ControllerColliderHit _contact;
    [SerializeField]
    float rayMargin;

    // Start is called before the first frame update
    void Start()
    {
        
        CC = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        vertVel = 0f;
        grav = Physics.gravity.y;
        //_contact = GetComponent<ControllerColliderHit>();
        // rayMargin = 2.1f;
        //currentState = playerStates.Idle;
    }


    //void UpdateState()
    //{   
        
    //    int layer = 1 << LayerMask.NameToLayer("Default");

    //    bool isHit = Physics.Raycast(transform.position, Vector3.down, out hit, 10f, layer, QueryTriggerInteraction.Ignore);

    //    if (isHit && !hit.collider.isTrigger && hit.distance <= rayMargin) // && hit.transform.tag == "Floor"
    //    {
    //        currentState = playerStates.Idle;
    //        animacion.SetBool("Jumping", false);
    //    }
    //    else
    //    { 
    //        currentState = playerStates.Jump;
    //        animacion.SetBool("Jumping", true);
    //    }


    //    switch (currentState)
    //    {
    //        // Toogle Idle/Run
    //        case playerStates.Idle:
    //        case playerStates.Run:
    //            if (Vector3.Distance(transform.position, lastPos) <= 0.01) { 
    //                currentState = playerStates.Idle;
    //                vertVel = 0f;
    //            }
    //            else {
    //                currentState = playerStates.Run;
    //            }
    //        break;

    //        // Return to Idle
    //        case playerStates.Jump:
    //        if (lastPos.y > transform.position.y){currentState = playerStates.Fall;}
    //        break;
    //        case playerStates.Fall:
                
    //        break;
            
    //    }
        


    //}


    // Update is called once per frame
    void Update()
    {   
        // Dead
        if(transform.position.y <= -20)
        {
            this.transform.position = spawnPoint.transform.position;
            this.transform.forward = spawnPoint.transform.forward;
            vertVel = 0f;
        }
        if (!activePlayer)
        {
            return ;
        }
        // currentState = playerStates.Idle;
        //UpdateState();

        mov.x = Input.GetAxis("Horizontal");
        mov.z = Input.GetAxis("Vertical");
        mov.y = 0f;
        mov = Vector3.ClampMagnitude(mov, 1.0f);
        //mov *= movVel;
        
        Quaternion rot = Quaternion.Euler(0f, target.eulerAngles.y, 0f);
        mov = rot * mov;
        //transform.rotation = Quaternion.LookRotation(movement);
        if (mov != Vector3.zero)
        {
            Quaternion direction = Quaternion.LookRotation(mov);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotVel*Time.deltaTime);
        }

        animacion.SetFloat("Speed", mov.sqrMagnitude);
        bool hitGround = false;
        RaycastHit hit;
        if (vertVel < 0 && Physics.Raycast(transform.position, Vector3.down *1.1f, out hit))
        {
            float check = (CC.radius) / (4f);
            hitGround = hit.distance <= check;
        }

        ////*
        //if (_charController.isGrounded)
        if (hitGround)
        {
            animacion.SetBool("Air", false);
            if (Input.GetButtonDown("Jump"))
            {
                vertVel = jumpVel;
                animacion.SetBool("Jumping", true);
            }
            else
            {
                vertVel = -1.5f;

                animacion.SetBool("Jumping", false);
            }
        }
        else
        {
            vertVel += grav * Time.deltaTime*0.5f;
            if (vertVel < -10f)
            {
                vertVel = -10f;
            }

            if (_contact != null)
            {
                animacion.SetBool("Air", true);
            }

            if (CC.isGrounded)
            {

                if (Vector3.Dot(mov, _contact.normal) < 0f)
                {
                    mov = _contact.normal * movVel;
                }
                else
                {
                    mov += _contact.normal * movVel;
                }
            }
        }
        //switch (currentState)
        //{
        //    case playerStates.Idle:
        //        if (Input.GetButton("Jump"))
        //        {
        //            vertVel = jumpVel;
        //            currentState = playerStates.Jump;

        //        }

        //        break;
        //    case playerStates.Run:



        //    case playerStates.Jump:
        //        break;
        //    case playerStates.Fall:
        //        vertVel = vertVel + grav * Time.deltaTime;
        //        break;

        //}

        mov.y = vertVel;
        mov *= movVel;

        CC.Move(mov*Time.deltaTime*movVel);
        // rb.velocity = mov*movVel;
        // transform.position += mov * Time.deltaTime * movVel;
        lastPos = transform.position;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }

}
