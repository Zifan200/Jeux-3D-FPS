using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLogic : MonoBehaviour
{
    public float grenadeDegat = 100f; // Dégâts de la grenade
    public bool hasBeenThrown = false;
    public float damageRadius = 2f;
    public float totalGrenadeDamage = 0f;
    public float distance = 0f;
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
        if (hasBeenThrown)
        {
            if (collision.gameObject.CompareTag("Ennemi"))
            {
                // Calculer la distance entre la grenade et l'ennemi
                distance = Vector3.Distance(transform.position, collision.transform.position);

                // Si la distance est inférieure ou égale au rayon de dégâts
                if (distance <= damageRadius)
                {
                    grenadeDamage(collision);
                    // Appliquer les dégâts à l'ennemi
                    collision.gameObject.GetComponent<EnnemiLogic>().TakeDamage(totalGrenadeDamage);
                }
            }
            // Détruire la grenade après la collision
            Destroy(gameObject);
        }
    }

    public void SetThrown()
    {
        hasBeenThrown = true;
    }

    public void grenadeDamage(Collision collision)
    {
        float distance = Vector3.Distance(transform.position, collision.transform.position);
        totalGrenadeDamage = -(grenadeDegat) * distance + 200;
    }
}
