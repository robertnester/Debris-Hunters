using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitforgameover : MonoBehaviour
{
    public ParticleSystem explosionParticleSystem;
    public GameObject gameObject;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        StartCoroutine(waitForExplosion());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitForExplosion(){
        yield return new WaitForSeconds(1f);
        explosionParticleSystem.Play();
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(true);
    }
}
