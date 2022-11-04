using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SerilizebleFields
    [Space(6)]
    [Header("\tPhysics")]
    [Space(6)]
    [Range(520.0f, 1020.0f)]
    [SerializeField] private float jumpForce = 10.0f;
    [Range(0.0f, 3.0f)]
    [SerializeField] private float gravityModifier = 2.0f;
    [Space(6)]
    [Header("\tCheck ground")]
    [Space(6)]
    [SerializeField] private bool isOnGround = true;
    [Header("\tParticles System")]
    [Space(6)]
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private Color bloodColor;
    [SerializeField] private ParticleSystem dirtSplatterParticle;
    [SerializeField] private GameObject dirtSplatterObj;
    [Header("\tGame status")]
    [Space(6)]
    public bool gameOver = false;
    [Space(6)]
    [Header("\tAudioResources in game")]
    [Space(6)]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    #endregion

    #region privateField
    // component
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //dirtSplatterParticle = GetGetComponent<ParticleSystem>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtSplatterParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtSplatterParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            ParticleSystem.MainModule main = dirtSplatterParticle.main;
            Vector3 dirtSplatterPos = dirtSplatterObj.transform.position;

            gameOver = true;
            Debug.Log("Game over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            // particle blood and rotate
            dirtSplatterObj.transform.Rotate(dirtSplatterPos.x, dirtSplatterPos.y - 20, 0);
            main.startColor = bloodColor;
            // audio
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        
    }

}
