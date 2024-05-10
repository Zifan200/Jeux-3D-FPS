using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnnemiLogic : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth = 100f;
    public GameObject healthBar;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HP");
        healthText = healthBar.GetComponent<TextMeshProUGUI>();
         healthText.text = $"{currentHealth}/{maxHealth}";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     
}
