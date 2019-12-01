using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class JetPack : MonoBehaviour
{
    public float speed = 3;

    public CharacterController CharCont;
    public FirstPersonController FPC;

    public Vector3 currentVector = Vector3.up;

    public float CurrentForce = 0;

    public float MaxForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)&& MaxForce > 0){
            MaxForce -= Time.deltaTime;
            if(CurrentForce < 1)
                CurrentForce += Time.deltaTime * 10;
            else
                CurrentForce = 1;
        }
        if(MaxForce < 0 && CurrentForce > 0){
            CurrentForce -= Time.deltaTime;
        }
        if(!Input.GetKey(KeyCode.Space)){
            if(CurrentForce > 0)
                CurrentForce -= Time.deltaTime;
            else
                CurrentForce = 0;

            if(MaxForce < 5){
                MaxForce += Time.deltaTime;
            }
            else
                MaxForce = 5;
        }
        if(CurrentForce > 0)
            UseJetPack();
    }
    
    public void UseJetPack()
    {
        if(FPC.m_Jump)
            FPC.m_Jump = false;
        currentVector = Vector3.up;
        
        currentVector += transform.right * Input.GetAxis("Horizontal");
        currentVector += transform.forward * Input.GetAxis("Vertical");
        CharCont.Move((currentVector * speed * Time.fixedDeltaTime - CharCont.velocity * Time.fixedDeltaTime)* CurrentForce);

    }
}
