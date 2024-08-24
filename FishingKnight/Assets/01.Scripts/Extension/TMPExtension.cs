using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class TMPExtension
{
    public static Coroutine DOText(this TextMeshProUGUI tmp, string text, float textDelay)
    {
        tmp.text = "";

        return tmp.StartCoroutine(DOTextCo(tmp, text, textDelay));
    }

    private static IEnumerator DOTextCo(TextMeshProUGUI tmp, string text, float textDelay)
    {
        int index = 0;
        WaitForSeconds wfs = new WaitForSeconds(textDelay);

        while (index != text.Length)
        {
            tmp.text += text[index++];

            yield return wfs;
        }
    }
}
