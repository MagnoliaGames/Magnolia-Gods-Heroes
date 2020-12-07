﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaSuministro : MonoBehaviour
{
    private GameObject player, erickChild, gun;

    public GameObject[] drops;
    public GameObject molotov, granade;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        erickChild = GameObject.Find("Erick Child");        
    }
    private void Update()
    {
        if (player.GetComponentInParent<PlayerHealth>().vidas > 0 && !player.GetComponent<PlayerMovement>().victoria)
        {
            if (gun == null)
            {
                gun = erickChild.GetComponentInChildren<Gun>().gameObject;              
            }           
        }          
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerTurns"))
        {
            if (gun != null)
            {
                Destroy(gun);
                GameObject drop = drops[Random.Range(0, drops.Length)];
                GameObject ActualDrop = GameObject.Instantiate(drop.gameObject, erickChild.transform);
                player.GetComponent<PlayerMovement>().FindIK(ActualDrop.GetComponent<Gun>().ikRight, ActualDrop.GetComponent<Gun>().ikLeft);
                Destroy(this.gameObject);                
            }
            player.GetComponent<PlayerMovement>().granades.Clear();
            player.GetComponent<PlayerMovement>().granades.AddRange(new List<GameObject>
            {
                granade,
                molotov,
                granade,
                molotov,
            });
        }
    }
}
