using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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
    public GameObject pistolPlayer;
    public GameObject subMachineGunPlayer;
    public GameObject assaultRifflePlayer;
    public List<GameObject> gunList = new List<GameObject>();
    public float index = 0;
    public bool isPistol = true;
    public bool isSubMachineGun = false;
    public bool isAssaultRiffle = false;
    [SerializeField]
    public GameObject smokePrefab;
    [SerializeField]
    public GameObject etincellePrefab;
    [SerializeField]
    private AudioClip tirPistol;
    [SerializeField]
    private AudioClip plusDeMunitionSon;
    [SerializeField]
    private AudioClip surfaceSon;
    [SerializeField]
    private AudioClip changerArmeSon;
    [SerializeField]
    public AudioClip ramasserArmeSon;
    AudioSource audioSource;
    private float fireRate = 300f;
    private int burstCount = 3;
    private float timeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = 60f / fireRate;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.instance.soundVolume;
        characterController = GetComponent<CharacterController>();
        vie = GameObject.Find("LifePoints");
        vieText = vie.GetComponent<TextMeshProUGUI>();

        pistolPlayer = GameObject.Find("PistolPlayer");
        subMachineGunPlayer = GameObject.Find("SMGPlayer");
        assaultRifflePlayer = GameObject.Find("AssaultRifflePlayer");

        subMachineGunPlayer.SetActive(false);
        assaultRifflePlayer.SetActive(false);

        gunList.Add(pistolPlayer);
        afficherListe();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerShooting();
        throwGrenade();
        playerPositionUpdate();
        switchGun();
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
        if (Input.GetButtonDown("Fire1") && !GameManager.instance.jeuEnPause)
        {   if(isAssaultRiffle)
            {
                StartCoroutine(FireBurst());
            }
            if(GameManager.instance.munitionActuellePistol > 0 && isPistol)
            {
                // Jouer le son de tir
                audioSource.PlayOneShot(tirPistol);

                // Réduire le nombre de munitions
                GameManager.instance.gestionMunition();

                // Effet special smoke
                Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
                Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
                rayCast();
            }
            if(GameManager.instance.munitionActuelleSMG > 0 && isSubMachineGun)
            {
                // Jouer le son de tir
                audioSource.PlayOneShot(tirPistol);

                // Réduire le nombre de munitions
                GameManager.instance.gestionMunition();

                // Effet special smoke
                Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
                Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
                rayCast();
            }
            if(GameManager.instance.munitionActuelleAR > 0 && isAssaultRiffle)
            {
                // Jouer le son de tir
                audioSource.PlayOneShot(tirPistol);
                StartCoroutine(FireBurst());
                // Réduire le nombre de munitions
                GameManager.instance.gestionMunition();

                // Effet special smoke
                Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
                Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
                rayCast();
            }
            else
            {
                noMoreAmmo();
            } 
        }
    }
    public void balleLogic()
    {
        if(GameManager.instance.munitionActuellePistol > 0 && !GameManager.instance.jeuEnPause && isPistol)
        {
            // Jouer le son de tir
            audioSource.PlayOneShot(tirPistol);

            // Réduire le nombre de munitions
            GameManager.instance.gestionMunition();

            // Effet special smoke
            Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
            Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
        }
        if(GameManager.instance.munitionActuelleSMG > 0 && !GameManager.instance.jeuEnPause && isSubMachineGun)
        {
            // Jouer le son de tir
            audioSource.PlayOneShot(tirPistol);

            // Réduire le nombre de munitions
            GameManager.instance.gestionMunition();

            // Effet special smoke
            Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
            Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
        }
        if(GameManager.instance.munitionActuelleAR > 0 && !GameManager.instance.jeuEnPause && isAssaultRiffle)
        {
            // Jouer le son de tir
            audioSource.PlayOneShot(tirPistol);

            // Réduire le nombre de munitions
            GameManager.instance.gestionMunition();

            // Effet special smoke
            Vector3 spawnPosition = transform.position + transform.forward * 1f + transform.right * 0.5f;
            Instantiate(smokePrefab, spawnPosition, Quaternion.identity);
        }
    }
    public void rayCast()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Effet pour l'impact de la balle
            Instantiate(etincellePrefab, hit.point, Quaternion.identity);
            // Si le raycast touche autre qu'un ennemi, jouer le son de surface
            if(hit.collider.name != "Ennemi")
            {
                audioSource.PlayOneShot(surfaceSon);
            }

            //Debug.Log(hit.collider.gameObject.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            // Headshot
            if(hit.collider.gameObject.name == "Tete" || hit.collider.gameObject.name == "YeuxDroit" || hit.collider.gameObject.name == "YeuxGauche")
            {
                hit.collider.gameObject.GetComponentInParent<EnnemiLogic>().headShot();
            }
            // BodyShot
            if(hit.collider.gameObject.name == "Ennemi" || hit.collider.gameObject.name == "Corps")
                {
                    GameManager.instance.bodyShot();
                }

                // Le reste du coprs
                if(hit.collider.gameObject.name == "MainDroite" || hit.collider.gameObject.name == "MainGauche")
                {
                    GameManager.instance.otherPartShot();
                } 
        }
        else
        {
            Debug.Log("Raté");
        }
    }

    public void noMoreAmmo()
    {
        if(GameManager.instance.munitionActuellePistol == 0 && isPistol)
        {
            audioSource.PlayOneShot(plusDeMunitionSon);
        }
        if(GameManager.instance.munitionActuelleSMG == 0 && isSubMachineGun)
        {
            audioSource.PlayOneShot(plusDeMunitionSon);
        }
        if(GameManager.instance.munitionActuelleAR == 0 && isAssaultRiffle)
        {
            audioSource.PlayOneShot(plusDeMunitionSon);
        }
    }

    IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            yield return new WaitForSeconds(timeBetweenShots);
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
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("SMG"))
        {
            if(!gunList.Contains(subMachineGunPlayer))
            {
                // Ajouter l'arme à la liste des armes
                gunList.Add(subMachineGunPlayer);
                afficherListe();

                Debug.Log(gunList.Count);
            }
            // Son de récupération d'arme
            audioSource.PlayOneShot(ramasserArmeSon);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.StartsWith("AssaultRiffle"))
        {
            if(!gunList.Contains(assaultRifflePlayer))
            {
                // Ajouter l'arme à la liste des armes
                gunList.Add(assaultRifflePlayer);
                afficherListe();

                 Debug.Log(gunList.Count);
            }
            
            // Son de récupération d'arme
            audioSource.PlayOneShot(ramasserArmeSon);
            Destroy(other.gameObject);
        }
       
    }

    void afficherListe()
    {
        string guns = string.Join(", ", gunList.Select(gun => gun.name));
        Debug.Log("Liste des armes : " + guns);
    }

    public void switchGun()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Récupérer le mouvement de la roulette de la souris
        if(GameManager.instance.jeuEnPause == false){

        if (Input.GetKeyDown(KeyCode.E) || scroll > 0)
        {
            // Son de changement d'arme
            audioSource.PlayOneShot(changerArmeSon);

            // Incrémenter l'index pour changer d'arme vers la droite
            index++;
            if(index >= gunList.Count)
            {
                index = 0;
            }
                for(int i = 0; i < gunList.Count;i++)
                {
                    if(index == i)
                    {
                        if (gunList[i] == subMachineGunPlayer)
                        {
                            // Changer l'arme active
                            subMachineGunPlayer.SetActive(true);
                            pistolPlayer.SetActive(false);
                            assaultRifflePlayer.SetActive(false);
                            
                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = false;
                            GameManager.instance.subMachineGunIcon.enabled = true;
                            GameManager.instance.assaultRiffleIcon.enabled = false;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = false;
                            GameManager.instance.subMachineGunText.enabled = true;
                            GameManager.instance.assaultRiffleText.enabled = false;

                            // Changer les booléens
                            isPistol = false;
                            isSubMachineGun = true;
                            isAssaultRiffle = false;

                        }
                        if (gunList[i] == assaultRifflePlayer)
                        {
                            // Changer l'arme active
                            assaultRifflePlayer.SetActive(true);
                            pistolPlayer.SetActive(false);
                            subMachineGunPlayer.SetActive(false);

                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = false;
                            GameManager.instance.subMachineGunIcon.enabled = false;
                            GameManager.instance.assaultRiffleIcon.enabled = true;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = false;
                            GameManager.instance.subMachineGunText.enabled = false;
                            GameManager.instance.assaultRiffleText.enabled = true;

                            // Changer les booléens
                            isPistol = false;
                            isSubMachineGun = false;
                            isAssaultRiffle = true;
                        }
                        if (gunList[i] == pistolPlayer)
                        {
                            // Changer l'arme active
                            pistolPlayer.SetActive(true);
                            subMachineGunPlayer.SetActive(false);
                            assaultRifflePlayer.SetActive(false);

                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = true;
                            GameManager.instance.subMachineGunIcon.enabled = false;
                            GameManager.instance.assaultRiffleIcon.enabled = false;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = true;
                            GameManager.instance.subMachineGunText.enabled = false;
                            GameManager.instance.assaultRiffleText.enabled = false;

                            // Changer les booléens
                            isPistol = true;
                            isSubMachineGun = false;
                            isAssaultRiffle = false;
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) || scroll < 0)
            {
                // Son de changement d'arme
                audioSource.PlayOneShot(changerArmeSon);

                // Décrémenter l'index pour changer d'arme vers l'arrière
                index--;
                if(index < 0) // Si l'index est inférieur à zéro, revenir à la dernière arme dans la liste
                {
                    index = gunList.Count - 1;
                }
        
                for(int i = 0; i < gunList.Count; i++)
                {
                    if(index == i)
                    {
                        if (gunList[i] == subMachineGunPlayer)
                        {
                            // Changer l'arme active
                            subMachineGunPlayer.SetActive(true);
                            pistolPlayer.SetActive(false);
                            assaultRifflePlayer.SetActive(false);

                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = false;
                            GameManager.instance.subMachineGunIcon.enabled = true;
                            GameManager.instance.assaultRiffleIcon.enabled = false;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = false;
                            GameManager.instance.subMachineGunText.enabled = true;
                            GameManager.instance.assaultRiffleText.enabled = false;

                            // Changer les booléens
                            isPistol = false;
                            isSubMachineGun = true;
                            isAssaultRiffle = false;
                        }
                        if (gunList[i] == assaultRifflePlayer)
                        {
                            // Changer l'arme active
                            assaultRifflePlayer.SetActive(true);
                            pistolPlayer.SetActive(false);
                            subMachineGunPlayer.SetActive(false);

                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = false;
                            GameManager.instance.subMachineGunIcon.enabled = false;
                            GameManager.instance.assaultRiffleIcon.enabled = true;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = false;
                            GameManager.instance.subMachineGunText.enabled = false;
                            GameManager.instance.assaultRiffleText.enabled = true;

                            // Changer les booléens
                            isPistol = false;
                            isSubMachineGun = false;
                            isAssaultRiffle = true;
                        }
                         if (gunList[i] == pistolPlayer)
                        {
                            // Changer l'arme active
                            pistolPlayer.SetActive(true);
                            subMachineGunPlayer.SetActive(false);
                            assaultRifflePlayer.SetActive(false);

                            // Changer l'icône de l'arme active
                            GameManager.instance.pistolIcon.enabled = true;
                            GameManager.instance.subMachineGunIcon.enabled = false;
                            GameManager.instance.assaultRiffleIcon.enabled = false;

                            // Changer le texte de l'arme active
                            GameManager.instance.pistolText.enabled = true;
                            GameManager.instance.subMachineGunText.enabled = false;
                            GameManager.instance.assaultRiffleText.enabled = false;

                            // Changer les booléens
                            isPistol = true;
                            isSubMachineGun = false;
                            isAssaultRiffle = false;
                        }
                    }
                }
            }      
        }
    }
    public void playSound()
    {
        audioSource.PlayOneShot(ramasserArmeSon);
    }
}