using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnnemiLogic : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth = 100f;
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

    public void TakeDamage(float anyDamage)
    {
        // Calcul du dommage
        float damage = anyDamage;
        Debug.Log($"Dommage: {damage}");

        // Appliquer le dommage à la santé actuelle
        currentHealth -= damage;
        Debug.Log($"Santé actuelle: {currentHealth}");

        // Empêcher la santé de tomber en dessous de zéro
        currentHealth = Mathf.Max(0, currentHealth);

        // Update les vies
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
     
}
