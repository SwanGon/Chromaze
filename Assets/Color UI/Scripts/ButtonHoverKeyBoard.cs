using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardNavigation : MonoBehaviour
{
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    private Button currentHoveredButton;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && upButton != null)
        {
            SetHover(upButton);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && downButton != null)
        {
            SetHover(downButton);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && leftButton != null)
        {
            SetHover(leftButton);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && rightButton != null)
        {
            SetHover(rightButton);
        }
    }

    private void SetHover(Button button)
    {
        if (currentHoveredButton != null)
        {
            SimulateExit(currentHoveredButton);
        }
        currentHoveredButton = button;
        SimulateHover(currentHoveredButton);
    }

    private void SimulateHover(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
    }

    private void SimulateExit(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
    }
}
