using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;

    // Use this for initialization
    void Start() {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        // Verif Si on click & si on ne click pas sur l'interface
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            this.GetInteraction();
        }

    }

    void GetInteraction() {
        // recup d'un raycast partant de la caméra à la postion de la souris
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        // si çà touche on output les infos sur interactionInfo 
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)) {
            //recup du GO touché
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object") {
                //si c'est un objet qu'on peut interagir ( avec un tag ) 
                Debug.Log("Interactable Interracted");
            }else{
                // sinon on veut bouger + pathfinding
                playerAgent.destination = interactionInfo.point;
            }   
        }
    }
}
