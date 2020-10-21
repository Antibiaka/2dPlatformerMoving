using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private int nextScene;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(nextScene);
    }
}
