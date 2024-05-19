using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuJouer : MonoBehaviour
{
    [SerializeField]
    private GameObject menuJouer;
    [SerializeField]
    private TextMeshProUGUI titre;
    private Color titreColor;
    [SerializeField]
    private Button buttonNormal;
    [SerializeField]
    private Button buttonDifficile;
    [SerializeField]
    private Button buttonRetour;
    private Color buttonNormalColor;
    private Color buttonDifficileColor;
    private Color buttonRetourColor;
    [SerializeField]
    private TextMeshProUGUI textNormal;
    [SerializeField]
    private TextMeshProUGUI textDifficile;
    [SerializeField]
    private TextMeshProUGUI textRetour;
    [SerializeField]
    private GameObject buttonMenuJouer;
    [SerializeField]
    private GameObject buttonPositionFinale;
    private Vector3 startPositionInitiale;
    private Vector3 startPositionFinale;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        // Rendre le titre invisible
        startPosition = titre.transform.position;
        titreColor = titre.color;
        titre.color = new Color(titreColor.r, titreColor.g, titreColor.b, 0f);

        // Rendre les boutons "Normal" invisibles au départ
        buttonNormalColor = buttonNormal.image.color;
        buttonNormal.image.color = new Color(buttonNormalColor.r, buttonNormalColor.g, buttonNormalColor.b, 0f);
        textNormal = buttonNormal.GetComponentInChildren<TextMeshProUGUI>();
        textNormal.color = new Color(textNormal.color.r, textNormal.color.g, textNormal.color.b, 0f);

        // Rendre les boutons "Difficile" invisibles au départ
        buttonDifficileColor = buttonDifficile.image.color;
        buttonDifficile.image.color = new Color(buttonDifficileColor.r, buttonDifficileColor.g, buttonDifficileColor.b, 0f);
        textDifficile = buttonDifficile.GetComponentInChildren<TextMeshProUGUI>();
        textDifficile.color = new Color(textDifficile.color.r, textDifficile.color.g, textDifficile.color.b, 0f);

        // Rendre les boutons "Retour" invisibles au départ
        buttonRetourColor = buttonRetour.image.color;
        buttonRetour.image.color = new Color(buttonRetourColor.r, buttonRetourColor.g, buttonRetourColor.b, 0f);
        textRetour = buttonRetour.GetComponentInChildren<TextMeshProUGUI>();
        textRetour.color = new Color(textRetour.color.r, textRetour.color.g, textRetour.color.b, 0f);

        // Initialiser les positions pour l'animation du titre
        startPositionInitiale = buttonMenuJouer.transform.position;
        startPositionFinale = buttonPositionFinale.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeInTitre()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            titreColor.a = Mathf.Clamp01(elapsedTime / duration);
            titre.color = titreColor;
            yield return null;
        }
    }

    IEnumerator FadeOutTitre()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            titreColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            titre.color = titreColor;
            yield return null;
        }

        titreColor.a = 0;
        titre.color = titreColor;
    }

    IEnumerator FadeInButtonNormal()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonNormalColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonNormal.image.color = buttonNormalColor;

            textNormal.color = new Color(textNormal.color.r, textNormal.color.g, textNormal.color.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonNormalColor.a = 1;
        buttonNormal.image.color = buttonNormalColor;

        textNormal.color = new Color(textNormal.color.r, textNormal.color.g, textNormal.color.b, 1);
    }

    IEnumerator FadeOutButtonNormal()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonNormalColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonNormal.image.color = buttonNormalColor;

            textNormal.color = new Color(textNormal.color.r, textNormal.color.g, textNormal.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonNormalColor.a = 0;
        buttonNormal.image.color = buttonNormalColor;

        textNormal.color = new Color(textNormal.color.r, textNormal.color.g, textNormal.color.b, 0);
    }

    IEnumerator FadeInButtonDifficile()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonDifficileColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonDifficile.image.color = buttonDifficileColor;

            textDifficile.color = new Color(textDifficile.color.r, textDifficile.color.g, textDifficile.color.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonDifficileColor.a = 1;
        buttonDifficile.image.color = buttonDifficileColor;

        textDifficile.color = new Color(textDifficile.color.r, textDifficile.color.g, textDifficile.color.b, 1);
    }

    IEnumerator FadeOutButtonDifficile()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonDifficileColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonDifficile.image.color = buttonDifficileColor;

            textDifficile.color = new Color(textDifficile.color.r, textDifficile.color.g, textDifficile.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonDifficileColor.a = 0;
        buttonDifficile.image.color = buttonDifficileColor;

        textDifficile.color = new Color(textDifficile.color.r, textDifficile.color.g, textDifficile.color.b, 0);
    }

    IEnumerator FadeInButtonRetour()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonRetourColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonRetour.image.color = buttonRetourColor;

            textRetour.color = new Color(textRetour.color.r, textRetour.color.g, textRetour.color.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonRetourColor.a = 1;
        buttonRetour.image.color = buttonRetourColor;

        textRetour.color = new Color(textRetour.color.r, textRetour.color.g, textRetour.color.b, 1);
    }

    IEnumerator FadeOutButtonRetour()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonRetourColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonRetour.image.color = buttonRetourColor;

            textRetour.color = new Color(textRetour.color.r, textRetour.color.g, textRetour.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonRetourColor.a = 0;
        buttonRetour.image.color = buttonRetourColor;

        textRetour.color = new Color(textRetour.color.r, textRetour.color.g, textRetour.color.b, 0);
    }
    public void sliderGaucheDroite()
    {
        StartCoroutine(SlideAndAnimateGaucheDroite());
    }

    IEnumerator SlideAndAnimateGaucheDroite()
    {
        // Attendre 0,5 seconde avant de commencer les animations suivantes
        yield return new WaitForSeconds(0.5f);

        yield return SlideCoroutine(startPositionFinale, 1.5f); // Attendre que le glissement soit terminé
    }

    public void sliderDroiteGauche()
    {
        StartCoroutine(SliderAnimationGaucheDroite());
    }

    IEnumerator SliderAnimationGaucheDroite()
    {

        yield return SlideCoroutine(startPositionInitiale, 1.5f); // Attendre que le glissement soit terminé
    }

    IEnumerator SlideCoroutine(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = buttonMenuJouer.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            buttonMenuJouer.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        buttonMenuJouer.transform.position = targetPosition;
    }

    public void onButtonJouer()
    {
        StartCoroutine(FadeInTitre());
        StartCoroutine(FadeInButtonNormal());
        StartCoroutine(FadeInButtonDifficile());
        StartCoroutine(FadeInButtonRetour());
        sliderGaucheDroite();
    }

    public void onButtonRetour()
    {
        StartCoroutine(FadeOutTitre());
        StartCoroutine(FadeOutButtonNormal());
        StartCoroutine(FadeOutButtonDifficile());
        StartCoroutine(FadeOutButtonRetour());
        sliderDroiteGauche();
    }

    public void onButtonNormal()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void onButtonDifficile()
    {
        GameManager.difficulte = "difficile";
        SceneManager.LoadScene("Level_01");
    }
}
