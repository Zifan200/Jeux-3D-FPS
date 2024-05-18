using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource;
    
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Empêche la destruction de cet objet lors du chargement de nouvelles scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Méthode pour régler le volume de la musique
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume; // Applique le volume au AudioSource de la musique
    }

}
