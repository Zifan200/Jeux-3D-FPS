using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameManager.instance.messageVictoire();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Supprimer le message lorsque le joueur quitte la porte
            GameManager.instance.messagesCacherInitialement();
        }
    }
}
