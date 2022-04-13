using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Image imageToFade;

    private Animator animator;

    public static MenuManager instance;

    private void Start()
    {
        instance = this;
    }

    public void FadeImage()
    {
        animator = imageToFade.GetComponent<Animator>();
        animator.SetTrigger("StartFade");
    }
}
