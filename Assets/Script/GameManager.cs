using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Toggle checkmarkDocumentA;
    public Toggle checkmarkDocumentB;
    public Toggle checkmarkCle;

    public static GameManager instance;
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
        ObjectPasTrouve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ObjectPasTrouve()
    {
        checkmarkDocumentA.isOn = false;
        checkmarkDocumentB.isOn = false;
        checkmarkCle.isOn = false;
    }

    public void documentATrouve()
    {
        checkmarkDocumentA.isOn = true;
    }

    public void documentBTrouve()
    {
        checkmarkDocumentB.isOn = true;
    }

    public void cleTrouve()
    {
        checkmarkCle.isOn = true;
    }
}
