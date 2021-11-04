using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour {
private Animator puerta;
private bool open;
void Start() {
puerta = GetComponent<Animator>();
open = puerta.GetBool("isOpen");
}
public void Operate() {
open = !open;
puerta.SetBool("isOpen", open);
}
}
