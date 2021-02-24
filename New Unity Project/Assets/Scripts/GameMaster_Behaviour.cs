using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_Behaviour : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject PlayerMirrorPrefab;
    private GameObject HealthBar;
    private GameObject Player;
    void Start()
    {
        Instantiate(PlayerPrefab, new Vector3(-4.5f, 0f, 0f), Quaternion.identity);
        Player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(PlayerMirrorPrefab, new Vector3(4.5f, 0f, 0f), Quaternion.identity, Player.transform);
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar");
        HealthBar.GetComponent<healthbar_Behaviour>().PlayerMirror = Player;
    }
}
