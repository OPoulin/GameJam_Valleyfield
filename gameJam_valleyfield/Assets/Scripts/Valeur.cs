using UnityEngine;

public class Valeur : MonoBehaviour
{
    [Header("Pourcentages re�us (en % : 0-100)")]
    private float percentDrawn = -1f; // % dessin� (initialis� � -1 pour indiquer qu'il n'est pas encore d�fini)
    private float percentHole = -1f;  // % trou (initialis� � -1 pour indiquer qu'il n'est pas encore d�fini)

    [Header("Proportions (la somme doit �tre 100%)")]
    [Range(0, 100)] public float proportionPaint = 50; // Proportion pour la peinture
    [Range(0, 100)] public float proportionHole = 50;  // Proportion pour les trous

    [Header("R�sultat")]
    [SerializeField, Tooltip("Score final calcul� sur 100%")]
    private float finalScore; // Score final calcul�

    /// <summary>
    /// D�finit le pourcentage pour la peinture et v�rifie les conditions pour calculer le score.
    /// </summary>
    /// <param name="percent">Pourcentage pour la peinture (0-100).</param>
    public void SetPercentPaint(float percent)
    {
        if (percent < 0 || percent > 100)
        {
            Debug.LogError("Le pourcentage de peinture doit �tre entre 0 et 100.");
            return;
        }

        percentDrawn = percent;
        Debug.Log($"Pourcentage peinture d�fini : {percentDrawn}%");

        // V�rifie si les deux pourcentages sont d�finis, puis calcule le score
        if (percentHole >= 0)
        {
        print("pipi");
            CalculateFinalScore();
        }
    }

    /// <summary>
    /// D�finit le pourcentage pour les trous et v�rifie les conditions pour calculer le score.
    /// </summary>
    /// <param name="percent">Pourcentage pour les trous (0-100).</param>
    public void SetPercentHole(float percent)
    {
        if (percent < 0 || percent > 100)
        {
            Debug.LogError("Le pourcentage de trou doit �tre entre 0 et 100.");
            return;
        }

        percentHole = percent;
        Debug.Log($"Pourcentage trou d�fini : {percentHole}%");

        // V�rifie si les deux pourcentages sont d�finis, puis calcule le score
        if (percentDrawn >= 0)
        {
        print("caca");
            CalculateFinalScore();
        }
    }

    /// <summary>
    /// Calcule le score final bas� sur les pourcentages et les proportions.
    /// </summary>
    private void CalculateFinalScore()
    {
        // Normalisation des proportions pour s'assurer qu'elles cumulent � 100%
        float totalProportion = proportionPaint + proportionHole;
        float normalizedPaintProportion = proportionPaint / totalProportion;
        float normalizedHoleProportion = proportionHole / totalProportion;

        // Calcul du score final en pond�rant les pourcentages re�us
        finalScore = (percentDrawn * normalizedPaintProportion) + (percentHole * normalizedHoleProportion);

        // Affichage dans la console
        Debug.Log($"Score Final Calcul� : {finalScore}%");
    }
}
