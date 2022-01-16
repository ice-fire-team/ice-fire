using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImagenFondo : MonoBehaviour {

const float ImageWidth = 2000.0f,
TimeOut = 4.0f;
enum SplashStates {Moving, //The splash image is moving
Finish } //Time out, a pressed key
//Go to main menu scene
SplashStates State;
public Vector3 Speed; //Speed for moving the image
float startTime;
Image image;//Reference to the component
Color32 c;

void Start () {
State = SplashStates.Moving;
startTime = Time.time;
image = GetComponent<Image>();
c = image.color;
}

void Update () {
switch (State)
{
case SplashStates.Moving: //The splash image is moving
transform.Translate (Speed * Time.deltaTime);
transform.eulerAngles += new Vector3(0f, 1f, 0f);
if (c.r < 255) c.r += 2;
if (c.g < 255) c.g += 2;
if (c.b < 255) c.b += 2;
image.color = c;
break;

default: break;
}
}
}



