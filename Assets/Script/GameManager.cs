using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Toggle checkmarkDocumentA;
    public Toggle checkmarkDocumentB;
    public Toggle checkmarkCle;
    public RawImage iconGrenade;
    public GameObject messageVictory; 
    public GameObject messageObjectMissing;
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
    PlayerLogic grenadeLogic;
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
        ennemi = GameObject.Find("Ennemi");
        ennemiLogic = ennemi.GetComponent<EnnemiLogic>();
        iconGrenade = GameObject.Find("GrenadeIcon").GetComponent<RawImage>();
        grenadeLogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
        addItemToList();
        ObjectPasTrouve();
        messagesCacherInitialement();
    }

    // Update is called once per frame
    void Update()
    {
    
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

    public void lancerGrenade(){
        // Lancer granade avec button "g" et si il y a des grenades dans la liste
        if(Input.GetKeyDown(KeyCode.G) && grenadeList.Count > 0)
        {
            grenadeList.RemoveAt(0);
            if(grenadeList.Count == 0)
            {
                iconGrenade.enabled = false;
            }
            grenadeLogic.instanciateGrenade();
        }
    }
    public void grenadeExplosion() {
        if (ennemiLogic != null) 
        {
            Debug.Log("Explosion de la grenade");
        } 
    }

    public void messagesCacherInitialement(){
        messageVictory.SetActive(false);
        messageObjectMissing.SetActive(false);
    }
    public void messageVictoire(){
        if(checkmarkDocumentA.isOn && checkmarkDocumentB.isOn && checkmarkCle.isOn)
            {
               messageVictory.SetActive(true);
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
        if (ennemiLogic != null) 
        {
         ennemiLogic.TakeDamage(pistolDamage);
        } 
    }

    public void headShot() {
        if (ennemiLogic != null) 
        {
            ennemiLogic.TakeDamage(pistolDamage * headDamageRatio);
        } 
    }

    public void otherPartShot() {
        if (ennemiLogic != null) 
        {
            ennemiLogic.TakeDamage(pistolDamage * bodyDamageRatio);
        } 
    }
}
