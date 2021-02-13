using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qSpell_behaviour : MonoBehaviour
{
    private GameObject Player;
    /*public bool startedRight = false;
    public bool startedLeft = false;
    public bool startedUp = false;
    public bool startedDown = false; */
    public float qSpeed = 10f;
    public Vector3 referance;
    public Vector3 playerReferance;
    public Vector3 normalizedDirection;
    
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        referance = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerReferance = Player.transform.position;
        referance.z = playerReferance.z;
        transform.position = playerReferance;
        normalizedDirection = (referance - playerReferance).normalized;
        Invoke("Die", 0.3f);
    }

    // Update is called once per frame
    void Update(){
        moveSpells();
    }

    void Die(){
        Player.GetComponent<PlayerMovement>().spellCount --;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Enemy") || col.CompareTag("Border")){
            Player.GetComponent<PlayerMovement>().spellCount --;
            Destroy(gameObject);
        }
    }

    void moveSpells(){
        transform.position += normalizedDirection * qSpeed * Time.deltaTime;
    }   
}
