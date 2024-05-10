using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLogic : MonoBehaviour
{
    [SerializeField]
    public GameObject grenade;
    [SerializeField]
    private float spawnDistance = 2f;
    [SerializeField]
    private float launchForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instanciateGrenade(){
        //décalage vers l'avant
        Vector3 spawnPosition = transform.position + (transform.forward * spawnDistance);
        GameObject GrenadeInstance = Instantiate(grenade, spawnPosition, this.transform.rotation);
        
        // Accéder au Rigidbody de l'instance de la grenade 
        Rigidbody rb = GrenadeInstance.GetComponent<Rigidbody>();
        // Ajout de la force à la grenade
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }


}
