using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{

    public string[] sentences;
    private bool canActivateBox;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateBox && Input.GetButtonDown("Fire1") && !DialogController.instance.IsDialogBoxActive())
        {
            DialogController.instance.ActivateDialog(sentences);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            canActivateBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canActivateBox = false;
        }
    }
}
