using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isLocked = true;

    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("Door unlocked!");
    }

    public void OpenDoor()
    {
        if (isLocked) return;

        // Disable collider so player can pass
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        // Simple open rotation
        transform.Rotate(0f, 90f, 0f);
    }
}
