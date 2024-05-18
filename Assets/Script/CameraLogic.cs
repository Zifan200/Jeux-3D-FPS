using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour

{
    [SerializeField]
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseMusic();
        playMusic();
    }
    public void pauseMusic()
    {
        // Mettre en pause la musique si le jeu est en pause
        if(GameManager.instance.jeuEnPause == true)
        {
            mainCamera.GetComponent<AudioSource>().Pause();
        }
    }
    public void playMusic()
    {
        // Reprendre la musique si le jeu n'est pas en pause
        if(GameManager.instance.jeuEnPause == false){
            mainCamera.GetComponent<AudioSource>().UnPause();
        }
    }
}
