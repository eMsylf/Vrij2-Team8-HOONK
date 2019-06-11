using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float deathDelay = .5f;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Debug.Log("GAME OVER");
            OnGameOver();
        }
    }

    private void OnGameOver()
    {

        Debug.Log("Oops you died try again pls");

        // Wait 3 seconds before restarting
        StartCoroutine(enumerator());

    }

    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
