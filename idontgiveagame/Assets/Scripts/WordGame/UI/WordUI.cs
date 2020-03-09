using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordUI : MonoBehaviour
{
    public void setText(string newText) {
        Transform text = gameObject.transform.Find("Text");
        TMPro.TextMeshProUGUI mesh = text.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        mesh.text = newText;

        //RectTransform wordRect = gameObject.GetComponent<RectTransform>();

        
    }
}
