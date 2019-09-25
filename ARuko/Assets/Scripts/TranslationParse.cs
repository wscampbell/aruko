using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationParse : MonoBehaviour
{
    // adds newlines to translation as needed
    public void ParseTranslation(string translation)
    {
        string parsed = System.Text.RegularExpressions.Regex.Unescape(translation);
        this.gameObject.GetComponent<Text>().text = parsed;
    }
}
