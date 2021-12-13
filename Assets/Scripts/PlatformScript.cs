using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player) {player.transform.parent = transform;}
        Debug.Log("Collider Entered");
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider col)
    {
        player.transform.parent = null;
    }
}
