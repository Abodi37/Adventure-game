using UnityEngine;
using System.Collections;

public class TimedLight : MonoBehaviour
{
   public Light myLight;
    public float minIntensity = 0f;
    public float maxIntensity = 10f;
    public float speed = 2f;

    void Update()
    {
        // Mathf.Sin goes from -1 to 1. 
        // We remap it to go from 0 to 1 for smooth pulsing.
        float pulse = (Mathf.Sin(Time.time * speed) + 1) / 2f;
        
        // Apply the intensity based on our min and max
        myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, pulse);
    }
}
