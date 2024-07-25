using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public TextMeshPro metersText;

    private int meter;

    public void SetMeterText(int _meter)
    {
        meter = _meter - 1;
        metersText.text = _meter.ToString() + " m";
        Debug.Log(meter - 1);
    }
    public int GetMeter()
    {
        return meter;
    }
}
