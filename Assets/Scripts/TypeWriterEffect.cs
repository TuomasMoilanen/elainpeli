using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using UnityEngine.Timeline;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField]
    private float typewriterSpeed = 20;

    public Coroutine Run(string texToType, TMP_Text textLabel)
    {
        return StartCoroutine(routine: TypeText(texToType, textLabel));
    }

    private IEnumerator TypeText(string texToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;


        float t = 0;
        int charIndex = 0;

        while (charIndex < texToType.Length)
        {
            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: texToType.Length);

            textLabel.text = texToType.Substring(startIndex: 0, length: charIndex);

            yield return null;
        }

    }
}
