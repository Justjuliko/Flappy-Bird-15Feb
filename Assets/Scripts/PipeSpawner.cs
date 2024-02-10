using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{   
    public void StopPipesMovement()
    {
        PipeController[] leftPipes = FindObjectsOfType<PipeController>();

        if (leftPipes == null)
        {
            return;
        }
        
        foreach (PipeController leftPipe in leftPipes)
        {
            leftPipe.enabled = false;
            
        }
    }
}
