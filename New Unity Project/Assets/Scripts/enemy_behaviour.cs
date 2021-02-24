using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    GameObject PlayerMirror;
    public float speed = 1f;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMirror = GameObject.FindGameObjectWithTag("PlayerMirror");
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move(){
        target = new Vector2(PlayerMirror.transform.position.x, PlayerMirror.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Projectile") || col.CompareTag("TeleSplosion")){
            Destroy(gameObject);
        }
    }
}
