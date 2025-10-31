using UnityEngine;
using System.Collections;

public class Feedbacks : MonoBehaviour
{
    private Vector3 originalPos;
    private Coroutine shakeCoroutine;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    // 🔹 Gèle le temps pendant "duration" secondes réelles
    public IEnumerator FreezeFrame(float duration)
    {
        float originalTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Met le temps à zéro
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = originalTimeScale;
    }

    // 🔹 Lance un tremblement d'écran
    public void ScreenShake(float duration, float magnitude)
    {
        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);

        shakeCoroutine = StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
