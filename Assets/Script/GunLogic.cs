using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject pistol;
    private GameObject subMachineGun;
    private GameObject assaultRiffle;
    public GameObject pistolPlayer;
    public GameObject subMachineGunPlayer;
    public GameObject assaultRifflePlayer;
    public List<GameObject> gunList = new List<GameObject>();
    private bool isPistol = true;
    private bool issubMachineGunPlayer = false;
    private bool isassaultRifflePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        pistol = GameObject.Find("Pistol");
        subMachineGun = GameObject.Find("SMG");
        assaultRiffle = GameObject.Find("AssaultRiffle");

        GameObject pistolObject = GameObject.FindWithTag("PistolPlayer");
        if (pistolObject != null)
        {
            pistolPlayer = pistolObject;
        }

        GameObject smgObject = GameObject.FindWithTag("SMGPlayer");
        if (smgObject != null)
        {
            subMachineGunPlayer = smgObject;
            subMachineGunPlayer.SetActive(false);
        }

        GameObject rifleObject = GameObject.FindWithTag("AssaultRifflePlayer");
        if (rifleObject != null)
        {
            assaultRifflePlayer = rifleObject;
            assaultRifflePlayer.SetActive(false);
        }
        gunList.Add(pistol);
        afficherListe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if(gameObject.name == "SMG")
            {
                addGun(subMachineGun);
                Debug.Log(other.gameObject.name + " picked up SMG");
                afficherListe();
            } 

            if(gameObject.name == "AssaultRiffle")
            {
                addGun(assaultRifflePlayer);
                Debug.Log(other.gameObject.name + " picked up Assault Riffle");
                afficherListe();
            }
            Destroy(gameObject);
        }
    }
    void addGun(GameObject gun)
    {
        if(gun.name == "SMG" && !gunList.Contains(subMachineGunPlayer))
        {
            gunList.Add(subMachineGun);
        }
        if(gun.name == "AssaultRiffle" && !gunList.Contains(assaultRiffle))
        {
            gunList.Add(assaultRiffle);
        }   
    }
    void afficherListe()
    {
        foreach(GameObject gun in gunList)
        {
            Debug.Log(gun.name);
        }
    }
}
