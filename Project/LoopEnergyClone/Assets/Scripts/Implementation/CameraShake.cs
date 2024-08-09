using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;
        float cameraX = transform.position.x;
        float cameraY = transform.position.y;

        while (elapsed < duration)
        {
            float x = Random.Range(cameraX-0.4f, cameraX+0.4f) * magnitude;
            float y = Random.Range(cameraY-0.4f, cameraY+0.4f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
