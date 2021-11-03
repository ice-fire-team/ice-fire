using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookPlayer : MonoBehaviour
{
    public enum RotationAxes

    { // Movimiento rat�n
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHor = 9.0f;    // velocidad
    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;   // rango de rotaci�n vertical
    public float maxVert = 45.0f;

    private float _rotationX = 0;  // cabeceo (pitch) actual 

    [SerializeField] private CameraManager cameraManager;
    

    private Player player;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true; // impide que el motor de f�sica rote la c�mara

        player = GetComponentInParent<Player>();
    }

    void Update()
    {
       
        if(player.ID != cameraManager.CamIndex)return;

        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y; // mantener el mismo �ngulo de gui�ada (yaw)
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    

    }
}