using UnityEngine;

[ExecuteInEditMode]
public class DisableMeshRenderers : MonoBehaviour
{
    void OnEnable()
    {
        DisableAllMeshRenderers();
    }

    void DisableAllMeshRenderers()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = false;
        }
    }
}
