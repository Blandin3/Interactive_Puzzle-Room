using UnityEngine;

public class StarTask : MonoBehaviour
{
    public PuzzleManager manager;
    public AudioClip collectSound;
    private bool collected = false;

    void Start()
    {
        Debug.Log("StarTask initialized on: " + gameObject.name);
        Collider col = GetComponent<Collider>();
        if (col == null)
        {
            col = GetComponentInChildren<Collider>();
            if (col == null)
                Debug.LogError("No Collider on star or its children!");
            else
            {
                Debug.Log("Found collider on child: " + col.gameObject.name + " | isTrigger: " + col.isTrigger);
                col.gameObject.AddComponent<StarTriggerHelper>().parentStar = this;
            }
        }
        else
        {
            Debug.Log("Collider isTrigger: " + col.isTrigger);
            if (!col.isTrigger)
                Debug.LogError("Collider is not set to Trigger!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Star TRIGGER with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        CollectStar(other.gameObject);
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Star COLLISION with: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
        CollectStar(other.gameObject);
    }
    
    public void CollectStar(GameObject obj)
    {
        if (collected) return;
        
        if (!obj.CompareTag("Player"))
        {
            Debug.Log("Not player, ignoring");
            return;
        }

        collected = true;
        Debug.Log("Player collected star!");
        
        if (manager) manager.TaskCompleted();

        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);
    }
}

public class StarTriggerHelper : MonoBehaviour
{
    public StarTask parentStar;
    
    void OnTriggerEnter(Collider other)
    {
        if (parentStar)
            parentStar.CollectStar(other.gameObject);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (parentStar)
            parentStar.CollectStar(other.gameObject);
    }
}



