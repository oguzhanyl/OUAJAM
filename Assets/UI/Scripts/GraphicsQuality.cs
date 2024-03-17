using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsQuality : MonoBehaviour
{
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
}
