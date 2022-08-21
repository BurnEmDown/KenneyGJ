using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public Color OceanGood, OceanBad, LandGood, LandBad, AtmosphereGood, AtmosphereBad;
    [SerializeField]
    Image Ocean, Land, Atmosphere;

    void Awake()
    {
        //Ocean.color = OceanGood;
        //and.color = LandGood;
        //Atmosphere.color = AtmosphereGood;
    }

    public void SetOceanColor(float val)
    {
        val = Mathf.Clamp01(val);
        Color lerpColor = Color.Lerp(OceanGood, OceanBad, val);
        Ocean.color = lerpColor;
    }

    public void SetLandColor(float val)
    {
        val = Mathf.Clamp01(val);
        Color lerpColor = Color.Lerp(LandGood, LandBad, val);
        Land.color = lerpColor;
    }

    public void SetAtmosColor(float val)
    {
        val = Mathf.Clamp01(val);
        Color lerpColor = Color.Lerp(AtmosphereGood, AtmosphereBad, val);
        Atmosphere.color = lerpColor;
    }
}
