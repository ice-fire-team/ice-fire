using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // obliga a que el GameObject tenga cierto componente
public class Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;

    [SerializeField] public CameraManager cameraManager;
    
    [SerializeField] public Player player;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if(player.ID != cameraManager.CamIndex)return;
        
        float deltaX = Input.GetAxis("Horizontal") * speed; // Las teclas asociadas est�n en:
        float deltaZ = Input.GetAxis("Vertical") * speed;   // Edit\Project Settings\Input
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = transform.TransformDirection(movement); // convierte desde el sistema local al global
        _charController.Move(movement * Time.deltaTime); // no movemos el transform para que se calculen
    }						// las colisiones
}

