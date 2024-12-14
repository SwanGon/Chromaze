using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image1, image2, image3, image4;
    public float scaleMultiplier = 1.2f;
    public float fadeAlpha = 0.5f;

    private Vector3 originalScale1, originalScale2;

    void Start()
    {
        originalScale1 = image1.transform.localScale;
        originalScale2 = image2.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image1.transform.localScale = originalScale1 * scaleMultiplier;
        image2.transform.localScale = originalScale2 * scaleMultiplier;
        SetImageOpacity(image3, fadeAlpha);
        SetImageOpacity(image4, fadeAlpha);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image1.transform.localScale = originalScale1;
        image2.transform.localScale = originalScale2;
        SetImageOpacity(image3, 1f);
        SetImageOpacity(image4, 1f);
    }

    private void SetImageOpacity(Image img, float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}
