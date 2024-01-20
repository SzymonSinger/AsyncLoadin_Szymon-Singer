using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class AsyncLoad : MonoBehaviour
{
   public static event EventHandler GameFullyLoaded;

    public List<int> levelsToLoad = new List<int>();

    public Image loadingImage;

   private float fakeProgress = 0;

   private bool isLoaded = false;
   

   private void Start()
   {
       StartCoroutine(LoadLevels());
   }

   private void Update()
   {
       if (isLoaded)
       {
           SceneManager.UnloadScene(0);
       }
   }
   private IEnumerator LoadLevels()
   {
       List<AsyncOperation> asyncOperations = new List<AsyncOperation>();

       for (int i = 0; i < levelsToLoad.Count; i++)
       {
           AsyncOperation LoadSceneAsync = SceneManager.LoadSceneAsync(levelsToLoad[i], LoadSceneMode.Additive);
           LoadSceneAsync.allowSceneActivation = false;
           asyncOperations.Add(LoadSceneAsync);
       }

       while (EverySceneOperationDone() == false || fakeProgress < 10)
       {
           yield return null;

           fakeProgress += Time.deltaTime;
           loadingImage.fillAmount = (asyncOperations[0].progress + asyncOperations[1].progress + fakeProgress) / 12f;
       }

       foreach (AsyncOperation asyncOperation in asyncOperations)
       {
           asyncOperation.allowSceneActivation = true;
       }

       yield return isLoaded = true;
       yield return new WaitForEndOfFrame();
       yield return null;
       
       GameFullyLoaded?.Invoke(this,EventArgs.Empty);

       bool EverySceneOperationDone()
       {
           foreach (AsyncOperation asyncOperation in asyncOperations)
           {
               if (asyncOperation.progress < .9f)
                   return false;
               
           }
           return true;
       }
   }
}
