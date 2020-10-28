using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    CanvasGroup canvasGroup = null;
    TMP_Text messageText = null;

    [SerializeField]
    float fadeDuration;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;

    }

    IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;

        yield return new WaitForSeconds(duration);
        float elapsedTime = 0;
        float startTime = Time.time;
        while(elapsedTime < fadeDuration)
        {
            elapsedTime = Time.time - startTime;
            canvasGroup.alpha = 1 - elapsedTime / fadeDuration;
            yield return null;
        }

        canvasGroup.alpha = 0;
  
    }

    void OnConTextualMessageTriggered(string message, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessage(message , duration));
    }

    void OnEnable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered += OnConTextualMessageTriggered;
    }

    private void OnDisable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered -= OnConTextualMessageTriggered;
    }
}
