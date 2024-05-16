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
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private AudioClip explosionSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            // Effet pour l'impact de la balle
            Instantiate(explosionPrefab, collision.GetContact(0).point, Quaternion.identity);

            // Instancier l'explosion de la grenade
            audioSource.PlayOneShot(explosionSound);
            // Détruire la grenade après un délai
            float delay = explosionSound.length + 0.1f;
            Invoke("destroyGrenade", delay);
        }
    }

    public void destroyGrenade()
    {
        Destroy(gameObject);
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
