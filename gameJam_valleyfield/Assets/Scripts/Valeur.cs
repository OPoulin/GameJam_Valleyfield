using UnityEngine;

public class Valeur : MonoBehaviour
{
    [Header("Pourcentages reçus (en % : 0-100)")]
    private float percentDrawn = -1f; // % dessiné (initialisé à -1 pour indiquer qu'il n'est pas encore défini)
    private float percentHole = -1f;  // % trou (initialisé à -1 pour indiquer qu'il n'est pas encore défini)

    [Header("Proportions (la somme doit être 100%)")]
    [Range(0, 100)] public float proportionPaint = 50; // Proportion pour la peinture
    [Range(0, 100)] public float proportionHole = 50;  // Proportion pour les trous

    [Header("Résultat")]
    [SerializeField, Tooltip("Score final calculé sur 100%")]
    private float finalScore; // Score final calculé

    /// <summary>
    /// Définit le pourcentage pour la peinture et vérifie les conditions pour calculer le score.
    /// </summary>
    /// <param name="percent">Pourcentage pour la peinture (0-100).</param>
    public void SetPercentPaint(float percent)
    {
        if (percent < 0 || percent > 100)
        {
            Debug.LogError("Le pourcentage de peinture doit être entre 0 et 100.");
            return;
        }

        percentDrawn = percent;
        Debug.Log($"Pourcentage peinture défini : {percentDrawn}%");

        // Vérifie si les deux pourcentages sont définis, puis calcule le score
        if (percentHole >= 0)
        {
        print("pipi");
            CalculateFinalScore();
        }
    }

    /// <summary>
    /// Définit le pourcentage pour les trous et vérifie les conditions pour calculer le score.
    /// </summary>
    /// <param name="percent">Pourcentage pour les trous (0-100).</param>
    public void SetPercentHole(float percent)
    {
        if (percent < 0 || percent > 100)
        {
            Debug.LogError("Le pourcentage de trou doit être entre 0 et 100.");
            return;
        }

        percentHole = percent;
        Debug.Log($"Pourcentage trou défini : {percentHole}%");

        // Vérifie si les deux pourcentages sont définis, puis calcule le score
        if (percentDrawn >= 0)
        {
        print("caca");
            CalculateFinalScore();
        }
    }

    /// <summary>
    /// Calcule le score final basé sur les pourcentages et les proportions.
    /// </summary>
    private void CalculateFinalScore()
    {
        // Normalisation des proportions pour s'assurer qu'elles cumulent à 100%
        float totalProportion = proportionPaint + proportionHole;
        float normalizedPaintProportion = proportionPaint / totalProportion;
        float normalizedHoleProportion = proportionHole / totalProportion;

        // Calcul du score final en pondérant les pourcentages reçus
        finalScore = (percentDrawn * normalizedPaintProportion) + (percentHole * normalizedHoleProportion);

        // Affichage dans la console
        Debug.Log($"Score Final Calculé : {finalScore}%");
    }
}
