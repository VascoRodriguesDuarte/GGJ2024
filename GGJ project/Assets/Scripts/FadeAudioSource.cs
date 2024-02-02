using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeAudioSource : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private float duration;
    [SerializeField] private float targetVolume;

    public void PublicStartFade()
    {
        StartCoroutine(StartFade());
    }

    private IEnumerator StartFade()
    {
        float currentTime = 0;
        float start = music.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            music.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}