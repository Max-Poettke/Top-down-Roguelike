using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar_Behaviour : MonoBehaviour
{
    public Slider healthBar;
    public GameObject PlayerMirror;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMirror = GameObject.FindGameObjectWithTag("PlayerMirror");
    }

    // Update is called once per frame
    void Update()
    {
     healthBar.value = PlayerMirror.GetComponent<PlayerMirror_Behaviour>().hp;   
    }
}
