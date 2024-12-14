using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public Image imageToScale1;
    public Image imageToScale2;
    public Image imageToFade1;
    public Image imageToFade2;
    public float scaleFactor = 1.2f;
    public float fadeAlpha = 0.5f;
    private Vector3 originalScale1;
    private Vector3 originalScale2;
    private Color originalColor1;
    private Color originalColor2;

    void Start()
    {
        originalScale1 = imageToScale1.transform.localScale;
        originalScale2 = imageToScale2.transform.localScale;
        originalColor1 = imageToFade1.color;
        originalColor2 = imageToFade2.color;
    }

    public void OnMouseOverButton()
    {
        imageToScale1.transform.localScale = originalScale1 * scaleFactor;
        imageToScale2.transform.localScale = originalScale2 * scaleFactor;
        SetImageOpacity(imageToFade1, fadeAlpha);
        SetImageOpacity(imageToFade2, fadeAlpha);
    }

    public void OnMouseExitButton()
    {
        imageToScale1.transform.localScale = originalScale1;
        imageToScale2.transform.localScale = originalScale2;
        SetImageOpacity(imageToFade1, originalColor1.a);
        SetImageOpacity(imageToFade2, originalColor2.a);
    }

    private void SetImageOpacity(Image img, float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}
