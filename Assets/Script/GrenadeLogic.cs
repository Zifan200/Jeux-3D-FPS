using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si le trigger est un ennemi
        if (other.gameObject.name == "Ennemi") 
        {
            GameManager.instance.grenadeExplosion();
            Destroy(gameObject); // Détruire la grenade
        }
    }

}
