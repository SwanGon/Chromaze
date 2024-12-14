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
        createClone(palette.p.splitUp());
    }

    public void splitDown()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.p.splitDown());
    }

    public void splitRight()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.p.splitRight());
    }

    public void splitLeft()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.p.splitLeft());
    }

    private void createClone(ColorPaletteClass newPalette)
    {
        PlayerSplit newObject = Instantiate(this);

        newObject.transform.position = transform.position;
        newObject.palette.p = newPalette;
        newObject.tag = "Clone";
    }

    private bool canSplitHorizontal()
    {
        return (palette.p.downRight != "" && palette.p.downLeft != "")
            || (palette.p.upRight != "" && palette.p.upLeft != "");
    }

    private bool canSplitVeritcal()
    {
        return (palette.p.upRight != "" && palette.p.downRight != "")
            || (palette.p.upLeft != "" && palette.p.downLeft != "");
    }
}
