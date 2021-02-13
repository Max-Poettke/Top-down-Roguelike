using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar_Behaviour : MonoBehaviour
{
    public Slider healthBar;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     healthBar.value = Player.GetComponent<PlayerMovement>().playerHp;   
    }
}
