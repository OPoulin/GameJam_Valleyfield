using UnityEngine;

public class changeFOV : MonoBehaviour
{
    [Header("Paramètres FOV")]
    [SerializeField] private float fovMin = 30f; // FOV minimum
    [SerializeField] private float fovMax = 90f; // FOV maximum
    [SerializeField] private float sensitivity = 10f; // Sensibilité du scroll

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("Aucune caméra n'est attachée à ce script.");
        }
    }

    private void Update()
    {
        if (cam == null) return;

        // Récupérer l'entrée de la molette de la souris
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Ajuster le FOV
        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            cam.fieldOfView -= scrollInput * sensitivity;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, fovMin, fovMax);
        }
    }
}
