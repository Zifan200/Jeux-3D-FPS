using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour
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
    if (other.gameObject.name == "Player") // Utiliser un tag au lieu du nom
        {
            if(gameObject.name == "DocumentA"){
                GameManager.instance.documentATrouve();
            }
            if(gameObject.name == "DocumentB"){
                GameManager.instance.documentBTrouve();
            }
            else if(gameObject.name == "Cle"){
                GameManager.instance.cleTrouve();
            }
            Debug.Log($"Le joueur a ramassé: {gameObject.name}");// Affiche l'objet ramasser
            Destroy(gameObject); // L'objet disparaît
        }
    }
}
