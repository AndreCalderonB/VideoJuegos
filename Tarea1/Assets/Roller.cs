using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{

    public float vel;
    Vector3 startpos;
    float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 3.38f ){
            //print(transform.position.x - startpos.x);
            if((transform.position.x - 3.38f) <= -6.7f ){
                //print("Llegaste");
                direction = -1;
            }else if(transform.position.x - 3.38f >= -0.2f){
                direction = 1;
            }
            transform.Translate(-direction*Time.deltaTime*vel,0,0);
        }
    }
}
