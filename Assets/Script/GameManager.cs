using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Toggle checkmarkDocumentA;
    public Toggle checkmarkDocumentB;
    public Toggle checkmarkCle;
    public RawImage iconGrenade;
    public GameObject messageVictory; 
    public GameObject messageObjectMissing;
    public GameObject messageDefaite;
    public GameObject objetNotFound;
    public TextMeshProUGUI textObjectMissing;
    public List<string> missingItem = new List<string>();
    public List<string> grenadeList = new List<string>();
    public float pistolDamage = 25f;
    public float submachineGunDamage = 10f;
    public float assaultRiffleDamage = 30f;
    public float bodyDamageRatio = 0.25f;
    public float headDamageRatio = 4f;
    private GameObject ennemi;
    private EnnemiLogic ennemiLogic;
    private GameObject timer;
    private TextMeshProUGUI timerText;
    private float timeElapsed = 5f;
    public GameObject tempsEcoule;
    public TextMeshProUGUI tempsEcouleText;
    GrenadeLogic grenadeLogic;
    PlayerLogic playerLogic;
    bool isPlayerDead = false;
    private GameObject menuPause;
    public bool jeuEnPause = false;
    private GameObject BallesActuelles;
    private TextMeshProUGUI ballesActuellesText;
    private GameObject extraBalles;
    public TextMeshProUGUI ballesExtraText;
    private float chargeurMaxPistol = 10;
    public float munitionActuellePistol;
    private float munitionExtra = 10;
    private float extraMaxMunition = 100;
    public RawImage pistolIcon;
    public RawImage subMachineGunIcon;
    public RawImage assaultRiffleIcon;
    public TextMeshProUGUI pistolText;
    public TextMeshProUGUI subMachineGunText;
    public TextMeshProUGUI assaultRiffleText;
    [SerializeField]
    private AudioClip rechargeSon;
    [SerializeField]
    private AudioClip explosionGrenadeSon;
    [SerializeField]
    private AudioClip screamSon;
    AudioSource audioSource;
    private GameObject player;
    private GameObject munition;
    Camera mainCamera;
    private bool isTempsEcoule = false;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
}

    // Start is called before the first frame update
    void Start()
    {
        objetNotFound = GameObject.Find("MessageObjet");
        textObjectMissing = objetNotFound.GetComponent<TextMeshProUGUI>();
        messageDefaite = GameObject.Find("ConditionDefaite");
        ennemi = GameObject.Find("Ennemi");
        ennemiLogic = ennemi.GetComponent<EnnemiLogic>();
        iconGrenade = GameObject.Find("GrenadeIcon").GetComponent<RawImage>();
        grenadeLogic = GameObject.Find("Grenade").GetComponent<GrenadeLogic>();
        playerLogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
        timer = GameObject.Find("Temps");
        timerText = timer.GetComponent<TextMeshProUGUI>();
        tempsEcoule = GameObject.Find("TempsEcoule");
        tempsEcouleText = tempsEcoule.GetComponent<TextMeshProUGUI>();
        menuPause = GameObject.Find("MenuPause");
        BallesActuelles = GameObject.Find("MunitionActuelle");
        ballesActuellesText = BallesActuelles.GetComponent<TextMeshProUGUI>();
        extraBalles = GameObject.Find("MunitionExtra");
        ballesExtraText = extraBalles.GetComponent<TextMeshProUGUI>();
        munitionActuellePistol = chargeurMaxPistol;
        ballesActuellesText.text = "Nombre de balles dans le chargeur: " + munitionActuellePistol + "/" + chargeurMaxPistol;
        ballesExtraText.text = "Nombre de balles supplémentaires: " + munitionExtra;
        Cursor.visible = false;
        pistolIcon = GameObject.Find("PistolIcon").GetComponent<RawImage>();
        subMachineGunIcon = GameObject.Find("SMGIcon").GetComponent<RawImage>();
        assaultRiffleIcon = GameObject.Find("ARIcon").GetComponent<RawImage>();
        pistolText = GameObject.Find("PistolText").GetComponent<TextMeshProUGUI>();
        subMachineGunText = GameObject.Find("SMGText").GetComponent<TextMeshProUGUI>();
        assaultRiffleText = GameObject.Find("ARText").GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        munition = GameObject.Find("Bullet");
        player = GameObject.Find("Player");
        mainCamera = player.GetComponentInChildren<Camera>();
        AudioSource audioSourceMainCamera = mainCamera.GetComponent<AudioSource>();
        AudioClip audioClip = audioSourceMainCamera.clip;

        addItemToList();
        ObjectPasTrouve();
        messagesCacherInitialement();
        iconCacherInitialement();
        tempsEcouleBool();
    }

    // Update is called once per frame
    void Update()
    {
        //Vérifier si le temps est supérieur à 0
        if (timeElapsed >= 1)
        {
            //Décrémenter le temps de Time.deltaTime
            timeElapsed -= Time.deltaTime;

            //Update le temps
            UpdateTimeText();
            UpdateTimeEcouleText();
        }
        if(isPlayerDead || isTempsEcoule)
        {
           onPlayerDeath();
        }
        menuPauseActive();
        reload();
        munitionMax();
        pauseMusic();
        playMusic();
        
    }
    public void pauseMusic()
    {
        if(jeuEnPause == true)
        {
            mainCamera.GetComponent<AudioSource>().Pause();
        }
    }
    public void playMusic()
    {
        if(jeuEnPause == false){
            mainCamera.GetComponent<AudioSource>().UnPause();
        }
    }
    public void tempsEcouleBool()
    {
        if(timeElapsed <= 0)
        {
            isTempsEcoule = true;
        }
    }

    private void addItemToList(){
        missingItem.Add("DocumentA");
        missingItem.Add("DocumentB");
        missingItem.Add("Cle"); 
    }
    private void ObjectPasTrouve()
    {
        checkmarkDocumentA.isOn = false;
        checkmarkDocumentB.isOn = false;
        checkmarkCle.isOn = false;
        iconGrenade.enabled = false;
    }

    public void documentATrouve()
    {
        checkmarkDocumentA.isOn = true;
        missingItem.Remove("DocumentA");
    }

    public void documentBTrouve()
    {
        checkmarkDocumentB.isOn = true;
        missingItem.Remove("DocumentB");
    
    }

    public void cleTrouve()
    {
        checkmarkCle.isOn = true;
        missingItem.Remove("Cle");
    }

    public void grenadeTrouve()
    {
        iconGrenade.enabled = true;
        grenadeList.Add("Grenade");
    }
    public void munitionTrouve()
    {
        munitionExtra += 10;
        ballesExtraText.text = "Nombre de balles supplémentaires: " + munitionExtra;
        munition.SetActive(false);
    }

    public void lancerGrenade(){
        // Lancer granade avec button "g" et si il y a des grenades dans la liste
        if(jeuEnPause == false)
        {
            if(Input.GetKeyDown(KeyCode.G) && grenadeList.Count > 0)
            {
                grenadeList.RemoveAt(0);
                if(grenadeList.Count == 0)
                {
                    iconGrenade.enabled = false;
                }
                playerLogic.instanciateGrenade();
            }
        }
    }

    public void messagesCacherInitialement(){
        messageVictory.SetActive(false);
        messageObjectMissing.SetActive(false);
        messageDefaite.SetActive(false);
        menuPause.SetActive(false);
        subMachineGunText.enabled = false;
        assaultRiffleText.enabled = false;
    }
    public void iconCacherInitialement(){
        subMachineGunIcon.enabled = false;
        assaultRiffleIcon.enabled = false;
    }
    public void messageVictoire(){
        if(checkmarkDocumentA.isOn && checkmarkDocumentB.isOn && checkmarkCle.isOn)
            {
               messageVictory.SetActive(true);

               finDeJeu();
            }
            else
            {
               messageObjetManquant();
            }
    }

    public void messageObjetManquant()
    {
        string message = "Vous devez encore trouver : " + string.Join(", ", missingItem);
        textObjectMissing.text = message;
        messageObjectMissing.SetActive(true);
    }

    public void bodyShot() {
        if (jeuEnPause == false) {
            if (ennemiLogic != null && playerLogic.isPistol) 
            {
                ennemiLogic.TakeDamage(pistolDamage);
            }
            if(ennemiLogic != null && playerLogic.isSubMachineGun)
            {
                ennemiLogic.TakeDamage(submachineGunDamage);
            }
            if(ennemiLogic != null && playerLogic.isAssaultRiffle)
            {
                ennemiLogic.TakeDamage(assaultRiffleDamage);
            }
        }
    }

    public void headShot() {
        if (jeuEnPause == false) {
            if (ennemiLogic != null && playerLogic.isPistol) 
            {
                ennemiLogic.TakeDamage(pistolDamage * headDamageRatio);
            }
            if(ennemiLogic != null && playerLogic.isSubMachineGun)
            {
                ennemiLogic.TakeDamage(submachineGunDamage * headDamageRatio);
            }
            if(ennemiLogic != null && playerLogic.isAssaultRiffle)
            {
                ennemiLogic.TakeDamage(assaultRiffleDamage * headDamageRatio);
            }
        }
    }

    public void otherPartShot() {
        if (jeuEnPause == false) 
        {
            if (ennemiLogic != null && playerLogic.isPistol) 
            {
                ennemiLogic.TakeDamage(pistolDamage * bodyDamageRatio);
            } 
            if(ennemiLogic != null && playerLogic.isSubMachineGun)
            {
                ennemiLogic.TakeDamage(submachineGunDamage * bodyDamageRatio);
            }
            if(ennemiLogic != null && playerLogic.isAssaultRiffle)
            {
                ennemiLogic.TakeDamage(assaultRiffleDamage * bodyDamageRatio);
            }
        }
    }

    public void onPlayerHit() {
        if(jeuEnPause == false)
        {
            if (playerLogic != null) 
            {
                playerLogic.playerTakeDamage(pistolDamage);
            } 
        }
    }

    public void onPlayerDeath() {
        messageDefaite.SetActive(true);
        isPlayerDead = true;
        tempsEcouleBool();
        finDeJeu();
    }

    // Fonction pour mettre à jour le temps du jeu
    void UpdateTimeText()
    {
        // Calculer les minutes et les secondes
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);

        // Formater le temps dans le format MM:SS en utilisant string.Format
        string timeString = string.Format("Temps: {0:00}:{1:00}", minutes, seconds);

        // Mettre à jour le texte du composant Text
        if (timerText != null)
        {
            timerText.text = timeString;
        }
    }

    void UpdateTimeEcouleText()
{
    // Calculer le temps écoulé en secondes
    float tempsEcouleSeconds = Mathf.Abs(Mathf.Floor(timeElapsed) - 90);

    // Formater le temps écoulé en format "SS secondes"
    string timeString = string.Format("Temps écoulé: {0} secondes", tempsEcouleSeconds);

    // Mettre à jour le texte du composant Text
    if (tempsEcouleText != null)
    {
        tempsEcouleText.text = timeString;
    }
}
    void arreterTimer()
    {
        timeElapsed = 0;
    }

    public void finDeJeu(){
        arreterTimer();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        jeuEnPause = true;
    }

    public void onButtonQuitter()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void onButtonReprendre()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        jeuEnPause = false;
        menuPause.SetActive(false);
    }

    public void menuPauseActive()
    {
        //Si appui sur ESC, afficher le menu pause et arrêter le jeu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            jeuEnPause = true;
            menuPause.SetActive(true);
        }
    }
    public void gestionMunition()
    {
        if(munitionActuellePistol > 0 && jeuEnPause == false)
        {
            munitionActuellePistol--;
            ballesActuellesText.text = "Nombre de balles dans le chargeur: " + munitionActuellePistol + "/" + chargeurMaxPistol;
        }
    }

    public void reload()
    {
        if(Input.GetKeyDown(KeyCode.R) && munitionExtra > 0 && !jeuEnPause)
        {
            // Son de rechargement
            audioSource.PlayOneShot(rechargeSon);

            // Calculer le nombre de balles supplémentaires nécessaires pour remplir le chargeur
            float ballesSupplementaires = chargeurMaxPistol - munitionActuellePistol;

            // Vérifier si le nombre de balles supplémentaires est supérieur à celles disponibles
             if (ballesSupplementaires > munitionExtra)
            {
                // ajouter toutes les munitions supplémentaires restantes
                ballesSupplementaires = munitionExtra;
            }

            // Mettre à jour le nombre de balles dans le chargeur et les balles supplémentaires
            munitionActuellePistol += ballesSupplementaires;
            munitionExtra -= ballesSupplementaires;

            // Mettre à jour les textes affichant les informations sur les balles
            ballesActuellesText.text = "Nombre de balles dans le chargeur: " + munitionActuellePistol + "/" + chargeurMaxPistol;
            ballesExtraText.text = "Nombre de balles supplémentaires: " + munitionExtra;
        }
    }
    public void munitionMax()
    {
       if(munitionExtra > extraMaxMunition)
        {
            munitionExtra = extraMaxMunition;
        }
    }

    public void playScreamSon()
    {
        audioSource.PlayOneShot(screamSon);
    }
    public void playExplosionGrenadeSon()
    {
        audioSource.PlayOneShot(explosionGrenadeSon);
    }
}
