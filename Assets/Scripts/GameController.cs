using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static List<Item> MoveableItems;
    public static GameController CONTROLLER;
    public GameObject movingItem;

    public float timeLimit = 120f; // 2 minutes
    public float elapsedTime = 0f;

    public Slider timer;
    public FadeScript fadePanel;

    bool triggeredPhone = false;

    private void Awake()
    {
        // enforce only 1 GameController - if it already exists, don't allow another to exist.
        SceneManager.sceneLoaded += Initialise;
    }

    private void Initialise()
    {
        if (CONTROLLER == null)
        {
            CONTROLLER = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        MoveableItems = new List<Item>();
        movingItem = null;
        timeLimit = 120f; // 2 minutes
        elapsedTime = 0f;
        if (GameObject.Find("Timer"))
            timer = GameObject.Find("Timer").GetComponent<Slider>();
        if (GameObject.Find("FadeInOut"))
            fadePanel = GameObject.Find("FadeInOut").GetComponent<FadeScript>();
        timer.gameObject.SetActive(false);
    }

    void Initialise(Scene scene, LoadSceneMode loadSceneMode)
    {
        Initialise();
    }

    void Start()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("DESTROYED");
    }

    // Update is called once per frame
    void Update()
    {
        if (movingItem == null || (movingItem != null && !movingItem.name.Equals("Phone")))
            UpdateTimer();
        else if (movingItem.name.Equals("Phone") && !triggeredPhone)
        {
            timer.gameObject.SetActive(false);
            FindObjectOfType<MovementScript>().anim.SetTrigger("Pick Up Phone");
            triggeredPhone = true;
            StartCoroutine(StartFade());
        }
        
    }

    private void UpdateTimer()
    {
        if (!timer)
            timer = GameObject.Find("Timer").GetComponent<Slider>();
        if (timer && timer.gameObject.activeInHierarchy && triggeredPhone)
        {
            elapsedTime += Time.deltaTime;
            timer.value = (elapsedTime / timeLimit);

            if (elapsedTime >= timeLimit)
            {
                EndGame();
            }
        }
    }

    IEnumerator StartFade()
    {
        yield return new WaitForSeconds(6.03f);
        fadePanel.fadingToBlack = true;

        while (fadePanel.fadingToBlack && !fadePanel.fadeComplete)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);
        fadePanel.fadeComplete = false;
        fadePanel.fadingToBlack = false;
        
        while (!fadePanel.fadingToBlack)
        {
            if (fadePanel.CHECKFADE())
                break;
            yield return new WaitForEndOfFrame();
        }
        Destroy(fadePanel.gameObject);
        timer.gameObject.SetActive(true);
        Destroy(movingItem);
        movingItem = null;
        yield return null;
    }

    private void EndGame()
    {
        throw new NotImplementedException();
    }
}
