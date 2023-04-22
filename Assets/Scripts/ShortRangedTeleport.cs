using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool shortOnCooldown;
    private float baseCooldown;
    public float shortCooldown;
    public KeyCode m_short;
    //public float shortTeleport;
    public Transform shortTeleTarget;
    public GameObject Player;
    public bool cannotShortTele;


    void Start()
    {
        shortOnCooldown = false;
    }
    void Update()
    {
        ShortTeleport();
    }
    void ShortTeleport()
    {
        if (Input.GetKey(m_short) && shortOnCooldown == false) // Activates Short-Ranged Teleportation
        {
            if (cannotShortTele == false)
            {
                Debug.Log("Short TP was triggered...");
                Player.SetActive(false);
                //playerPos.transform.position += playerPos.transform.forward * shortTeleport; // OLD Teleport
                playerPos.transform.position = shortTeleTarget.position;
                Player.SetActive(true);
                Player.GetComponent<FPSMovement>().m_velocity.y = 0f;
                shortOnCooldown = true;
                baseCooldown = shortCooldown; // Cooldown reset
            }
        }
        if (shortOnCooldown == true) // Cooldown calculations
        {
            baseCooldown -= Time.deltaTime;
            if (baseCooldown <= 0)
            {
                shortOnCooldown = false;
            }
        }
    }
}
