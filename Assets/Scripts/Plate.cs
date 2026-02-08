using UnityEngine;

public class EasyPlate : MonoBehaviour
{
    private bool activated = false;
    public EasyPlateManager manager;
    public Material activeMat;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Plate collision with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        
        if (!activated && other.gameObject.CompareTag("Player"))
        {
            activated = true;
            GetComponent<Renderer>().material = activeMat;
            Debug.Log("Plate activated! Calling manager...");
            
            if (manager)
                manager.PlateActivated();
            else
                Debug.LogError("Manager not assigned to plate!");
        }
    }
}
