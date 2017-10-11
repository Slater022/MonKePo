using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CombatTrigger : MonoBehaviour {

    GameObject player;
    private bool isTriggered;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            TriggerCombat();
        }
    }


    void OnTriggerExit(Collider other) {
    }


    void Update() {
    }


    void TriggerCombat() {
        // Combat !!
        if (!isTriggered) {
            isTriggered = true;
            Debug.Log("combat!");
            if (SceneManager.GetActiveScene().name == "LevelTest2") {
                SceneManager.LoadScene("LevelTest", LoadSceneMode.Single);
            } else {
                SceneManager.LoadScene("LevelTest2", LoadSceneMode.Single);
            }

        }


    }
}
