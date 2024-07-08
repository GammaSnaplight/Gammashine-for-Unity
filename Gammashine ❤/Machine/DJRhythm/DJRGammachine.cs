using System;

using UnityEngine;

using Snaplight;
using Snaplight.VisualizationEngine;

/// <summary>
/// Используйте DJRhythm пульт от Гаммы для работы с треками, тактами и так далее. 
/// </summary>
public static class DJRGammachine
{
    // Serializable

    // Variables: Field
    private const int _seconds60 = 60;

    // Variables: Enums
    public enum AudioAccuracyOptimizationType { VeryLow = 8, Low = 4, Medium = 2, High = 1 }
    public enum AudioAccuracySpectrum { UnderLow = 64, VeryLow = 128, Low = 256, Medium = 512, Good = 1024, High = 2048, Supreme = 4096, Impressive = 8192 }
    public enum AudioAccuracyFrequency { SubBass_BigDrums_,  }

    /// <summary>
    /// Проверяет загружен ли саундтрек?
    /// </summary>
    /// <param name="audioClip"></param>
    /// <returns></returns>
    public static bool CheckoutLoadSoundtrack(AudioClip audioClip)
    {
        audioClip.LoadAudioData();

        if (audioClip.loadState == AudioDataLoadState.Loaded)
        {
            Debug.Log("Soundtrack Loaded!");
            return true;
        }
        else if (audioClip.loadState == AudioDataLoadState.Failed)
        {
            Debug.LogError("Soundtrack Failed loading!");
            return false;
        }
        else
        {
            Debug.LogError("Empty void...");
            return false;
        }
    }

    /// <summary>
    /// Проверяет загружен ли саундтрек?
    /// </summary>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static bool CheckoutLoadSoundtrack(AudioSource audioSource)
    {
        audioSource.clip.LoadAudioData();
        audioSource.Stop();

        if (audioSource.clip.loadState == AudioDataLoadState.Loaded)
        {
            Debug.Log("Soundtrack Loaded!");
            return true;
        }
        else if (audioSource.clip.loadState == AudioDataLoadState.Failed)
        {
            Debug.LogError("Soundtrack Failed loading!");
            return false;
        }
        else
        {
            Debug.LogError("Empty void...");
            return false;
        }
    }

    /// <summary>
    /// Выявляет точное время трека
    /// </summary>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static float AudioCurrentTime(AudioSource audioSource)
    {
        float a = audioSource.timeSamples;
        float b = audioSource.clip.frequency;
        return a / b;
    }

    /// <summary>
    /// Вычисляет промежуточное время между битами трека
    /// </summary>
    /// <param name="bmp"></param>
    /// <returns></returns>
    public static float AudioBeatTime(float bmp)
       => _seconds60 / bmp;

    /// <summary>
    /// Высчитывает BPM (удары в минуты) на основе данных трека
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static int AudioCurrentBeat(float bmp, AudioSource audioSource)
        => Mathf.FloorToInt(audioSource.timeSamples / (audioSource.clip.frequency * (_seconds60 / bmp)));

    /// <summary>
    /// Высчтивает время такта трека на основе данных трека
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static float AudioCurrentBeatTime(float bmp, AudioSource audioSource)
       => audioSource.timeSamples / (audioSource.clip.frequency * (_seconds60 / bmp));

    /// <summary>
    /// Высчитывает текущий такт трека
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="key"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static int AudioCurrentBeat(float bmp, float key, AudioSource audioSource)
        => Mathf.FloorToInt(audioSource.timeSamples / (audioSource.clip.frequency * (_seconds60 / bmp * key)));

    /// <summary>
    /// Высчитывает все такты в треке
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static int AudioLengthAllBeats(float bmp, AudioSource audioSource)
        => Mathf.FloorToInt(audioSource.clip.samples / (audioSource.clip.frequency * (_seconds60 / bmp)));

    /// <summary>
    /// Высчитывает все такты в треке с учетом интервала
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="interval"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static int AudioLengthAllBeats(float bmp, float interval, AudioSource audioSource)
        => Mathf.FloorToInt(audioSource.clip.samples / (audioSource.clip.frequency * (_seconds60 / bmp)) * Mathf.Clamp(interval, 0, 1));

    /// <summary>
    /// Конвертирует время в такты
    /// </summary>
    /// <param name="t"></param>
    /// <param name="bmp"></param>
    /// <param name="audioSource"></param>
    /// <returns></returns>
    public static int ConvertSecondToBeat(float t, float bmp, AudioSource audioSource)
        => Mathf.FloorToInt(t / AudioCurrentBeat(bmp, audioSource));

    /// <summary>
    /// Конвертирует такты в время
    /// </summary>
    /// <param name="beat"></param>
    /// <param name="bmp"></param>
    /// <returns></returns>
    public static float ConvertBeatToSecond(int beat, float bmp)
        => beat * _seconds60 / bmp;
    
    public static float[] AudioData(AudioClip clip) => new float[clip.samples * clip.channels];


    public static float dB(AudioClip clip, AudioAccuracyOptimizationType type = AudioAccuracyOptimizationType.Medium)
    {
        if (clip.loadType != AudioClipLoadType.DecompressOnLoad)
        {
            VEngine.UnityWriteError("Audio should not be <" + clip.loadType + ">. Set it as - <DecompressOnLoad>");
            return Constlight.ERROR;
        }

        float[] audioData = AudioData(clip);
        clip.GetData(audioData, 0);

        float rms = 0f;
        int blockSize = 1024;
        for (int i = 0; i < audioData.Length; i += blockSize)
        {
            int end = Mathf.Min(i + blockSize, audioData.Length);
            for (int j = i; j < end; j += (int)type)
            {
                rms += audioData[i] * audioData[i];
            }
        }

        return 20 * Mathf.Log10(Mathf.Sqrt(rms / audioData.Length));
    }

    public static float[] AudioVolumeNormalize(AudioAccuracyOptimizationType type = AudioAccuracyOptimizationType.High, params AudioClip[] clip)
    {
        float[] clips = new float[clip.Length];
        float[] percentage = new float[clip.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            clips[i] = dB(clip[i], type);
        }

        float referenceSample = Mathlight.Average(clips);

        for (int i = 0; i < clips.Length; i++)
        {
            percentage[i] = Mathlight.Percent1(clips[i], referenceSample);
        }

        return percentage;
    }

    public static float[] ComputeFFT(float[] data)
    {
        float[] window = new float[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            window[i] = 0.35875F - 0.48829F * MathF.Cos(2 * MathF.PI * i / (data.Length - 1)) + 0.14128F * MathF.Cos(4 * MathF.PI * i / (data.Length - 1)) - 0.01168F * MathF.Cos(6 * MathF.PI * i / (data.Length - 1));
        }

        float[] fft = new float[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            fft[i] = data[i] * window[i];
        }

        for (int i = 0; i < data.Length; i++)
        {
            float sum = 0;
            for (int j = 0; j < data.Length; j++)
            {
                sum += fft[j] * MathF.Cos(2 * MathF.PI * i * j / data.Length);
            }
            fft[i] = sum;
        }

        float[] amplitudes = new float[data.Length / 2];
        for (int i = 0; i < data.Length / 2; i++)
        {
            amplitudes[i] = 2 * MathF.Sqrt(MathF.Pow(fft[i], 2) + MathF.Pow(fft[data.Length - i - 1], 2)) / data.Length;
        }

        return amplitudes;
    }

    //public static bool AudioBeatCallback(AudioAccuracySpectrum spectrum = AudioAccuracySpectrum.Good, int channel = 0, FFTWindow FFT = FFTWindow.BlackmanHarris, )
}
