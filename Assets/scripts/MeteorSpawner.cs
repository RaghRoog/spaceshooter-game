using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteors;
    public Vector2 spawningRange = new Vector2(7, 4);

    private void Start() {
        InvokeRepeating("SpawnMeteor", 0f, 0.5f);
    }


    private void SpawnMeteor() {
        float xCord = Random.Range(-spawningRange.x, spawningRange.x);
        float yCord = spawningRange.y;
        int randIndex = Random.Range(0, meteors.Length); 
        GameObject meteor = Instantiate(meteors[randIndex], new Vector2(xCord, yCord), Quaternion.identity);
        float scale = Random.Range(0.7f, 1.3f);
        meteor.transform.localScale = new Vector3(scale, scale, 1);
        float rotation = Random.Range(-360f, 360f);
        meteor.transform.Rotate(Vector3.forward, rotation);
    }
}
