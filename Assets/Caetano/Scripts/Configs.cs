using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Configs : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // Câmera principal
    private UniversalAdditionalCameraData cameraData; // Dados adicionais da câmera
    private bool isPostProcessingEnabled = true; // Estado inicial

    private void Start()
    {
        // Obtém os dados adicionais da câmera (URP)
        if (mainCamera != null)
        {
            cameraData = mainCamera.GetComponent<UniversalAdditionalCameraData>();
        }

        if (cameraData == null)
        {
            Debug.LogError("Nenhum componente UniversalAdditionalCameraData foi encontrado na câmera!");
        }
    }

    private void Update()
    {
        // Detecta o pressionamento da tecla "1"
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TogglePostProcessingEffect();
        }
    }

    private void TogglePostProcessingEffect()
    {
        if (cameraData != null)
        {
            isPostProcessingEnabled = !isPostProcessingEnabled;
            cameraData.renderPostProcessing = isPostProcessingEnabled;
            Debug.Log($"Post-Processing está agora: {(isPostProcessingEnabled ? "Ativado" : "Desativado")}");
        }
    }

}
