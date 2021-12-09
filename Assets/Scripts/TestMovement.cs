using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Vector3 mov;
    [SerializeField]
    private float vel;

    CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mov.x = Input.GetAxis("Vertical");
        mov.z = Input.GetAxis("Horizontal");
        CC.Move(mov*Time.deltaTime*vel);
    }
}
