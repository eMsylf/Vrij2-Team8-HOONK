using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {
    




    public void PlayGame ()
        {
        StartCoroutine(GameStart());
    
        }


    private IEnumerator GameStart()
    {
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
    public void QuitGame()
    {
        StartCoroutine(Stop());
    }
}
