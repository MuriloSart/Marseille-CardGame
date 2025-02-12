using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "MyExposedParam";

    public void ChangeValue(float f)
    {
        group.SetFloat(floatParam, f);
    }
}
