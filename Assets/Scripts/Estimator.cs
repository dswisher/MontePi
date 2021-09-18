using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Estimator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hitText;
    [SerializeField] private TextMeshProUGUI missText;
    [SerializeField] private TextMeshProUGUI piText;

    private int hits;
    private int misses;

    private int updatePi = 0;
    private const int piUpdateInterval = 10;

    private void Start()
    {
        UpdateText();
    }

    public void AddHit()
    {
        hits += 1;

        UpdateText();
    }


    public void AddMiss()
    {
        misses += 1;

        UpdateText();
    }


    private void UpdateText()
    {
        hitText.text = $"{hits:00000}";
        missText.text = $"{misses:00000}";

        // Estimate PI
        if (updatePi == 0)
        {
            double pi = 0;
            if (hits > 0)
            {
                pi = 4.0 * hits / (hits + misses);
            }

            piText.text = $"{pi:0.0000}";

            updatePi = piUpdateInterval;
        }
        else
        {
            updatePi -= 1;
	    }
    }
}
