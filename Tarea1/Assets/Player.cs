using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float score = 0;
    private float v, h;
    private float vel = 2;
    private Vector3 pos;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        StartCoroutine(CheckDeath());
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal")*vel;
        v = Input.GetAxis("Vertical")*vel;

        transform.Translate(h*Time.deltaTime,0,v*Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag == "Roller"){
            this.transform.position = pos;
            if(score > 0){
                score = score-1;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Meta"){
            score = score+1;
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            this.transform.position = pos;        
        }
    }
    IEnumerator CheckDeath(){
        while (true)
        {
        if(transform.position.y <= -1){
            this.transform.position = pos;
            if(score > 0){
                score = score-1;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
