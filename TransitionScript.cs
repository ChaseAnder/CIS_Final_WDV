// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionScript : MonoBehaviour
{   
    public string level;

    void OnTriggerEnter(Collider other)
    {
        // checks if collider is player when portal is entered
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().SaveScore(); // Save the score of coins collected
            Debug.Log("Triggered by: " + other.name);
            SceneManager.LoadScene(level); // Changes scenes
        }
        
    }
}
