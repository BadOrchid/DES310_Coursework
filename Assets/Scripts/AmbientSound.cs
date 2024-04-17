using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{

    [SerializeField] bool playSound = true;
    [SerializeField] AudioClip[] sounds;
    [Range(0, 1)][SerializeField] float[] volumes;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (playSound) {
            InvokeRepeating("Storm", 5, 20);
            InvokeRepeating("Rain", 2.5f, sounds[0].length);

        }

    }

    // Update is called once per frame
    void Update()
    {
        //float deltaTime = Time.deltaTime;


    }

    void Rain() {
        StartCoroutine(PlaySound(0, 0));

    }

    void Storm() {

        StartCoroutine(PlaySound(2, 0));
        StartCoroutine(PlaySound(1, 2));
        //StartCoroutine(PlaySound(0, 4));

    }

    IEnumerator PlaySound(int index, float seconds) {
        yield return new WaitForSeconds(seconds);
        audioSource.volume = volumes[index];
        audioSource.PlayOneShot(sounds[index]);

    }


}
