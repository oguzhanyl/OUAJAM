using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void destroyGO()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
