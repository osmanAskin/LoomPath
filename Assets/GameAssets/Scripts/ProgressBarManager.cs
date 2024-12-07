using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> progressImages;
    
    [SerializeField] private GameObject progressImage1;
    [SerializeField] private GameObject progressImage2;
    [SerializeField] private GameObject progressImage3;
    [SerializeField] private GameObject progressImage4;

    private void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
        Debug.Log(currentSceneIndex);
        //var SceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == 0)
        {
            /*
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
            */
            progressImage1.SetActive(true);
        }
        
        else if (currentSceneIndex == 1 || currentSceneIndex == 5 || currentSceneIndex == 9)
        {
            /*
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
            */
            progressImage1.SetActive(true);
            progressImage2.SetActive(true);
        }
        
        else if (currentSceneIndex == 2 || currentSceneIndex == 6 || currentSceneIndex == 10)
        {
            /*
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
            */
            progressImage1.SetActive(true);
            progressImage2.SetActive(true);
            progressImage3.SetActive(true);
        }
        
        else if (currentSceneIndex == 3 || currentSceneIndex == 7 || currentSceneIndex == 11)
        {
            /*
            for (int i = 0; i <= currentSceneIndex && i < progressImages.Count; i++)
            {
                progressImages[i].SetActive(true);
            }
            */
            progressImage1.SetActive(true);
            progressImage2.SetActive(true);
            progressImage3.SetActive(true);
            progressImage4.SetActive(true);
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
