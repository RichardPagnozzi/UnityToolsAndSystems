using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDamage_Text : MonoBehaviour
{
    public TextMeshProUGUI text;


    public void SetText(string damageAmnt, Color32 textColor)
    {
        if (text != null)
            text.text = damageAmnt;

        text.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, textColor);


    }

}
