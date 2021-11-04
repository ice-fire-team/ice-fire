using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    //private float timeLastShot;
    private bool canShoot;

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //timeLastShot = -10.0f;
        canShoot = true;
    }

    IEnumerator resetCanShoot()
    {
        yield return new WaitForSeconds(1.0f);
        canShoot = true;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot /*Time.time - timeLastShot > 1.0f*/)
        {
            //timeLastShot = Time.time;
            canShoot = false;
            StartCoroutine(resetCanShoot());

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);

                GameObject go = hit.transform.gameObject;
                ReactiveTarget enemy = go.GetComponent<ReactiveTarget>();
                if (enemy != null)
                {
                    //Debug.Log("TOMA CASTAÑA");
                    enemy.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.layer = 2;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }


    private void OnGUI()
    {
        float size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
