using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject menuTitre;
    private GameObject menuPrincipal;
    private GameObject menuJouer;
    private GameObject menuQuitter;
    // Start is called before the first frame update
    void Start()
    {
        menuPrincipal = GameObject.Find("MenuPrincipal");
        menuTitre = GameObject.Find("MenuTitre");
        menuJouer = GameObject.Find("MenuJouer");
        menuQuitter = GameObject.Find("MenuQuitter"); 

        menuPrincipal.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonCommencer()
    {
        menuTitre.SetActive(false);
        menuPrincipal.SetActive(true);
        
    }
}
