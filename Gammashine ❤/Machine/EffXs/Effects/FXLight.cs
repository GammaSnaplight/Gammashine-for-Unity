using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using Snaplight;

public static class FXLight
{
    public static IEnumerator EffXsPulseDown(GameObject gameObject, float intensity, float speed, int pulseCount)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 targetScale = originalScale * (1 + intensity);

        for (int i = 0; i < pulseCount; i++)
        {
            while (Vector3.Distance(gameObject.transform.localScale, targetScale) > 0.01f)
            {
                gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, targetScale, Time.deltaTime * speed);
                yield return null;
            }

            while (Vector3.Distance(gameObject.transform.localScale, originalScale) > 0.01f)
            {
                gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, originalScale, Time.deltaTime * speed);
                yield return null;
            }
        }

        gameObject.transform.localScale = originalScale;
    }

    public static IEnumerator EffXsFade(GameObject gameObject, float intensity, float speed, int fadeCount)
    {
        Material material = gameObject.GetComponent<Renderer>().material;
        Color originalColor = material.color;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, 1 - intensity);

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(material.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(material.color.a, targetColor.a, Time.deltaTime * speed);
                material.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }

            while (Mathf.Abs(material.color.a - originalColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(material.color.a, originalColor.a, Time.deltaTime * speed);
                material.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }

        material.color = originalColor;
    }

    public static IEnumerator EffXsFadeDown(Image image, float intensity, float speed, int fadeCount)
    {
        Color originalColor = image.color;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, 1 - intensity);

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, targetColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }
    }

    public static IEnumerator EffXsFadeDownAndScale(Image image, float intensity, float speed, int fadeCount, float growFactor)
    {
        Color originalColor = image.color;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, 1 - intensity);
        Vector2 originalScale = image.rectTransform.localScale;
        Vector2 targetScale = originalScale * growFactor;

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, targetColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                image.rectTransform.localScale = Vector2.Lerp(image.rectTransform.localScale, targetScale, Time.deltaTime * speed);
                yield return null;
            }

            while (Mathf.Abs(image.color.a - originalColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, originalColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                image.rectTransform.localScale = Vector2.Lerp(image.rectTransform.localScale, originalScale, Time.deltaTime * speed);
                yield return null;
            }
        }
    }

    public static IEnumerator EffXsFadeDownAndScale(SpriteRenderer spriteRenderer, float intensity, float speed, int fadeCount, float growFactor)
    {
        Color originalColor = spriteRenderer.color;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, 1 - intensity);
        Vector3 originalScale = spriteRenderer.transform.localScale;
        Vector3 targetScale = originalScale * growFactor;

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(spriteRenderer.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(spriteRenderer.color.a, targetColor.a, Time.deltaTime * speed);
                spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                spriteRenderer.transform.localScale = Vector3.Lerp(spriteRenderer.transform.localScale, targetScale, Time.deltaTime * speed);
                yield return null;
            }

            while (Mathf.Abs(spriteRenderer.color.a - originalColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(spriteRenderer.color.a, originalColor.a, Time.deltaTime * speed);
                spriteRenderer.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                spriteRenderer.transform.localScale = Vector3.Lerp(spriteRenderer.transform.localScale, originalScale, Time.deltaTime * speed);
                yield return null;
            }
        }
    }

    public static IEnumerator EffXsPulseFadeDown(Image image, float intensity, float speed, int fadeCount)
    {
        Color originalColor = image.color;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, 1 - intensity);

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, targetColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }

            while (Mathf.Abs(image.color.a - originalColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, originalColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }

        image.color = originalColor;
    }

    public static IEnumerator EffXsFadeUp(Image image, float intensity, float speed, int fadeCount)
    {
        Color originalColor = new(image.color.r, image.color.g, image.color.b, 0);
        image.color = originalColor;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, intensity);

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, targetColor.a, Time.deltaTime * speed);
                image.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }
    }

    public static IEnumerator EffXsFadeInOut(Image image, float intensity, float speed, int fadeCount)
    {
        Color originalColor = new Color(image.color.r, image.color.g, image.color.b, 0);
        Color fadeInColor = new Color(originalColor.r, originalColor.g, originalColor.b, intensity);
        Color fadeOutColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        for (int i = 0; i < fadeCount; i++)
        {
            // Появление
            while (Mathf.Abs(image.color.a - fadeInColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, fadeInColor.a, Time.deltaTime * speed);
                image.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }

            // Исчезновение
            while (Mathf.Abs(image.color.a - fadeOutColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, fadeOutColor.a, Time.deltaTime * speed);
                image.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }
    }

    public static IEnumerator EffXsPulseFadeUp(Image image, float intensity, float speed, int fadeCount)
    {
        Color originalColor = new(image.color.r, image.color.g, image.color.b, 0);
        image.color = originalColor;
        Color targetColor = new(originalColor.r, originalColor.g, originalColor.b, intensity);

        for (int i = 0; i < fadeCount; i++)
        {
            while (Mathf.Abs(image.color.a - targetColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, targetColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }

            while (Mathf.Abs(image.color.a - originalColor.a) > 0.01f)
            {
                float newAlpha = Mathf.Lerp(image.color.a, originalColor.a, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, originalColor.b, newAlpha);
                yield return null;
            }
        }

        image.color = originalColor;
    }

    public static IEnumerator EffXsPulseBlue(Image image, float intensity, float speed, int count)
    {
        Color originalColor = new(image.color.r, image.color.g, image.color.b, image.color.a);
        image.color = originalColor;
        Color targetColor = new(0, intensity, originalColor.b, originalColor.a);

        for (int i = 0; i < count || count == -1;)
        {
            while (Mathf.Abs(image.color.r - targetColor.r) > 0.01)
            {
                float newBlue = Mathf.Lerp(image.color.r, targetColor.r, Time.deltaTime * speed);
                image.color = new(newBlue, originalColor.g, originalColor.b, originalColor.a);
                yield return null;
            }

            while (Mathf.Abs(image.color.r - originalColor.r) > 0.01)
            {
                float newBlue = Mathf.Lerp(image.color.r, originalColor.r, Time.deltaTime * speed);
                image.color = new(newBlue, originalColor.g, originalColor.b, originalColor.a);
                yield return null;
            }

            if (count != -1) i++;
        }
    }

    public static IEnumerator EffXsPulseBlue2(Image image, float intensity, float speed, int count)
    {
        Color originalColor = new(image.color.r, image.color.g, image.color.b, image.color.a);
        image.color = originalColor;
        Color targetColor = new(originalColor.r, originalColor.g, intensity, originalColor.a);

        for (int i = 0; i < count || count == -1;)
        {
            while (Mathf.Abs(image.color.b - targetColor.b) > 0.01)
            {
                float newBlue = Mathf.Lerp(image.color.b, targetColor.b, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, newBlue, originalColor.a);
                yield return null;
            }

            while (Mathf.Abs(image.color.b - originalColor.b) > 0.01)
            {
                float newBlue = Mathf.Lerp(image.color.b, originalColor.b, Time.deltaTime * speed);
                image.color = new(originalColor.r, originalColor.g, newBlue, originalColor.a);
                yield return null;
            }

            if (count != -1) i++;
        }
    }

    public static IEnumerator EffXsPulseBlue3(Image image, float intensity, float speed, int count, int steps, Color color)
    {
        Color originalColor = image.color;
        Color targetColor = Color.Lerp(originalColor, color, intensity);

        for (int i = 0; i < count || count == -1;)
        {
            for (int step = 0; step < steps; step++)
            {
                float t = step / (float)steps;
                image.color = Color.Lerp(originalColor, targetColor, t);
                yield return new WaitForSeconds(1f / speed);
            }

            for (int step = 0; step < steps; step++)
            {
                float t = step / (float)steps;
                image.color = Color.Lerp(targetColor, originalColor, t);
                yield return new WaitForSeconds(1f / speed);
            }

            if (count != -1) i++;
        }
    }

    public static IEnumerator Move(Image image, float distance, float speed, int moveCount)
    {
        Vector3 originalPosition = image.transform.position;
        Vector3 targetPosition = new Vector3(originalPosition.x, originalPosition.y + distance, originalPosition.z);

        for (int i = 0; i < moveCount; i++)
        {
            float elapsedTime = 0;

            while (elapsedTime < speed)
            {
                float newY = Mathf.SmoothStep(originalPosition.y, targetPosition.y, (elapsedTime / speed));
                image.transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0;

            while (elapsedTime < speed)
            {
                float newY = Mathf.SmoothStep(targetPosition.y, originalPosition.y, (elapsedTime / speed));
                image.transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
