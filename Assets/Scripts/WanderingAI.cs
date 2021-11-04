using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;


    //
    [SerializeField] private GameObject _fireballPrefab;
    private GameObject _fireball;
    //

    private void Start()
    {
        _alive = true;
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    void Update()
    {
        if (!_alive) return;

        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            //
            GameObject go = hit.transform.gameObject;
            if (go.CompareTag("Player"))
            {
               // PlayerCharacter player = go.GetComponent<PlayerCharacter>();
               if (_fireball == null)
                {
                    _fireball = Instantiate<GameObject>(_fireballPrefab);
                    //_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.position = transform.TransformPoint(new Vector3(0.0f, 0.0f, 1.5f));
                    _fireball.transform.rotation = transform.rotation;
                }
               
            } else if (go.CompareTag("Wall") && hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}

