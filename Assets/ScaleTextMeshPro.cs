
using UnityEngine;
using TMPro;
using System;

public class ScaleTextMeshPro : MonoBehaviour
{
    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Get the TextMeshPro and RectTransform components
        textMeshPro = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponentInParent<RectTransform>();
    }

    void Update()
    {
        // Calculate the preferred height of the text based on the width of its parent panel and its content size
        float preferredHeight = textMeshPro.GetPreferredValues(rectTransform.rect.width, Mathf.Infinity).y;

        // Compare the preferred height with the current height of the TextMeshPro game object's RectTransform
        if (preferredHeight > rectTransform.rect.height)
        {
            // Set the height of the TextMeshPro game object's RectTransform to the preferred height
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
        }
    }
}
