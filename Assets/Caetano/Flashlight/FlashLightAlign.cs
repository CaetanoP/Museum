using UnityEngine;
/// <summary>
/// This script is used to align the flashlight to the player's head.
/// so that the flashlight is always pointing in the same direction as the player's look.
/// </summary>
public class FlashLightAlign : MonoBehaviour
{
    
    // The head object that the flashlight will align to.
    [Header("Head Object")]
    [SerializeField] private GameObject head;
    //First person controller
    [Header("First Person Controller")]
    [SerializeField] private GameObject player;
    

    public void Start()
    {
        if (head == null)
        {
            Debug.LogError("Head not assigned to the flashlight align script. Use the inspector to assign the head object.");
            gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        
        transform.rotation = Quaternion.Euler(head.transform.rotation.eulerAngles.x+90, player.transform.rotation.eulerAngles.y, 0);
        

    }

}
