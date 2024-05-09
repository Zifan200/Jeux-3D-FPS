using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
{
    if (other.gameObject.name == "Player")
    {
        Debug.Log("Le joueur a atteint la porte");
        if(GameManager.instance.checkmarkDocumentA.isOn && GameManager.instance.checkmarkDocumentB.isOn && GameManager.instance.checkmarkCle.isOn)
        {
            GameManager.instance.messageVictoire();
        }
    }
}
}
