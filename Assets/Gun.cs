using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public Slider asteroid;
    public int asteroidValue = 3;
    public AudioClip pewpew;
    public AudioSource audioSource;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 25f;
    private float nextTimeToFire = 0.5f;
    public int score;
    public Animator animator;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        asteroid.value = 6;
        audioSource.clip = pewpew;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
        Shoot();
        }
        if(asteroid.value == 12){
            SceneManager.LoadScene("victory");
        }
        if(asteroid.value == 0){
            SceneManager.LoadScene("explosion");
        }
    }
    IEnumerator shootgun(){
        animator.SetBool("shooting", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("shooting", false);

        
    }
    void Shoot(){
        StartCoroutine(shootgun());
        muzzleFlash.Play();
        audioSource.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            print(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.TakeDamage(damage);
                asteroidValue += 1;
                asteroid.value += 1f;
                score += 100;
                Text scoreText = GameObject.Find("Canvas/scoreTXT").GetComponent<Text>();
                scoreText.text = score.ToString();
            }
        }
    }
}