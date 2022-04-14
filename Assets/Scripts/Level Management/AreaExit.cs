using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    [SerializeField] private String sceneToLoad;
    [SerializeField] private String transitionAreaName;
    [SerializeField] private AreaEnter theAreaEnter;
    
    // Start is called before the first frame update
    void Awake()
    {
        theAreaEnter.transitionAreaName = transitionAreaName;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player.instance.transitionName = transitionAreaName;
            MenuManager.instance.FadeImage();
            StartCoroutine(LoadSceneCoroutine());
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
