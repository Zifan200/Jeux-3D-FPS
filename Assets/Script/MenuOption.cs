using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MenuOption : MonoBehaviour
{
    [SerializeField]
    private GameObject menuOption;
    [SerializeField] private Slider sliderSon;
    [SerializeField] private Slider sliderMusique;
    [SerializeField] private TextMeshProUGUI textSon;
    [SerializeField] private TextMeshProUGUI textMusique;
    [SerializeField] private AudioSource musicSource; // Reference au AudioSource de la musique
    [SerializeField] private TextMeshProUGUI titre;
    [SerializeField] private GameObject buttonMenuOption;
    [SerializeField] private GameObject buttonMenuOptionPositionFinale;
    private Color colorOption;
    private Vector3 startPositionInitiale;
    private Vector3 startPositionFinale;
    private Vector3 startPositionTextOption;
    private Color titreColor;
    private Color buttonRetourColor;
    [SerializeField] private TextMeshProUGUI retourText;
    [SerializeField] private Button buttonRetour;
    [SerializeField] private Slider SliderMusique;
    [SerializeField] private Slider SliderSon;
    private Color sliderColorMusique;
    private Color sliderColorSon;
    [SerializeField] private TextMeshProUGUI sonText;
    [SerializeField] private TextMeshProUGUI sonVolumeText;
    private Color sonColorText;
    private Color sonVolumeColorText;
    [SerializeField] private TextMeshProUGUI musiqueText;
    [SerializeField] private TextMeshProUGUI musiqueVolumeText;
    private Color musiqueColorText;
    private Color musiqueVolumeColorText;
    [SerializeField] private Image fillAreaSon;
    [SerializeField] private Image fillAreaMusique;
    private Color fillAreaSonColor;
    private Color fillAreaMusiqueColor;
    [SerializeField] private Image backgroundMusique;
    [SerializeField] private Image backgroundSon;
    private Color backgroundMusiqueColor;
    private Color backgroundSonColor;


    // Start is called before the first frame update
    void Start()
    {
        // set la valeur des sliders
        sliderSon.onValueChanged.AddListener(delegate { onSliderVolume(); });
        sliderMusique.onValueChanged.AddListener(delegate { onSliderMusique(); });

        // Set le texte des sliders
        textSon.text = (int)(sliderSon.value * 100) + "%";
        textMusique.text = (int)(sliderMusique.value * 100) + "%";

        // rendre le texte invisible
        startPositionTextOption = titre.transform.position;
        titreColor = titre.color;
        titre.color = new Color(titreColor.r, titreColor.g, titreColor.b, 0f);

        // Rendre le bouton "Retour" invisible au départ
        buttonRetourColor = buttonRetour.image.color;
        buttonRetour.image.color = new Color(buttonRetourColor.r, buttonRetourColor.g, buttonRetourColor.b, 0f);
        retourText.color = new Color(retourText.color.r, retourText.color.g, retourText.color.b, 0f);

        // rendre le slider son invisible
        sliderColorSon = SliderSon.image.color;
        SliderSon.image.color = new Color(sliderColorSon.r, sliderColorSon.g, sliderColorSon.b, 0f);
        sonText.color = new Color(sonText.color.r, sonText.color.g, sonText.color.b, 0f);
        sonVolumeText.color = new Color(sonVolumeText.color.r, sonVolumeText.color.g, sonVolumeText.color.b, 0f);
        fillAreaSonColor = fillAreaSon.GetComponent<Image>().color;
        fillAreaSon.GetComponent<Image>().color = new Color(fillAreaSonColor.r, fillAreaSonColor.g, fillAreaSonColor.b, 0f);
        backgroundSonColor = backgroundSon.GetComponent<Image>().color;
        backgroundSon.GetComponent<Image>().color = new Color(backgroundSonColor.r, backgroundSonColor.g, backgroundSonColor.b, 0f);
       

        // rendre le slider musique invisible
        sliderColorMusique = SliderMusique.image.color;
        SliderMusique.image.color = new Color(sliderColorMusique.r, sliderColorMusique.g, sliderColorMusique.b, 0f);
        musiqueText.color = new Color(musiqueText.color.r, musiqueText.color.g, musiqueText.color.b, 0f);
        musiqueVolumeText.color = new Color(musiqueVolumeText.color.r, musiqueVolumeText.color.g, musiqueVolumeText.color.b, 0f);
        fillAreaMusiqueColor = fillAreaMusique.GetComponent<Image>().color;
        fillAreaMusique.GetComponent<Image>().color = new Color(fillAreaMusiqueColor.r, fillAreaMusiqueColor.g, fillAreaMusiqueColor.b, 0f);
        backgroundMusiqueColor = backgroundMusique.GetComponent<Image>().color;
        backgroundMusique.GetComponent<Image>().color = new Color(backgroundMusiqueColor.r, backgroundMusiqueColor.g, backgroundMusiqueColor.b, 0f);
       
        
        startPositionInitiale = buttonMenuOption.transform.position;
        startPositionFinale = buttonMenuOptionPositionFinale.transform.position;
    }

    public void onSliderMusique()
    {
        // Change the volume of the music and update the displayed volume
        AudioManager.instance.musicVolume = sliderMusique.value;
        musicSource.volume = sliderMusique.value;
        textMusique.text = (int)(sliderMusique.value * 100) + "%";
    }

    public void onSliderVolume()
    {
        // Update the displayed volume for sound effects
        AudioManager.instance.soundVolume = sliderSon.value;
        textSon.text = (int)(sliderSon.value * 100) + "%";
    }

    IEnumerator FadeInOption()
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

    IEnumerator fadeOutOption()
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

    IEnumerator FadeInSon()
    {
        yield return new WaitForSeconds(1f); // Attendre 1 seconde avant de démarrer le fondu de son
        // Fondu enchaîné du son
        float elapsedTime = 0;
        float fadeDuration = 1f; // Durée du fondu en seconde
        Color initialColor = SliderSon.image.color;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            SliderSon.image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            sonText.color = new Color(sonText.color.r, sonText.color.g, sonText.color.b, alpha);
            sonVolumeText.color = new Color(sonVolumeText.color.r, sonVolumeText.color.g, sonVolumeText.color.b, alpha);
            fillAreaSon.GetComponent<Image>().color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            backgroundSon.GetComponent<Image>().color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator fadeOutSon()
    {
        yield return new WaitForSeconds(1f); // Attendre 1 seconde avant de démarrer le fondu de son

        float duration = 1f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        // Récupérer les couleurs initiales
        Color sonTextColor = sonText.color;
        Color sonVolumeTextColor = sonVolumeText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Calculer la transparence en fonction du temps écoulé
            float alpha = Mathf.Clamp01(1f - (elapsedTime / duration));

            // Appliquer la transparence aux couleurs
            sonTextColor.a = alpha;
            sonVolumeTextColor.a = alpha;

            // Appliquer les couleurs modifiées
            sonText.color = sonTextColor;
            sonVolumeText.color = sonVolumeTextColor;
            sonText.color = sonTextColor;
            sonVolumeText.color = sonVolumeTextColor;
            sliderSon.image.color = new Color(sliderColorSon.r, sliderColorSon.g, sliderColorSon.b, 0f);
            fillAreaSon.GetComponent<Image>().color = new Color(fillAreaSonColor.r, fillAreaSonColor.g, fillAreaSonColor.b, 0f);
            backgroundSon.GetComponent<Image>().color = new Color(backgroundSonColor.r, backgroundSonColor.g, backgroundSonColor.b, 0f);

            yield return null;
        }  
            sonTextColor.a = 0f;
            sonVolumeTextColor.a = 0f;  
        }

    IEnumerator fadeOutMusique()
    {
        float duration = 1f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        // Récupérer les couleurs initiales
        Color musiqueTextColor = musiqueText.color;
        Color musiqueVolumeTextColor = musiqueVolumeText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Calculer la transparence en fonction du temps écoulé
            float alpha = Mathf.Clamp01(1f - (elapsedTime / duration));

            // Appliquer la transparence aux couleurs
            musiqueTextColor.a = alpha;
            musiqueVolumeTextColor.a = alpha;

            // Appliquer les couleurs modifiées
            musiqueText.color = musiqueTextColor;
            musiqueVolumeText.color = musiqueVolumeTextColor;
            musiqueText.color = musiqueTextColor;
            musiqueVolumeText.color = musiqueVolumeTextColor;
            SliderMusique.image.color = new Color(sliderColorMusique.r, sliderColorMusique.g, sliderColorMusique.b, 0f);
            fillAreaMusique.GetComponent<Image>().color = new Color(fillAreaMusiqueColor.r, fillAreaMusiqueColor.g, fillAreaMusiqueColor.b, 0f);
            backgroundMusique.GetComponent<Image>().color = new Color(backgroundMusiqueColor.r, backgroundMusiqueColor.g, backgroundMusiqueColor.b, 0f);

            yield return null;
        }

        musiqueTextColor.a = 0f;
        musiqueVolumeTextColor.a = 0f;
    }

    IEnumerator FadeInMusique()
    {
        // Fondu enchaîné de la musique
        float elapsedTime = 0;
        float fadeDuration = 1f; // Durée du fondu en seconde
        Color initialColor = SliderMusique.image.color;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            SliderMusique.image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            musiqueText.color = new Color(musiqueText.color.r, musiqueText.color.g, musiqueText.color.b, alpha);
            musiqueVolumeText.color = new Color(musiqueVolumeText.color.r, musiqueVolumeText.color.g, musiqueVolumeText.color.b, alpha);
            fillAreaMusique.GetComponent<Image>().color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            backgroundMusique.GetComponent<Image>().color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


    IEnumerator FadeInBouttonRetour()
    {
        yield return new WaitForSeconds(0.5f);

        // Fondu enchaîné du bouton retour
        float elapsedTime = 0;
        float fadeDuration = 1.5f; // Durée du fondu en seconde
        Color initialColor = buttonRetour.image.color;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            buttonRetour.image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            retourText.color = new Color(retourText.color.r, retourText.color.g, retourText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOutBouttonRetour()
    {
        float duration = 1.5f; // Durée du fondu en secondes
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonRetourColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            buttonRetour.image.color = buttonRetourColor;
            retourText.color = new Color(retourText.color.r, retourText.color.g, retourText.color.b, 1 - Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        buttonRetourColor.a = 0;
        buttonRetour.image.color = buttonRetourColor;
        retourText.color = new Color(retourText.color.r, retourText.color.g, retourText.color.b, 0);
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
        Vector3 initialPosition = buttonMenuOption.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            buttonMenuOption.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        buttonMenuOption.transform.position = targetPosition;
    }

    public void onButtonOption()
    {
       StartCoroutine(FadeInOption());
       StartCoroutine(FadeInMusique());
       StartCoroutine(FadeInSon());
       StartCoroutine(FadeInBouttonRetour());
       sliderGaucheDroite();
    }

    public void onButtonRetour()
    {
        StartCoroutine(fadeOutOption());
        StartCoroutine(fadeOutMusique());
        StartCoroutine(fadeOutSon());
        StartCoroutine(FadeOutBouttonRetour());
        sliderDroiteGauche();
    }
}
