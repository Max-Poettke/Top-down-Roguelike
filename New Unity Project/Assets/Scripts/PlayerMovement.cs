using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerHp = 3f;
    private Vector3 direction;
    public Vector3 target; 
    private Vector3 teleTarget;
    public GameObject qSpell;
    public GameObject wSpell;
    public GameObject explosionPrefab;
    private GameObject wPart;
    public float wOrder;
    public float speed = 2f;
    public float playerScale = 0.2f;
    public float spellCount = 0;
    public float castTime;
    public float qCoolDown = 40f;
    public float wCoolDown = 100f;
    public float eCoolDown = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        stop();
        movePlayer();
        spellQ();
        spellW();
        spellE();
        coolDowns();
    }

    void coolDowns(){
    if (qCoolDown > 0){
        qCoolDown = qCoolDown - 1;
    }
    if (wCoolDown > 0){
        wCoolDown -= 1;
    }
    if (eCoolDown > 0){
        eCoolDown = eCoolDown - 1;
    }
    if (castTime > 0){
        castTime = castTime - 1;
    }
}

    void movePlayer(){
        if (Input.GetMouseButtonDown(1)){
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        direction = (target - transform.position).normalized;
        }
    	
        if (castTime == 0){
         rb.velocity = direction * speed;
//        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        } else if (castTime != 0) {
            rb.velocity = new Vector2(0, 0);
        }

        if (transform.position.x <= target.x + 0.1 &&  transform.position.x >= target.x - 0.1 && transform.position.y <= target.y + 0.1 && transform.position.y >= target.y - 0.1){
            rb.velocity = new Vector2(0,0);
        }
    }
    void stop(){
        if (Input.GetKeyDown(KeyCode.S)){
            target = transform.position;
        }
    }

    void spellQ(){
        if (Input.GetKeyDown(KeyCode.Q) && qCoolDown <= 0f){
            GameObject newSpell = (GameObject)Instantiate (qSpell, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
            spellCount ++;
            qCoolDown = 25f;
            castTime = 6f;
        }
    }

    void spellW(){
        if (Input.GetKeyDown(KeyCode.W) && wCoolDown <= 0f){
            wCoolDown = 150;
            castTime = 10f;
            for (wOrder = 0; wOrder < 3; wOrder++){
                GameObject newSpell = (GameObject)Instantiate(wSpell, transform.position, Quaternion.identity);
                newSpell.GetComponent<wSpell_Behaviour>().wSequence = wOrder;
                spellCount ++;
            }
        }
    }

    void spellE(){
        if (Input.GetKeyDown(KeyCode.E) && eCoolDown <= 0f){
            Debug.Log("Key pressed");
            eCoolDown = 150;
            castTime = 15f; 
            teleTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            teleTarget.z = transform.position.z;
            transform.localScale = new Vector3(1f/10f, 1f/10f, 1f);
            Invoke("teleAnim", 0.25f);
            Invoke("teleSplosion", 0.48f);
            Invoke("teleport", 0.5f);
        }
    }

    void teleAnim(){
        transform.localScale = new Vector3(1f/20f, 1f/20f, 1f);
    }

    Vector3 calculateTarget(Vector3 mousePos){
        target = (mousePos - transform.position).normalized * 5;
        target += transform.position;
        return target;
    }

    void teleSplosion(){
        target = calculateTarget(teleTarget);
        Instantiate(explosionPrefab, target, Quaternion.identity);
        Invoke("telePoof", 0.1f);
    }

    void telePoof(){
        GameObject telesplosionist = GameObject.FindGameObjectWithTag("TeleSplosion");
        Destroy(telesplosionist);
    }

    void teleport(){
        transform.localScale = new Vector3(playerScale, playerScale, 1);
        target = calculateTarget(teleTarget);
        transform.position = target;
        target = transform.position;
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")){
            playerHp --;
            Vector3 forceDirection = (transform.position - col.transform.position).normalized;
            forceDirection.z = 0f;
            transform.position = transform.position + forceDirection;
            if (playerHp <= 0){
                Destroy(gameObject);
                }
        }
    }
}



// spell needs to be instantiated
// spell needs to move
// spell needs to dissapear, when hitting sth or when certain distance is reached
// spell needs to do sth, when "dead"