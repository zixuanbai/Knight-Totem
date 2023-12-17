using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    public Image healthGreen;
    public Image healthRed;

    private void Update()
    {
        if (healthRed.fillAmount>healthGreen.fillAmount)
        {
            healthRed.fillAmount -= Time.deltaTime;
        }
    }
    public void OnHealthChange(float persentage)
    {
        healthGreen.fillAmount = persentage;
    }
}
