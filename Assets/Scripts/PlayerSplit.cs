using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] ColorPalette palette;

    public void OnSplit(InputAction.CallbackContext context)
    {
        if (context.performed) {
            OnSplitPerformed();
        }
    }

    private void OnSplitPerformed()
    {
        SceneManager.LoadScene("ColorMenu", LoadSceneMode.Additive);
    }

    public void splitUp()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.splitUp());
    }

    public void splitDown()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.splitDown());
    }

    public void splitRight()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.splitRight());
    }

    public void splitLeft()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.splitLeft());
    }

    private void createClone(ColorPalette newPalette)
    {
        PlayerSplit newObject = Instantiate(this);

        newObject.transform.position = transform.position;
        newObject.palette = newPalette;
        newObject.tag = "Clone";
    }

    private bool canSplitHorizontal()
    {
        return (palette.downRight != "" && palette.downLeft != "")
            || (palette.upRight != "" && palette.upLeft != "");
    }

    private bool canSplitVeritcal()
    {
        return (palette.upRight != "" && palette.downRight != "")
            || (palette.upLeft != "" && palette.downLeft != "");
    }
}
