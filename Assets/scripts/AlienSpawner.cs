using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject alienPrefab;

    public Vector2 spawningRange = new Vector2(7, 4);

    private GameObject alien;


    private void Update() {
        alien = GameObject.FindGameObjectWithTag("alien");
        if ( alien == null) {
            SpawnAlien();
        }
    }

    private void SpawnAlien() {
        float xCord = Random.Range(-spawningRange.x, spawningRange.x);
        float yCord = spawningRange.y;
        Instantiate(alienPrefab, new Vector2(xCord, yCord), Quaternion.identity);
    }
}
