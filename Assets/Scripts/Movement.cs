using UnityEngine;
using System;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Vector3 endpos;
    
    IEnumerator Start()
    {
        var pointA = transform.position;
        while(true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, endpos, 0.50f));
            yield return StartCoroutine(MoveObject(transform, endpos, pointA, 0.50f));
        }
    }
   
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i= 0.0f;
        var rate= 1.0f/time;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
