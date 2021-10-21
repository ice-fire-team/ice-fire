using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCamera: MonoBehaviour
{
    // camera will follow this object
    [SerializeField] Transform Target;
    [SerializeField] Transform player;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    // different ways of lateupdate
    public int ModeOfOperation = 1;

    // the transition speed when moving
    public float SmoothSpeed = 0.125f;

    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;
 
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
 
    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }
    
    private void Update () 
    {  
    }
 
    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = Target.position + Offset;

        switch(ModeOfOperation){
            default:
            case 1:         
                camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
                break;
            case 2:
                Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, SmoothSpeed);
                camTransform.position = smoothPosition;
                break;
        }

        // update rotation
        transform.LookAt(Target);
    }


}