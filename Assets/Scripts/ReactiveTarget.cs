using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public void ReactToHit()
    {
        WanderingAI ai = GetComponent<WanderingAI>();
        if (ai != null)
        {
            ai.SetAlive(false);
        }
        StartCoroutine(Die());
    }


    IEnumerator Die()
    {

        //transform.Rotate(-75, 0, 0);
        //yield return new WaitForSeconds(1.5f);

        const int numSteps = 20;
        for (int i = 0; i < numSteps; i++)
        {
            transform.Rotate(-75.0f/numSteps, 0, 0);
            yield return new WaitForSeconds(1.0f/numSteps);
        }

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

}
