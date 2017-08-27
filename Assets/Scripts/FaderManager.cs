using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderManager : MonoBehaviour
{
    private Animator animator;
    private Image fader;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        fader = GetComponent<Image>();
    }

    public void FadeOut(float seconds)
    {
        StartCoroutine(Fading(seconds));
    }
    
    private IEnumerator Fading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("ShouldFade", true);

        yield return new WaitUntil(() => fader.color.a == 1);
        LevelManager.Instance.LoadNextLevel();
    }
}