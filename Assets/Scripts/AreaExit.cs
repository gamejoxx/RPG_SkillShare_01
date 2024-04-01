using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] string transitionAreaName;
    // [SerializeField] AreaEnter theAreaEnter;

    // Start is called before the first frame update
    void Start()
    {
       // theAreaEnter.transitionAreaName = transitionAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnTriggerEnter2D(Collider2D nextarea)
    {
    if(nextarea.tag == "Player")
        {
            Player.instance.transitionName = transitionAreaName;

            MenuManager.instance.FadeImage();

            StartCoroutine(LoadSceneCoroutine());

           // Debug.Log("Player entered the exit zone");
         }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }

}
