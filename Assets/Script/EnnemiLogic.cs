using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnnemiLogic : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth = 100f;
    public GameObject healthBar;
    public TextMeshProUGUI healthText;
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 initialPosition;
    [SerializeField] private GameObject player;
    public float stopDistance = 5f;
    public float detectionDistance = 10f;
    [SerializeField]
    public float distanceThreshold;
    private float tempsEcouleDepuisTir = 0f;
    public float delaiCadenceTir = 2.0f;
    private bool playerDetected = false;
    [SerializeField]
    private GameObject smokePrefab;
    [SerializeField]
    private GameObject etincellePrefab;
    [SerializeField]
    private AudioClip tirPistol;
    [SerializeField]
    private AudioClip scream;
    AudioSource audioSource;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        healthBar = GameObject.Find("HP");
        healthText = healthBar.GetComponent<TextMeshProUGUI>();
        healthText.text = $"{currentHealth}/{maxHealth}";
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDistance;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        detectionJoueur();
        tempsEcouleDepuisTir += Time.deltaTime;
    }

    public void TakeDamage(float anyDamage)
    {
        // Calcul du dommage
        float damage = anyDamage;
        Debug.Log($"Dommage: {damage}");

        // Appliquer le dommage à la santé actuelle
        currentHealth -= damage;
        Debug.Log($"Santé actuelle: {currentHealth}");

        // Empêcher la santé de tomber en dessous de zéro
        currentHealth = Mathf.Max(0, currentHealth);

        // Update les vies
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
        mortEnnemi();
    }

    public void detectionJoueur()
    {
        // Distance entre l'ennemi et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Vérifier si le joueur est suffisamment proche
        if (distanceToPlayer < distanceThreshold)
        {
            playerDetected = true;
        
        }
        if (playerDetected)
        {
            pourSuivreJoueur();
            if(tempsEcouleDepuisTir >= delaiCadenceTir)
            {
                // Tirer sur le joueur
                tirerJoueur();
            }
        }
    }
    private void pourSuivreJoueur()
    {
        // Définir la position de destination de l'agent sur celle du joueur au démarrage
        agent.SetDestination(playerTransform.position);
    }
    public void tirerJoueur()
    {
        if(!isDead){
        // Raycast pour tirer sur le joueur
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            // Effet special smoke
            Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
            Instantiate(smokePrefab, spawnPosition, Quaternion.identity);

            // Effet sonore pour le tir
            audioSource.PlayOneShot(tirPistol);

            if (hit.transform.CompareTag("Player"))
            {
             float chanceDeToucher = Random.value;
                if (chanceDeToucher <= 0.33f) // 33% de chance
                {
                    GameManager.instance.onPlayerHit();
                    // Effet pour l'impact de la balle
                    Instantiate(etincellePrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Raté");
                }
            }
        }
        tempsEcouleDepuisTir = 0;
        }
    }

    public void mortEnnemi()
    {
        if (currentHealth <= 0)
        {
            // Effet sonore pour la mort de l'ennemi
            audioSource.PlayOneShot(scream);

            isDead = true;
        
            // Delay pour la destruction de l'ennemi
            float delay = scream.length;
            Invoke("DestroyEnemy", delay);
        }
    }

    private void DestroyEnemy()
    {
        // Détruire l'ennemi
        Destroy(gameObject);
    }
}
