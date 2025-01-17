using System.Collections.Generic;
using UnityEngine;

public class TrouManager : MonoBehaviour
{
    [Header("Liste des trous")]
    public List<GameObject> trous; // Liste contenant tous les objets "trou"

    [Header("Résultat")]
    [SerializeField] private float proportionBouchee; // Proportion des trous bouchés (en %)
    public GameObject resultat;

    private void Update()
    {
        // Vérifie si la touche "Enter" est pressée
        if (Input.GetKeyDown(KeyCode.Return))
        {
            VerifierTrou();
        }
    }
    public void VerifierTrou()
    {
        if (trous == null || trous.Count == 0)
        {
            Debug.LogWarning("La liste des trous est vide !");
            proportionBouchee = 0f;
            return;
        }

        int nombreTrousBouches = 0;

        foreach (var trou in trous)
        {
            if (trou.GetComponent<trou>() != null && trou.GetComponent<trou>().bouche)
            {
                nombreTrousBouches++;
            }
        }

        // Calcul de la proportion des trous bouchés
        proportionBouchee = ((float)nombreTrousBouches / trous.Count) * 100f;

        resultat.GetComponent<Valeur>().SetPercentHole(proportionBouchee);
        print("proportionBouchee" + proportionBouchee);
    }
}
