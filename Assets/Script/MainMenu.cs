using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject menuTitre;
    private GameObject menuPrincipal;
    private GameObject menuJouer;
    private GameObject menuOption;
    // Start is called before the first frame update
    void Start()
    {
        menuPrincipal = GameObject.Find("MenuPrincipal");
        menuTitre = GameObject.Find("MenuTitre");
        menuJouer = GameObject.Find("MenuJouer");
        menuOption = GameObject.Find("MenuOption"); 

        menuPrincipal.SetActive(false); 
        menuJouer.SetActive(false);
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
