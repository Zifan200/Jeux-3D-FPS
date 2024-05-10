using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLogic : MonoBehaviour
{
    public float grenadeDamage = 100f; // Dégâts de la grenade
    public bool hasBeenThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetThrown();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si la collision est avec un ennemi
        if (hasBeenThrown == true) 
        {
            if(collision.gameObject.name == "Ennemi"){
                GameManager.instance.grenadeExplosion();
            }
            // Détruire la grenade après la collision
            Destroy(gameObject);
        }
    }

     public void SetThrown()
    {
        hasBeenThrown = true;
    }
}
