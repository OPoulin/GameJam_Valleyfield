using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dessein3D : MonoBehaviour
{
    public Camera cam; // Référence à la caméra dans la scène

    // Propriétés du pinceau
    public int brushSize = 4;
    public Color brushColor;

    // Références pour la texture et le mesh
    public MeshRenderer meshRenderer;
    private Texture2D texture;

    // Référence à l'objet 3D qui sera placé à la surface
    public GameObject objectToPlace; // L'objet 3D à placer et orienter

    // Variables pour le calcul des coordonnées UV
    private Vector2 uvPoint;
    private bool pressedLastFrame = false;
    private Vector2 lastUv;

    [SerializeField] public int res;

    // Variables pour le mouvement de l'objet
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool isPressed;

    //tailles du rouleau
    public int tailleX;
    public int tailleY;

    void Start()
    {
        toolManagerScript.selectedToolName = "charpy";

        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer is not assigned!");
            return;
        }

        // Crée une texture vide (transparente) au démarrage
        texture = new Texture2D(res, res, TextureFormat.RGBA32, false);

        // Assure-toi que la texture est modifiable
        texture.wrapMode = TextureWrapMode.Repeat;
        texture.filterMode = FilterMode.Point;

        // Remplir la texture avec de la transparence
        Color[] pixels = new Color[texture.width * texture.height];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = Color.clear; // Transparence
        }
        texture.SetPixels(pixels);
        texture.Apply();

        // Assigner la texture transparente au matériau du mesh
        meshRenderer.material.mainTexture = texture;

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
        // Vérifier les clics de souris
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }

        if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") >= 0.3 || Input.GetAxis("Mouse X") <= -0.3)
        {
            tailleX = 100;
            tailleY = 1;
        }
        else if (Input.GetMouseButton(0) && Input.GetAxis("Mouse Y") >= 0.3 || Input.GetAxis("Mouse Y") <= -0.3)
        {
            tailleX = 1;
            tailleY = 100;
        }

        // Calculer et mettre à jour la position de l'objet
        CalculateUV();

        // Si la souris est pressée, on applique le pinceau
        if (Input.GetMouseButton(0))
        {
            ChangePixelsAroundPoint();
        }

        // Lerp pour ajuster la position de l'objet
        objectToPlace.transform.position = Vector3.Lerp(
            objectToPlace.transform.position,
            targetPosition,
            Time.deltaTime * 20f // Vitesse de transition
        );
    }

    void CalculateUV()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Créer un rayon vers la position de la souris

        // Affiche le rayon dans la scène (en rouge)
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f)) // Si le rayon touche le mesh
        {
            // Obtenir les coordonnées UV du point d'impact
            uvPoint = hit.textureCoord;

            // Calculer la position sur la surface du mesh
            Vector3 hitPoint = hit.point;

            // Récupérer la normale du point d'impact
            Vector3 hitNormal = hit.normal;

            // Définir la position cible en fonction de l'état de clic
            if (isPressed)
            {
                targetPosition = hitPoint + hitNormal * 0.0f; // Plus proche de la surface
            }
            else
            {
                targetPosition = hitPoint + hitNormal * 0.10f; // Reculer
            }

            // Calculer la direction de l'orientation de l'objet (en gardant l'axe Y)
            Vector3 forward = Vector3.Cross(hitNormal, Vector3.right); // Générer une direction sur l'axe X/Y
            if (forward.magnitude < 0.1f) forward = Vector3.Cross(hitNormal, Vector3.up); // Si la direction est trop petite, on utilise l'axe Y comme référence.

            // Interpoler la rotation entre l'objet actuel et la nouvelle normale
            Quaternion targetRotation = Quaternion.LookRotation(forward, hitNormal);
            objectToPlace.transform.rotation = Quaternion.Slerp(objectToPlace.transform.rotation, targetRotation, Time.deltaTime * 100f); // Lerp pour rendre la rotation smooth
        }
    }

    void ChangePixelsAroundPoint()
    {
        if (pressedLastFrame)
        {
            // Applique l'effet de pinceau à la texture autour du point UV
            if (toolManagerScript.selectedToolName == "charpy")
            {
                brushSize = 20;
                DrawBrush(uvPoint);
            }
            else if (toolManagerScript.selectedToolName == "paintRoller")
            {
                brushSize = 120;
                DrawRouleau(uvPoint);
            }
            else if(toolManagerScript.selectedToolName == "pinceau")
            {
                brushSize = 30;
                DrawBrush(uvPoint);
            }
        }

        pressedLastFrame = true;
        lastUv = uvPoint;
        SetTexture(); // Met à jour la texture du mesh
    }

    void DrawBrush(Vector2 uv) // Appliquer la couleur autour du point UV
    {
        int xPix = Mathf.FloorToInt(uv.x * texture.width);
        int yPix = Mathf.FloorToInt(uv.y * texture.height);

        for (int x = xPix - brushSize; x <= xPix + brushSize; x++)
        {
            for (int y = yPix - brushSize; y <= yPix + brushSize; y++)
            {
                if (x >= 0 && x < texture.width && y >= 0 && y < texture.height)
                {
                    // Calculer la distance au centre pour dessiner un cercle
                    float distance = Vector2.Distance(new Vector2(x, y), new Vector2(xPix, yPix));

                    // Si la distance est inférieure ou égale à la taille du pinceau, on applique la couleur
                    if (distance <= brushSize)
                    {
                        Color brushWithAlpha = new Color();
                        if (toolManagerScript.selectedToolName == "charpy")
                        {
                            brushWithAlpha = new Color(0, 0, 0, 1f);
                        }
                        else if(toolManagerScript.selectedToolName == "pinceau")
                        {
                            brushWithAlpha = new Color(brushColor.r, brushColor.g, brushColor.b, 1f);
                        }
                        texture.SetPixel(x, y, brushWithAlpha);
                    }
                }
            }
        }
    }

    void DrawRouleau(Vector2 uv) // Appliquer la couleur autour du point UV
    {
        int xPix = Mathf.FloorToInt(uv.x * texture.width);
        int yPix = Mathf.FloorToInt(uv.y * texture.height);

        for (int x = xPix - brushSize + tailleX; x <= xPix + brushSize - tailleX; x++)
        {
            for (int y = yPix - brushSize + tailleY; y <= yPix + brushSize - tailleY; y++)
            {
                if (x >= 0 && x < texture.width && y >= 0 && y < texture.height)
                {
                    // Calculer la distance au centre pour dessiner un cercle
                    float distance = Vector2.Distance(new Vector2(x, y), new Vector2(xPix, yPix));

                    // Si la distance est inférieure ou égale à la taille du pinceau, on applique la couleur
                    if (distance <= brushSize)
                    {
                        Color brushWithAlpha = new Color(brushColor.r, brushColor.g, brushColor.b, 1f);
                        texture.SetPixel(x, y, brushWithAlpha);
                    }
                }
            }
        }
    }

    void SetTexture() // Applique la texture modifiée au mesh
    {
        texture.Apply();
    }
}
