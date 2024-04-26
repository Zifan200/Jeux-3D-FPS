using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Empêcher le curseur de sortir de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtenir les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Ajuster la rotation en fonction du mouvement de la souris
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limite l'inclinaison verticale

        // Faire pivoter la caméra autour de l'axe X (haut/bas)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Faire pivoter le corps du personnage autour de l'axe Y (rotation)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
