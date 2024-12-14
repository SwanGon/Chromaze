using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardToHover : MonoBehaviour
{
    public Button targetButton;

    private bool isHovering = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isHovering)
            {
                SimulateHover(targetButton);
                isHovering = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (isHovering)
            {
                SimulateExit(targetButton);
                isHovering = false;
            }
        }
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
