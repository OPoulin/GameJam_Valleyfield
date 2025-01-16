using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boucheTrou : MonoBehaviour
{
    public Camera cam; // R�f�rence � la cam�ra dans la sc�ne

    // R�f�rences pour la texture et le mesh
    public MeshRenderer meshRenderer;

    // R�f�rences aux objets 3D
    public GameObject objectToPlace; // L'objet 3D � placer
    public GameObject objetRestore; // Parent pour organiser les objets instanci�s

    // Variables pour le calcul des coordonn�es UV
    private Vector2 uvPoint;

    // Variables pour le mouvement de l'objet
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool isPressed;

    void Start()
    {
        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer is not assigned!");
            return;
        }

        if (objectToPlace == null)
        {
            Debug.LogError("objectToPlace is not assigned!");
        }

        // Position initiale de l'objet
        initialPosition = objectToPlace.transform.position;
        targetPosition = initialPosition;
    }

    private void Update()
    {
        // V�rifier les clics de souris
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }

        // Calculer et mettre � jour la position de l'objet
        CalculateUV();

        // Si la souris est press�e, instancier un nouvel objet
        if (Input.GetMouseButtonDown(0))
        {
            InstantiateObjectAtTargetPosition();
        }

        // Lerp pour ajuster la position de l'objet (mouvement fluide)
        objectToPlace.transform.position = Vector3.Lerp(
            objectToPlace.transform.position,
            targetPosition,
            Time.deltaTime * 20f // Vitesse de transition
        );
    }

    void CalculateUV()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Cr�er un rayon vers la position de la souris

        // Affiche le rayon dans la sc�ne (en rouge)
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f)) // Si le rayon touche le mesh
        {
            // Obtenir les coordonn�es UV du point d'impact
            uvPoint = hit.textureCoord;

            // Calculer la position sur la surface du mesh
            Vector3 hitPoint = hit.point;

            // R�cup�rer la normale du point d'impact
            Vector3 hitNormal = hit.normal;

            // D�finir la position cible en fonction de l'�tat de clic
            if (isPressed)
            {
                targetPosition = hitPoint + hitNormal * 0.00f; // Plus proche de la surface
            }
            else
            {
                targetPosition = hitPoint + hitNormal * 0.10f; // Reculer
            }

            // Calculer la direction de l'orientation de l'objet
            Vector3 forward = Vector3.Cross(hitNormal, Vector3.right); // G�n�rer une direction sur l'axe X/Y
            if (forward.magnitude < 0.1f)
                forward = Vector3.Cross(hitNormal, Vector3.up); // Si la direction est trop petite, on utilise l'axe Y comme r�f�rence.

            // Interpoler la rotation entre l'objet actuel et la nouvelle normale
            Quaternion targetRotation = Quaternion.LookRotation(forward, hitNormal);
            objectToPlace.transform.rotation = Quaternion.Slerp(objectToPlace.transform.rotation, targetRotation, Time.deltaTime * 100f); // Rotation fluide
        }
    }

    void InstantiateObjectAtTargetPosition()
    {
        // Calculer une rotation al�atoire sur l'axe Z
        float randomZRotation = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, randomZRotation);

        // Instancier un nouvel objet � la position et rotation actuelles avec rotation al�atoire sur Z
        GameObject newObject = Instantiate(
            objectToPlace,
            targetPosition,
            objectToPlace.transform.rotation * randomRotation
        );

        // Ajouter le nouvel objet comme enfant de `objetRestore`
        if (objetRestore != null)
        {
            newObject.transform.parent = objetRestore.transform;
        }

        // Activer le MeshCollider sur le nouvel objet, s'il en poss�de un
        MeshCollider meshCollider = newObject.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.enabled = true;
        }
    }
}
