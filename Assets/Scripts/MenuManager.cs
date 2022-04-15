using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Image imageToFade;
    [SerializeField] private GameObject menu;

    private Animator animator;

    public static MenuManager instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            menu.SetActive(!menu.activeInHierarchy);
        }
    }

    public void FadeImage()
    {
        animator = imageToFade.GetComponent<Animator>();
        animator.SetTrigger("StartFade");
    }
}
