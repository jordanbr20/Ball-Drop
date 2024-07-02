using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OnEsc : MonoBehaviour
{
    public GameObject hideObj;
    public GameObject showObj;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onEsc();
        }
    }
    
    private void onEsc()
    {
        showObj.SetActive(true);
        hideObj.SetActive(false);
    }
}
