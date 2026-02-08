using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public RotatePillar[] pillars;
    public GameObject door;
    public PuzzleManager puzzleManager;

    public void CheckPillars()
    {
        Debug.Log("Checking pillar alignment...");
        
        if (pillars.Length == 0)
        {
            Debug.LogError("No pillars assigned!");
            return;
        }
        
        float targetRotation = pillars[0].transform.eulerAngles.y;
        Debug.Log("Target rotation: " + targetRotation);

        foreach (RotatePillar pillar in pillars)
        {
            float diff = Mathf.Abs(pillar.transform.eulerAngles.y - targetRotation);
            Debug.Log(pillar.name + " rotation: " + pillar.transform.eulerAngles.y + " | Diff: " + diff);
            
            if (diff > 5f)
            {
                Debug.Log("Pillars not aligned yet");
                return;
            }
        }

        Debug.Log("Pillars aligned! Opening door...");
        
        if (door)
            door.SetActive(false);
        else
            Debug.LogError("Door not assigned!");
            
        if (puzzleManager)
            puzzleManager.TaskCompleted();
    }
}
