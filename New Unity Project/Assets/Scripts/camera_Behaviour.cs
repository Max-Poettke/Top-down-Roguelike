using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Behaviour : MonoBehaviour
{
    public bool centerKey = false;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        checkToCenter();
        center();
    }

    void center(){
        if (centerKey){
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
        }
    }

    bool checkToCenter(){
        if(Input.GetKeyDown(KeyCode.Z) && centerKey == false){
            Debug.Log(centerKey);
            centerKey = true;
        } else
        if(Input.GetKeyDown(KeyCode.Z) && centerKey == true){
            centerKey = false;
        }
        return centerKey;
    }
}
