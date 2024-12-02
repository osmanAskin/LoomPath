using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> progressImages;
    
    private void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
        //Debug.Log(currentSceneIndex);
        
        if (currentSceneIndex == 0)
        {
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
        }
        
        else if (currentSceneIndex == 1 && currentSceneIndex == 6)
        {
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
        }
        
        else if (currentSceneIndex == 2 && currentSceneIndex == 7)
        {
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
        }
        
        else if (currentSceneIndex == 3 && currentSceneIndex == 8)
        {
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
        }

        /*
    if(currentSceneIndex == j)}
        for (int j = 0; j <= currentSceneIndex; j++)
        {
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
        }
        */

    }
}
