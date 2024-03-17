using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    public void destroyGO()
    {
        Destroy(gameObject);
    }

    private void textSetActive()
    {
        gameObject.SetActive(false);
    }
}
