using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
[SerializeField] private Transform target;
public float rotSpeed = 1.5f;
private float _rotY;
private Vector3 _offset;
void Start () {
_rotY = transform.eulerAngles.y;
_offset = target.position - transform.position; // desplazamiento inicial entre cámara y protagonista
}
void LateUpdate () { // Se ejecuta después de todos los Update
float horInput = Input.GetAxis("Horizontal");
if (horInput != 0) {
_rotY += horInput * rotSpeed;
} else {
_rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
}
Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
transform.position = target.position - (rotation * _offset);
transform.LookAt(target); // mirar siempre al protagonista
}
}
