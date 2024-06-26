using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class TwoPlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] public float moveSpeed = 1.5f;

    [SerializeField] private string horAxisName;
    [SerializeField] private string verAxisName;
    [SerializeField] private string interactAxisName;

    [SerializeField] public PlayerType type = PlayerType.None;

    [SerializeField] bool useKeyboard = true;
    [SerializeField] private string horAxisKeyboard;
    [SerializeField] private string verAxisKeyboard;

    [Range(0, 1)][SerializeField] float playerStepsVolume = 0.3f;
    [SerializeField] AudioClip sfxPlayerSteps;

    public Animator animator;
    AudioSource audioSource;

    private void Awake() {
        if (type == PlayerType.Human) {
            if (!SavedVariables.humanStartPosSet) {
                SavedVariables.humanStartPos = transform.position;
                SavedVariables.humanStartPosSet = true;

            }

        }
        else {
            if (!SavedVariables.ghostStartPosSet) {
                SavedVariables.ghostStartPos = transform.position;
                SavedVariables.ghostStartPosSet = true;

            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sfxPlayerSteps;
        audioSource.volume = playerStepsVolume;

    }

    // Update is called once per frame
    void Update()
    {

        if (!animator.GetBool("isSitting")) {

            float moveHor;
            float moveVer;

            if (useKeyboard) {
                moveHor = Input.GetAxis(horAxisKeyboard);
                moveVer = Input.GetAxis(verAxisKeyboard);

            }
            else {
                moveHor = Input.GetAxis(horAxisName);
                moveVer = Input.GetAxis(verAxisName);

            }

            Vector2 movement = new Vector2(moveHor, moveVer);
            movement = Camera.main.transform.TransformDirection(movement);
            movement.Normalize();

            playerRB.velocity = movement * moveSpeed;

            if (animator.GetBool("isPulling") || animator.GetBool("isPushing")) {
                animator.SetFloat("speed", 0.0f);

            }
            else {
                // Sets player animation to walking
                animator.SetFloat("speed", playerRB.velocity.magnitude);

            }

            // Sets player to be facing left or right
            if (playerRB.velocity.x != 0) {
                if (playerRB.velocity.x > 0) {
                    animator.SetBool("isFacingLeft", false);

                }
                else {
                    animator.SetBool("isFacingLeft", true);

                }

            }

            // If player is moving, play step SFX
            if (playerRB.velocity.magnitude > 0 || playerRB.velocity.magnitude < 0) {
                if (!audioSource.isPlaying) {
                    audioSource.Play();

                }

            }
            else {
                audioSource.Stop();
            }

        }

        if (Input.GetButtonDown(interactAxisName))
        {
            Debug.Log(this.name + "Interaction Recieved");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Block" || collision.gameObject.tag == "Pillar") {
            PlayerType blockType = collision.gameObject.GetComponent<PushBlock>().type;

            if (blockType == type) {
                if (!animator.GetBool("isPulling")) {
                    animator.SetBool("isPushing", true);

                }

            }

        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Block" || collision.gameObject.tag == "Pillar") {
            PlayerType blockType = collision.gameObject.GetComponent<PushBlock>().type;

            if (blockType == type) {
                animator.SetBool("isPushing", false);

            }

        }

    }

}