using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMerge : MonoBehaviour
{
    private Collider2D trigCollider = null;

    public void OnMerge(InputAction.CallbackContext context)
    {
        if (context.performed) {
            OnMergePerformed();
        }
    }

    private void OnMergePerformed()
    {
        if (trigCollider != null)
        {
            PlayerSplit playerSplit = this.GetComponent<PlayerSplit>();
            playerSplit.fuseClone(trigCollider.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        trigCollider = col;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        trigCollider = null;
    }
}