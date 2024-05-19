using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJouer : MonoBehaviour
{
    [SerializeField]
    private GameObject menuJouer;
    // Start is called before the first frame update
    void Start()
    {
        setMenuJouerInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMenuJouerInvisible()
    {
        menuJouer.SetActive(false);
    }

    public void onButtonJouer()
    {
        menuJouer.SetActive(true);
    }

    public void onButtonRetour()
    {
        menuJouer.SetActive(false);
    }

    public void onButtonNormal()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void onButtonDifficile()
    {
        SceneManager.LoadScene("Level_01");
    }
}
