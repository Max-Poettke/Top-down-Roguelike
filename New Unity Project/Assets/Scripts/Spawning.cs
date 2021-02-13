using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{


    public float maxRange = 3f;
    public float spawnRate = 100f;
    public GameObject enemy;
    GameObject Player;
    public int i = 0;
    private float radiusX;
    private float radiusY;

    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        spawnEnemy();
        i++;
        if (i >= spawnRate){
            i = 0;
        }
    }

    void spawnEnemy(){
        if (i == 0){
            radiusX = (4 * Mathf.PI * Random.Range(-1f, 1f) * maxRange) / 4f;
            radiusY = (4 * Mathf.PI * Random.Range(-1f, 1f) * maxRange) / 4f;
            if ((((Player.transform.position.x - radiusX) <= -1) ||
                ((Player.transform.position.x - radiusX) >= 1)) && 
                (((Player.transform.position.y - radiusY) <= -1) ||
                ((Player.transform.position.y - radiusY) >= 1))){
                Instantiate(enemy, new Vector3(radiusX, radiusY, 0), Quaternion.identity);
                }
            }
    }





}
