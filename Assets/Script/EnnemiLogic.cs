using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnnemiLogic : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth = 100f;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 initialPosition;
    [SerializeField] private GameObject player;
    public float stopDistance = 5f;
    [SerializeField]
    private float detectionDistance;
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
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private List<GameObject> listeArmes;
    private float ennemiMunitionActuelle;
    private float ennemiChargeur = 10f;
    private float tempsDeRecharge = 3f;
    [SerializeField]
    private AudioClip recharge;
    private bool isRecharging = false;
    private PlayerLogic playerLogic;

    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        healthBar = GameObject.Find("HP");
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDistance;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.instance.soundVolume;
        ennemiMunitionActuelle = ennemiChargeur;
        playerLogic = player.GetComponent<PlayerLogic>();
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

     public void headShot() {
        // Si le jeu n'est pas en pause, infliger des dégâts à l'ennemi selon le type d'arme utilisé.
        if (GameManager.instance.jeuEnPause == false) {
            if (playerLogic.isPistol) 
            {
                TakeDamage(GameManager.instance.pistolDamage * GameManager.instance.headDamageRatio);
            }
            if(playerLogic.isSubMachineGun)
            {
                TakeDamage(GameManager.instance.submachineGunDamage * GameManager.instance.headDamageRatio);
            }
            if(playerLogic.isAssaultRiffle)
            {
                TakeDamage(GameManager.instance.assaultRiffleDamage * GameManager.instance.headDamageRatio);
            }
        }
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
            if (tempsEcouleDepuisTir >= delaiCadenceTir && !isRecharging)
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
        if (!isDead && ennemiMunitionActuelle > 0)
        {
            // Effet sonore pour le tir
            audioSource.PlayOneShot(tirPistol);

            // Raycast pour tirer sur le joueur
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, (detectionDistance)))
            {
                // Effet spécial smoke
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
                        Instantiate(etincellePrefab, hit.point, Quaternion.identity);
                    }
                    else
                    {
                        Debug.Log("Raté");
                    }
                }
            }
            // Réduire la munition actuelle
            ennemiMunitionActuelle--;
            Debug.Log($"Munition actuelle: {ennemiMunitionActuelle}");
            tempsEcouleDepuisTir = 0;

            if (ennemiMunitionActuelle <= 0)
            {
                StartCoroutine(rechargeMunitionCoroutine());
            }
        }
    }

    IEnumerator rechargeMunitionCoroutine()
    {
        isRecharging = true;
        audioSource.PlayOneShot(recharge);
        yield return new WaitForSeconds(tempsDeRecharge);
        ennemiMunitionActuelle = ennemiChargeur;
        isRecharging = false;
    }

    public void mortEnnemi()
    {
        if (currentHealth <= 0)
        {
            // Instancier le son à la mort de l'ennemi
            GameManager.instance.playScreamSon();

            // Instancier les munitions
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Instancier une arme aléatoire
            int indexArme = Random.Range(0, listeArmes.Count);
            Instantiate(listeArmes[indexArme], transform.position, Quaternion.identity);

            isDead = true;
        
            // Détruire l'ennemi
            Destroy(gameObject);
        }
    }
}
