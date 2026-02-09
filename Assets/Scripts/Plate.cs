using UnityEngine;

public class EasyPlate : MonoBehaviour
{
    private bool activated = false;
    public EasyPlateManager manager;
    public Material activeMat;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Plate trigger with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        
        if (!activated && other.CompareTag("Player"))
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
