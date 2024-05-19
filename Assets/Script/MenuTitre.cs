using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class MenuTitre : MonoBehaviour
{
    [SerializeField]
    private GameObject menuTitre;
    [SerializeField]
    private Button buttonCommencer;
    [SerializeField]
    private TextMeshProUGUI titre;
    private Color colorTitre;
    private Color buttonColor;
    private TextMeshProUGUI buttonText;
    private Color buttonTextColor;
    private Color colorMenu;
    [SerializeField]
    private TextMeshProUGUI auteur;


    // Start is called before the first frame update
    void Start()
    {
        // Initialiser la couleur du titre
        colorTitre = titre.color;
        colorTitre.a = 1; // Couleur initiale (complètement visible)
        titre.color = colorTitre;

        // Initialiser la couleur du bouton
        buttonColor = buttonCommencer.image.color;
        buttonColor.a = 0; // Rendre le bouton invisible au démarrage
        buttonCommencer.image.color = buttonColor;

        // Récupérer le composant TextMeshProUGUI du bouton et initialiser sa couleur
        buttonText = buttonCommencer.GetComponentInChildren<TextMeshProUGUI>();
        buttonTextColor = buttonText.color;
        buttonTextColor.a = 0; // Rendre le texte du bouton invisible au démarrage
        buttonText.color = buttonTextColor;

        // Fade in du titre
        StartCoroutine(FadeInTitre());
    }
    void Update()
    {
        
    }

    // Coroutine pour le fondu du titre
    IEnumerator FadeInTitre()
    {
        float duration = 2f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            colorTitre.a = Mathf.Clamp01(elapsedTime / duration);
            titre.color = colorTitre;
            yield return null;
        }

        colorTitre.a = 1;
        titre.color = colorTitre;

        // Démarrer la coroutine pour le bouton après le fondu du titre
        StartCoroutine(FadeInBouttonCommencer());
    }

    // Coroutine pour le fondu du bouton commencer
    IEnumerator FadeInBouttonCommencer()
    {
        float duration = 2f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonCommencer.image.color = buttonColor;

            buttonTextColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonText.color = buttonTextColor;

            yield return null;
        }

        buttonColor.a = 1;
        buttonCommencer.image.color = buttonColor;

        buttonTextColor.a = 1;
        buttonText.color = buttonTextColor;
    }

    // Méthode pour rendre le menuTitre invisible
    public void MakeMenuInvisible()
    {
        menuTitre.SetActive(false);
    }

    IEnumerator fadeOutBouttonCommencer()
    {
        float duration = 1f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonCommencer.image.color = buttonColor;

            buttonTextColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonText.color = buttonTextColor;

            yield return null;
        }

        buttonColor.a = 0;
        buttonCommencer.image.color = buttonColor;

        buttonTextColor.a = 0;
        buttonText.color = buttonTextColor;
    }
   

    public void onButtonCommencer()
    {
        // Rendre le titre invisible instantanément
        colorTitre.a = 0;
        titre.color = colorTitre;

        // Rendre l'auteur invisible instantanément
        Color colorAuteur = auteur.color;
        colorAuteur.a = 0;
        auteur.color = colorAuteur;

        // Démarrer la coroutine pour faire disparaître le bouton
        StartCoroutine(fadeOutBouttonCommencer());
    }
}
