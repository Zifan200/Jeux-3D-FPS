using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuOption : MonoBehaviour
{
    public GameObject menuOption;
    [SerializeField] private Slider sliderSon;
    [SerializeField] private Slider sliderMusique;
    [SerializeField] private TextMeshProUGUI textSon;
    [SerializeField] private TextMeshProUGUI textMusique;
    [SerializeField] private AudioSource musicSource; // Reference au AudioSource de la musique

    // Start is called before the first frame update
    void Start()
    {
        // set la valeur des sliders
        sliderSon.onValueChanged.AddListener(delegate { onSliderVolume(); });
        sliderMusique.onValueChanged.AddListener(delegate { onSliderMusique(); });

        // Set le texte des sliders
        textSon.text = (int)(sliderSon.value * 100) + "%";
        textMusique.text = (int)(sliderMusique.value * 100) + "%";
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
}
