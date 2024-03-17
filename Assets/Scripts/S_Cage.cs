using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cage : MonoBehaviour
{
    public GameObject pressR_Panel;

    public int whichAnimal;

    private void Start()
    {
        pressR_Panel.SetActive(false);
    }

}
