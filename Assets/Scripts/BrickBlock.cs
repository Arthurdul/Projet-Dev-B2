using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    public void DestroyObject(){
        Destroy(gameObject,0.05f);
    }
}
