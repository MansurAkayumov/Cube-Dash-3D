using UnityEngine;
using TMPro;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    [SerializeField] private Color[] _colors;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SetColor(Renderer renderer, int value)
    {
        renderer.material.color = _colors[value - 1];
    }

    public void SetAlpha(Material material, float alphaValue)
    {
        Color oldColor = material.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        material.color = newColor;
    }
    
    public void SetTextAlpha(TextMeshPro[] texts, float alphaValue)
    {
        foreach (var text in texts)
        {
            Color oldColor = text.color;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
            text.color = newColor;   
        }
    }
}
