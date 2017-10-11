using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour {

    GameObject player;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
			TriggerCombat();
        }
    }


    void OnTriggerExit (Collider other)
    {
    }


    void Update ()
    {
    }


	void TriggerCombat ()
	{
		// Combat !!
		Debug.Log("combat!");
	}
}
