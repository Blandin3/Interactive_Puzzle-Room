using UnityEngine;

public class RotatePillar : MonoBehaviour
{
    public float rotationStep = 90f;
    public PillarManager manager;
    private bool hasRotated = false;

    void Start()
    {
        Debug.Log("RotatePillar initialized on: " + gameObject.name);
        Collider col = GetComponent<Collider>();
        if (col == null)
        {
            col = GetComponentInChildren<Collider>();
            if (col == null)
                Debug.LogError("No Collider on pillar or its children!");
            else
            {
                Debug.Log("Found collider on child: " + col.gameObject.name + " | isTrigger: " + col.isTrigger);
                // Add trigger listener to child
                col.gameObject.AddComponent<PillarTriggerHelper>().parentPillar = this;
            }
        }
        else
            Debug.Log("Collider isTrigger: " + col.isTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pillar TRIGGER with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        RotatePillarLogic(other.gameObject);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Pillar COLLISION with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        RotatePillarLogic(other.gameObject);
    }
    
    public void RotatePillarLogic(GameObject obj)
    {
        if (!hasRotated && obj.CompareTag("Player"))
        {
            hasRotated = true;
            Debug.Log("Rotating pillar by " + rotationStep + " degrees");
            transform.Rotate(0, rotationStep, 0);
            Debug.Log("New rotation: " + transform.eulerAngles.y);
            
            if (manager)
                manager.CheckPillars();
            else
                Debug.LogError("Manager not assigned to pillar!");
                
            Invoke("ResetRotation", 0.5f);
        }
    }
    
    void ResetRotation()
    {
        hasRotated = false;
    }
}

public class PillarTriggerHelper : MonoBehaviour
{
    public RotatePillar parentPillar;
    
    void OnTriggerEnter(Collider other)
    {
        if (parentPillar)
            parentPillar.RotatePillarLogic(other.gameObject);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (parentPillar)
            parentPillar.RotatePillarLogic(other.gameObject);
    }
}