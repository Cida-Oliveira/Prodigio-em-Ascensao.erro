using UnityEngine;
public class Moeda : MonoBehaviour
{

     public int velocidadeGiro = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * velocidadeGiro * Time.deltaTime,Space.World);
    }
}