using System.Collections.Generic;
using UnityEngine;

public class RevealOriginel : MonoBehaviour
{
    [System.Serializable]
    public class PaintingPair
    {
        public GameObject painting;
        public GameObject original;
    }

    public List<PaintingPair> paintingPairs;
    public bool isButtonActive;

    void Start()
    {
        // Assurez-vous que le tableau contient au moins une paire
        if (paintingPairs == null || paintingPairs.Count == 0)
        {
            Debug.LogError("La liste des paires de peintures et d'originels est vide !");
        }
    }

    void Update()
    {
        // Si besoin, vous pouvez ajouter du code pour des actions régulières ici
    }

    public void ToggleOriginel()
    {
        if (paintingPairs == null || paintingPairs.Count == 0) return;

        int index = Mathf.RoundToInt(TimerSkip.laPeinture);

        if (index >= 0 && index < paintingPairs.Count)
        {
            PaintingPair pair = paintingPairs[index];

            if (pair.painting != null && pair.original != null)
            {
                if (!isButtonActive)
                {
                    pair.painting.SetActive(false);
                    pair.original.SetActive(true);
                }
                else
                {
                    pair.painting.SetActive(true);
                    pair.original.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning("Index de peinture hors des limites : " + index);
        }

        isButtonActive = !isButtonActive;
    }
}
