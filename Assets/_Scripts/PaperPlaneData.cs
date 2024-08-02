using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PaperPlaneData", menuName = "PaperPlaneData", order = 51)]
public class PaperPlaneData : ScriptableObject
{
    [SerializeField]
    private string namePlane;
    [SerializeField]
    private string weightPlaneText;
    [SerializeField]
    private float weightPlane;
    [SerializeField]
    private string windResistancePlaneText;
    [SerializeField]
    private float windResistance;
    [SerializeField]
    private int pricePlane;
    [SerializeField]
    private Sprite spritePlane;

    public string NamePlane
    {
        get { return namePlane; }
    }
    public string WeightPlaneText
    {
        get { return weightPlaneText; }
    }
    public float WeightPlane
    {
        get { return weightPlane; }
    }
    public string WindResistanceText
    {
        get
        {
            return windResistancePlaneText;
        }
    }
    public float WindResistance
    {
        get { return windResistance; }
    }
    public int PricePlane
    {
        get { return pricePlane; }
    }
    public Sprite SpritePlane
    {
        get
        {
            return spritePlane;
        }
    }
}
