using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wSpell_Behaviour : MonoBehaviour
{

    private GameObject Player;
    public float wSequence;
    public float angleBetween;
    private Vector3 target;
    public float speed;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        target = (target - Player.transform.position).normalized;
        switch (wSequence){
            case 0:
                target.x = (target.x * Mathf.Cos(angleBetween * Mathf.Deg2Rad));
                target.y = (target.y * Mathf.Sin(angleBetween * Mathf.Deg2Rad));
                break;
/*                
            case 1:
                Debug.Log(target);
                return;
                break;
*/
            case 2:
                target.x = (target.x * Mathf.Sin(angleBetween * Mathf.Deg2Rad));
                target.y = (target.y * Mathf.Cos(angleBetween * Mathf.Deg2Rad));
                break;
        }
        Invoke("Die", 0.2f);
    }

    public static Vector3 Rotate(Vector3 v, float degrees){
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;

        v.x = (tx * cos) - (ty * sin);
        v.y = (tx * sin) + (ty * cos);
        return new Vector3(v.x, v.y, 0f);
     }

    void Update(){
        Move();
    }

    void Die(){
        Player.GetComponent<PlayerMovement>().spellCount --;
        Destroy(gameObject);
    }

    void Move(){
        transform.position += target * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border")){
            Player.GetComponent<PlayerMovement>().spellCount --;
            Destroy(gameObject);
        }
    }
}
