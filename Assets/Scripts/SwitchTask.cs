using UnityEngine;

public class SwitchTask : MonoBehaviour
{
    public Light roomLight;
    public Light[] wallLights;
    public PuzzleManager manager;
    public bool powerOn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        if (powerOn) return;

        powerOn = true;
        Debug.Log("Switch activated!");
        
        if (roomLight)
        {
            roomLight.enabled = true;
            Debug.Log("Room light turned on");
        }
        
        if (wallLights.Length == 0)
        {
            Debug.LogError("No wall lights assigned!");
        }
        else
        {
            Debug.Log("Turning on " + wallLights.Length + " wall lights");
            foreach (Light light in wallLights)
            {
                if (light)
                {
                    light.enabled = true;
                    Debug.Log("Turned on light: " + light.name);
                }
                else
                {
                    Debug.LogError("Null light in array!");
                }
            }
        }
        
        GetComponent<Renderer>().material.color = Color.green;

        if (manager) manager.TaskCompleted();
    }
}


