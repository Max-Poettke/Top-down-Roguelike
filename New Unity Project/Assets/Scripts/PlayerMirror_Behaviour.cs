using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMirror_Behaviour : MonoBehaviour
{
    private GameObject AttachedPlayer;
    public float hp;

    void Start()
    {
        AttachedPlayer = GameObject.FindGameObjectWithTag("Player");
        hp = AttachedPlayer.GetComponent<PlayerMovement>().playerHp;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Enemy")){
            hp --;
            Vector3 forceDirection = (transform.position - col.transform.position).normalized;
            forceDirection.z = 0f;
            AttachedPlayer.transform.position = AttachedPlayer.transform.position + forceDirection;
            if (hp <= 0){
                Destroy(AttachedPlayer);
                }
        }
    }
}
