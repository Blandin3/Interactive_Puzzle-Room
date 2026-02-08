using UnityEngine;

public class EasyPlateManager : MonoBehaviour
{
    public int totalPlates = 3;
    private int activatedPlates = 0;
    public GameObject[] plates;
    public PuzzleManager puzzleManager;

    public void PlateActivated()
    {
        activatedPlates++;
        Debug.Log("Plate activated! Count: " + activatedPlates + "/" + totalPlates);

        if (activatedPlates >= totalPlates)
        {
            Debug.Log("Easy puzzle solved! Destroying plates...");
            
            if (puzzleManager) puzzleManager.TaskCompleted();
            
            if (plates.Length == 0)
            {
                Debug.LogError("No plates assigned in array!");
                return;
            }
            
            foreach (GameObject plate in plates)
            {
                if (plate)
                {
                    Debug.Log("Destroying plate: " + plate.name);
                    Destroy(plate);
                }
            }
        }
    }
}