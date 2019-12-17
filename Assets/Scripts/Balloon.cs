using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float volume = 1f;
    public float minVolume = 0.1f;
    public float maxVolume = 10f;
    public float emitRatio = 0.1f;
    Rigidbody2D rb;
    Animator animator;

    public AudioSource balloon_popping;
    public AudioSource balloon_fly;
    public AudioSource balloon_collect;
    public AudioSource bird_chirp;
    private Vector3 orig_scale;
    // Start is called before the first frame update
    void Start() { 
        orig_scale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (volume > maxVolume){
            Explode();
        }else{
            // volume += Time.deltaTime * 0.1f;
        }
        Vector2 dir = PlayerInput.GetInstance().GetXY();
        if (dir.magnitude > 0.3f){
            SetDirection(dir);
        }
    
        if (PlayerInput.GetInstance().GetBoost()){
            PopBalloon(dir);
        }
        transform.localScale = Mathf.Sqrt(volume)*orig_scale;
    }

    public void GetPickup(){
        balloon_collect.Play();
        volume *= 1.5f;
        Debug.Log("Get pickup!"); 
    }

    public void SetDirection(Vector2 dir){
        float angle = Vector3.SignedAngle(Vector3.down, dir, Vector3.forward);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public void PopBalloon(Vector2 dir){
        balloon_fly.Play();
        if (volume > minVolume){
            volume = Mathf.Clamp(volume*(1-emitRatio), minVolume, maxVolume);
            rb.AddForce(-dir*2, ForceMode2D.Impulse);
            animator.SetTrigger("fly");
        }
        else if (volume <= minVolume){
            GameController.GetInstance().GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.collider.gameObject.tag == "Hurt"){
            GetComponent<ExplosionParticleGenerator>().Launch();
            AudioManager.instance.BalloonPop();
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            bird_chirp.Play();
        }

    }

    public void Explode(){
        gameObject.SetActive(false);
        GameController.GetInstance().GameOver();

    }
}
