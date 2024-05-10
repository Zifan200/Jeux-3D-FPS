using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float characterSpeed = 5f;
     [SerializeField] private Transform cameraTransform; 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerShooting();
    }

    private void playerMovement(){
        // Capture les entrées du joueur
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        // Transforme les axes de mouvement en fonction de la direction de la caméra
        Vector3 move = cameraTransform.right * input.x + cameraTransform.forward * input.z;

        move.y = 0;

        // Déplace le joueur selon la direction transformée
        characterController.Move(move * Time.deltaTime * characterSpeed);
    }

    private void playerShooting(){
        //Tirer clic gauche
         if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //rb.AddExplosionForce(2f, hit.point, 2f, 1f, ForceMode.Impulse);
                    Debug.Log("Touché");
                }
            }
            else
            {
                Debug.Log("Raté");
            }
        }


        
    }
}
