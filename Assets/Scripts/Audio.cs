using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private List<AudioClipList> _clipList = null;

    private List<AudioSource> _audios = null;
    private Singleton _singleton = Singleton.GetInstance();

    private void Awake() => _audios ??= new List<AudioSource>(GetComponentsInChildren<AudioSource>());

    private void Start() { }

    private AudioSource GetAudioSource(string name)
    {
        AudioSource audioSource = null;
        bool stop = false;

        _audios.ForEach(aus =>
        {
            if (stop) return;

            if (aus.name.Equals(name))
            {
                audioSource = aus;
                stop = true;
            }
        });

        return audioSource;
    }

    private AudioClip GetAudioClip(string name)
    {
        AudioClip audioClip = null;
        bool stop = false;

        _clipList.ForEach(aus =>
        {
            if (stop) return;

            if (aus.NameClip.ToLower().Trim().Equals(name.ToLower().Trim()))
            {
                audioClip = aus.Clip;
                stop = true;
            }
        });

        return audioClip ?? _clipList[0].Clip;
    }

    private IEnumerator DOFade(AudioSource audio, float end, float time)
    {
        while (audio.volume != end)
        {
            audio.volume = Mathf.Lerp(audio.volume, end, time * Time.deltaTime);
            yield return new WaitForSeconds(.001f);
        }
    }

    private IEnumerator SwitchMusicDoFade(AudioSource audio, AudioClip clip, float volume, float time)
    {
        StartCoroutine(DOFade(audio, 0, time / 2));
        yield return new WaitForSeconds(time / 2);
        audio.clip = clip;
        audio.Play();
        StopAllCoroutines();
        StartCoroutine(DOFade(audio, volume, time / 2));
    }
    //@music play | bla time = 1f


    public void SwitchMusic(string name, float time)
    {
        if (string.IsNullOrEmpty(name))
            return;

        AudioSource source = GetAudioSource("Music");

        if (source.isPlaying && source.clip == GetAudioClip(name))
            return;

        StartCoroutine(SwitchMusicDoFade(source, GetAudioClip(name), _singleton.Data.SettingData.MusicValue, time));
    }

    public void SwitchSound(string name, float time)
    {
        if (string.IsNullOrEmpty(name))
            return;

        AudioSource source = GetAudioSource("Sound");
        if (source.isPlaying && source.clip == GetAudioClip(name))
            return;

        StartCoroutine(SwitchMusicDoFade(source, GetAudioClip(name), _singleton.Data.SettingData.SoundValue, time));
        Invoke("StopSound", time * 2);
    }

    private void StopSound() => GetAudioSource("Sound").Stop();

    public void OneShot(string name)
    {
        GetAudioSource("Sound").volume = _singleton.Data.SettingData.SoundValue;
        GetAudioSource("Sound").PlayOneShot(GetAudioClip(name));
    }

}

[System.Serializable]
public class AudioClipList
{
    [SerializeField] private string _nameClip = null;
    [SerializeField] private AudioClip _clip = null;

    public string NameClip => _nameClip;
    public AudioClip Clip => _clip;
}
