using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isLit = false;
    public Renderer rend;

    void Awake()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateVisual();
    }

    public void LightUp()
    {
        isLit = true;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (rend != null)
            rend.sharedMaterial.color = isLit ? Color.yellow : Color.gray;
    }
}
