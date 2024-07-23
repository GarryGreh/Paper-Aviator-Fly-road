using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public TextMeshPro metersText;

    public void SetMeterText(int _meter)
    {
        metersText.text = _meter.ToString() + " m";
    }
}
