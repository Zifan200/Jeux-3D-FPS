using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPrincipal;
    [SerializeField]
    private TextMeshProUGUI titre;
    private Color titreColor;
    private Vector3 startPosition;
    [SerializeField]
    private TextMeshProUGUI positionFinaleTitre;
    [SerializeField]
    private Button buttonPlay;
    [SerializeField]
    private Button buttonOption;
    private Vector3 startPositionInitiale;
    private Vector3 startPositionFinale;
    [SerializeField]
    private GameObject buttonMenuPrincipal;
    [SerializeField]
    private GameObject buttonPositionFinale;
    private Color buttonPlayColor;
    private Color buttonOptionColor;
    private TextMeshProUGUI buttonPlayText;
    private TextMeshProUGUI buttonOptionText;


    // Start is called before the first frame update
    void Start()
    {
        // Rendre le titre invisible
        startPosition = titre.transform.position;
        titreColor = titre.color;
        titre.color = titreColor;

        startPositionInitiale = buttonMenuPrincipal.transform.position;
        startPositionFinale = buttonPositionFinale.transform.position;

        // Rendre les boutons "Option" et "Jouer" invisibles au départ avec leur couleur définie
        buttonPlayColor = buttonPlay.image.color;
        buttonPlay.image.color = new Color(buttonPlayColor.r, buttonPlayColor.g, buttonPlayColor.b, 0f);
        buttonPlayText = buttonPlay.GetComponentInChildren<TextMeshProUGUI>();
        buttonPlayText.color = new Color(buttonPlayText.color.r, buttonPlayText.color.g, buttonPlayText.color.b, 0f);
        

        buttonOptionColor = buttonOption.image.color;
        buttonOption.image.color = new Color(buttonOptionColor.r, buttonOptionColor.g, buttonOptionColor.b, 0f);
        buttonOptionText = buttonOption.GetComponentInChildren<TextMeshProUGUI>();
        buttonOptionText.color = new Color(buttonOptionText.color.r, buttonOptionText.color.g, buttonOptionText.color.b, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Méthode pour déplacer le titre vers la position finale en une certaine durée
    void MoveTitreToPosition()
    {
        StartCoroutine(MoveTitleCoroutine(positionFinaleTitre.transform.position, 1.5f));
    }

    // Coroutine pour déplacer le titre progressivement vers la position finale
    IEnumerator MoveTitleCoroutine(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = titre.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            titre.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        titre.transform.position = targetPosition;
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

        titreColor.a = 1;
        titre.color = titreColor;
    }

    IEnumerator FadeInButtonPlay()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonPlayColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonPlay.image.color = buttonPlayColor;

            buttonPlayText.color = new Color(buttonPlayText.color.r, buttonPlayText.color.g, buttonPlayText.color.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonPlayColor.a = 1;
        buttonPlay.image.color = buttonPlayColor;

        buttonPlayText.color = new Color(buttonPlayText.color.r, buttonPlayText.color.g, buttonPlayText.color.b, 1);
    }

    IEnumerator FadeInButtonOption()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonOptionColor.a = Mathf.Clamp01(elapsedTime / duration);
            buttonOption.image.color = buttonOptionColor;

            buttonOptionText.color = new Color(buttonOptionText.color.r, buttonOptionText.color.g, buttonOptionText.color.b, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonOptionColor.a = 1;
        buttonOption.image.color = buttonOptionColor;

        buttonOptionText.color = new Color(buttonOptionText.color.r, buttonOptionText.color.g, buttonOptionText.color.b, 1);
    }

    IEnumerator FadeOutButtonPlay()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonPlayColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonPlay.image.color = buttonPlayColor;

            buttonPlayText.color = new Color(buttonPlayText.color.r, buttonPlayText.color.g, buttonPlayText.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonPlayColor.a = 0;
        buttonPlay.image.color = buttonPlayColor;

        buttonPlayText.color = new Color(buttonPlayText.color.r, buttonPlayText.color.g, buttonPlayText.color.b, 0);
    }

    IEnumerator FadeOutButtonOption()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonOptionColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonOption.image.color = buttonOptionColor;

            buttonOptionText.color = new Color(buttonOptionText.color.r, buttonOptionText.color.g, buttonOptionText.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonOptionColor.a = 0;
        buttonOption.image.color = buttonOptionColor;

        buttonOptionText.color = new Color(buttonOptionText.color.r, buttonOptionText.color.g, buttonOptionText.color.b, 0);
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
        // Attendre 0,5 seconde avant de commencer les animations suivantes
        yield return new WaitForSeconds(0.5f);

        yield return SlideCoroutine(startPositionInitiale, 1.5f); // Attendre que le glissement soit terminé
    }

    IEnumerator SlideCoroutine(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = buttonMenuPrincipal.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            buttonMenuPrincipal.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        buttonMenuPrincipal.transform.position = targetPosition;
    }


    public void onButtonCommencer()
    {
        StartCoroutine(FadeInButtonPlay());
        StartCoroutine(FadeInButtonOption());
        sliderGaucheDroite();
        MoveTitreToPosition();
        
    }
    public void onButtonPlayOption()
    {
        StartCoroutine(FadeOutTitre());
        StartCoroutine(FadeOutButtonPlay());
        StartCoroutine(FadeOutButtonOption());
        sliderDroiteGauche();
    }

    public void onButtonRetour()
    {
        StartCoroutine(FadeInTitre());
        StartCoroutine(FadeInButtonPlay());
        StartCoroutine(FadeInButtonOption());
        sliderGaucheDroite();
        
    }

}
