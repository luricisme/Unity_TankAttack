using System.Collections;
using UnityEngine;

public class AudioDeletion : MonoBehaviour
{
    public AudioClip audioClip;
    void Start()
    {
        // Bắt đầu coroutine để chờ và sau đó xoá audio
        StartCoroutine(DeleteAudioAfterDelay());
    }

    IEnumerator DeleteAudioAfterDelay()
    {
        // Chờ cho đến khi audio phát xong hoặc sau khoảng thời gian delay
        yield return new WaitForSeconds(audioClip.length);

        // Xoá audio
        Destroy(gameObject);
    }
}
