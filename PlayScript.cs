// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public string level; // which level/ scene it gets transitioned too
    
    // made for UI button if button pressed game starts
    public void Play()
    {
        SceneManager.LoadScene(level); // switches scenes
    }
}
