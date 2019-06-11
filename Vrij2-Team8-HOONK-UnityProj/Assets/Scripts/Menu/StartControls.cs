using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartControls : MonoBehaviour {





    public void PlayGame()
    {
        StartCoroutine(GameStart());

    }


    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }





   
}
