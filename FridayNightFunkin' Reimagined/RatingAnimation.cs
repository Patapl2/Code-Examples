using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingAnimation : MonoBehaviour
{
    public SpriteRenderer rend;

    [SerializeField] float rotationRange = 10.0f;
    [SerializeField] float moveRange = 0.2f;

    private IEnumerator coroutine;

    void Start()
    {
        //This script changes the behaviour of the UI elements that the players can see using randomnsess and a maths formula. It is changed based on of the performance of the player during gameplay.
        rend = GetComponent<SpriteRenderer>();
        coroutine = FadeOut(0.02f);
        StartCoroutine(coroutine);
        transform.Rotate(0.0f, 0.0f, Random.Range(-rotationRange, rotationRange));        
        transform.position = new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), 0f);
    }

    private IEnumerator FadeOut(float waitTime)
    {
        for (float f = 100; f > 0; f -= 5)
        {
            Color c = rend.material.color;
            c.a = f / 100;
            rend.material.color = c;
            yield return new WaitForSeconds(waitTime);
        }
        Destroy(this.gameObject);
    }
}
