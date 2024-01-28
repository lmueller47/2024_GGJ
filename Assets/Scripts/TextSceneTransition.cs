using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSceneTransition : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Switch());
    }
    public IEnumerator Switch()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
