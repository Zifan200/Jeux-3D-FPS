using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour
{
    private bool isPickedUp = false;
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
            if(gameObject.name == "DocumentA"){
                GameManager.instance.documentATrouve();
            }
            if(gameObject.name == "DocumentB"){
                GameManager.instance.documentBTrouve();
            }
            if(gameObject.name == "Cle"){
                GameManager.instance.cleTrouve();
            }
            if (gameObject.name == "Grenade" || gameObject.name == "Capsule"){
                if(gameObject.name != "Grenade(Clone)")
                {
                    GameManager.instance.grenadeTrouve();
                    isPickedUp = true;
                }            
            }
            Debug.Log($"Le joueur a ramassé: {gameObject.name}");// Affiche l'objet ramasser
            Destroy(gameObject); // L'objet disparaît
        }
    }
}
