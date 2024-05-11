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
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        detectionJoueur();
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
    }

    public void detectionJoueur()
{
    // Distance entre l'ennemi et le joueur
    float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

    // Vérifier si le joueur est suffisamment proche
    if (distanceToPlayer < distanceThreshold)
    {
        pourSuivreJoueur();
        tirerJoueur();
    }
    else
    {
        retourPositionInitiale();
    }
}

    public void retourPositionInitiale()
    {
        // Si le joueur n'est pas détecté, retourner à la position initiale
        agent.SetDestination(initialPosition);
    }

    private void pourSuivreJoueur()
    {
        // Définir la position de destination de l'agent sur celle du joueur au démarrage
        agent.SetDestination(playerTransform.position);
    }
    public void tirerJoueur()
    {
        // Raycast pour tirer sur le joueur
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            Debug.Log($"Touché: {hit.transform.name}");
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Joueur touché");
            }
        }
    }
}
