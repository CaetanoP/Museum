using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject WinningMsg;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("hi");
        if (other.tag == "Player") {
            WinningMsg.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
