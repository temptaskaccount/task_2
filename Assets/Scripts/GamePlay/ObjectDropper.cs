using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectDropper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        transform.DOMoveY(transform.position.y - 30f, 6).OnComplete(() => Destroy(gameObject));
    }

}
