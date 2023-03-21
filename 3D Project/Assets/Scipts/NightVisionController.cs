using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class NightVisionController : MonoBehaviour
{
    [SerializeField] private Color defaultLightColor;
    [SerializeField] private Color boostedLightColor;

    private bool isEnabled = false;
    private PostProcessVolume volume;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientLight = defaultLightColor;
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)) 
        {
            ToggleNightVision();
        }
    }

    private void ToggleNightVision()
    {
        isEnabled = !isEnabled;
        if (isEnabled)
        {
            RenderSettings.ambientLight = boostedLightColor;
            volume.weight = 1;
            Debug.Log("Nightvision enabled");
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColor;
            volume.weight = 0;
            Debug.Log("Nightvision disabled");
        }
    }
}