using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRenderHelper : MonoBehaviour
{
    public MeshRenderer fillMeshRenderer;

    public void ColorPotion(bool isFilled, Color fillColor)
    {
        if (!isFilled)
        {
            fillMeshRenderer.enabled = false;
            return;
        }

        fillMeshRenderer.enabled = true;
        fillMeshRenderer.material.color = fillColor;
    }
}
