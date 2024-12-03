using UnityEngine;

public class FlashLightInteraction : MonoBehaviour
{
    [SerializeField] private Light flashLight;

    //If press F, the flashlight will be turned on or off
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = !flashLight.enabled;
        }
    }
}
