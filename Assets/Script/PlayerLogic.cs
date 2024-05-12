using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float characterSpeed = 5f;
    [SerializeField] private Transform cameraTransform; 
    public float playerPositionX;
    public float playerPositionY;
    public Vector3 playerPosition;
    [SerializeField]
    public GameObject grenade;
    [SerializeField]
    private float spawnDistance = 2f;
    [SerializeField]
    private float launchForce = 15f;
    private GameObject vie;
    private TextMeshProUGUI vieText;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float positionPlayerInitiale;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        vie = GameObject.Find("LifePoints");
        vieText = vie.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerShooting();
        throwGrenade();
        playerPositionUpdate();
    }

    public void playerPositionUpdate(){
        // la position du joueur
        playerPosition = transform.position;

        // Mettre à jour les valeurs de playerPositionX et playerPositionY
        playerPositionX = playerPosition.x;
        playerPositionY = playerPosition.y;
    }

    private void playerMovement(){
        // Capture les entrées du joueur
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        // Transforme les axes de mouvement en fonction de la direction de la caméra
        Vector3 move = cameraTransform.right * input.x + cameraTransform.forward * input.z;

        move.y = 0;

        // Déplace le joueur selon la direction transformée
        characterController.Move(move * Time.deltaTime * characterSpeed);
    }

    private void playerShooting(){
        //Tirer clic gauche
         if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

                // Headshot
                if(hit.collider.gameObject.name == "Tete" || hit.collider.gameObject.name == "YeuxDroit" || hit.collider.gameObject.name == "YeuxGauche")
                {
                    GameManager.instance.headShot();
                }
                // BodyShot
                if(hit.collider.gameObject.name == "Ennemi")
                {
                    GameManager.instance.bodyShot();
                }

                // Le reste du coprs
                if(hit.collider.gameObject.name == "Corps" || hit.collider.gameObject.name == "MainDroite" || hit.collider.gameObject.name == "MainGauche")
                {
                    GameManager.instance.otherPartShot();
                } 
            }
            else
            {
                Debug.Log("Raté");
            }
        }
    }

    private void throwGrenade()
    {
        GameManager.instance.lancerGrenade();
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

    public void playerTakeDamage(float anyDamage)
    {
        // Calcul du dommage
        float damage = anyDamage;
        Debug.Log($"Dommage: {damage}");

        // Appliquer le dommage à la santé actuelle
        currentHealth -= damage;
        //Debug.Log($"Santé actuelle: {currentHealth}");

        // Empêcher la santé de tomber en dessous de zéro
        currentHealth = Mathf.Max(0, currentHealth);

        // Update les vies
        if (vieText != null)
        {
            vieText.text = $"{currentHealth}/{maxHealth}";
        }
        if(currentHealth == 0)
        {
            GameManager.instance.onPlayerDeath();
        }
    }
}
