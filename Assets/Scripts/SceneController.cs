using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    void Update()
    {
        if (_enemy == null)
        {   // �OJO!
            _enemy = Instantiate<GameObject>(enemyPrefab); // instanciar si no hab�a un enemigo
            _enemy.transform.position = transform.position;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
