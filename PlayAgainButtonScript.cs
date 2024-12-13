// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButtonScript : MonoBehaviour
{
    public string level;
    void Update()
    {
        // Check if the P key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(level);  // Change Scenes
        }
    }
        
    
}
