using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeRemoveNehaviour : StateMachineBehaviour
{
    public float fadeTime = 0.5f;
    public float fadeDelay = 0f;

    private float timeElapsed = 0f;
    private float fadeDelayElasped = 0f;

    SpriteRenderer spriteRenderer;
    GameObject objToRemove;
    Color startColor;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        objToRemove = animator.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fadeDelay > fadeDelayElasped)
        {
            fadeDelayElasped += Time.deltaTime;
        }
        else
        {
            timeElapsed += Time.deltaTime;

            float newAlpha = startColor.a * (1 - timeElapsed / fadeTime);

            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

            if (timeElapsed > fadeTime)
            {
                Destroy(objToRemove);
            }
        }


    }
}