using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                // SWITCH
                SwitchTask switchTask = hit.collider.GetComponent<SwitchTask>();
                if (switchTask != null)
                {
                    switchTask.ActivateSwitch();
                    return;
                }


                // ❌ NO BATTERY CODE HERE ANYMORE
            }
        }
    }
}


