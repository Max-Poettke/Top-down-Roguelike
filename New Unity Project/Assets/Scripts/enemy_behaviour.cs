using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    GameObject Player;
    public float speed = 1f;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move(){
        target = new Vector2(Player.transform.position.x, Player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Projectile") || col.CompareTag("TeleSplosion")){
            Destroy(gameObject);
        }
    }
}
