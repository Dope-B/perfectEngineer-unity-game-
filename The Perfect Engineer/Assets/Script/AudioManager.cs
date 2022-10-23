using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
public static AudioManager audioManager;
    #region SingleTon
    private void Awake()
    {
        if (audioManager == null)
        {
            DontDestroyOnLoad(this.gameObject);
            audioManager = this;
            audioSourceBGM = this.gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion SingleTon
    public AudioSource[] audioSourceEffect;
    public AudioSource audioSourceBGM;
    public AudioClip[] effectSound;
    public AudioClip[] BGMSound;
    public AudioClip currentBGM =null;
    public string[] playSoundName;
    public float maxvol = 1f;
    public float EmaxVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceEffect = new AudioSource[effectSound.Length+4];
        playSoundName = new string[audioSourceEffect.Length];
        for (int i = 0; i < effectSound.Length+4; i++)
        {
            audioSourceEffect[i] = this.gameObject.AddComponent<AudioSource>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playEffect(string name)
    {
        for (int i = 0; i < effectSound.Length; i++)
        {
            if (name == effectSound[i].name)
            {
                for (int j = 0; j < audioSourceEffect.Length; j++)
                {
                    if (!audioSourceEffect[j].isPlaying)
                    {
                        audioSourceEffect[j].volume = EmaxVol;
                        playSoundName[j] = effectSound[i].name;
                        audioSourceEffect[j].clip = effectSound[i];
                        audioSourceEffect[j].Play();
                        return;
                    }
                }
                Debug.Log("no more AudioSource");
                return;
            }
        }
        Debug.Log("there's no soundName");
    }

    public void stopBGM()
    {
        audioSourceBGM.Stop();
    }
    public void stopAllEffect()
    {
        for (int i = 0; i<audioSourceEffect.Length; i++)
        {
            audioSourceEffect[i].Stop();
        }
    }
    public void stopEffect(string name)
    {
        for (int i = 0; i < audioSourceEffect.Length; i++)
        {
            if (name == playSoundName[i])
            {
                audioSourceEffect[i].Stop();
                break;
            }
        }
        Debug.Log("there's no soundName");
    }
    public void setEffectVol(float vol)
    {
        for (int i = 0; i < audioSourceEffect.Length; i++)
        {
            audioSourceEffect[i].volume = vol;
        }
    }
    public void setBGMVol(float vol) { audioSourceBGM.volume = vol; }

    public IEnumerator playBGM(string name, float time = 0)
    {
        audioManager.audioSourceBGM.time = 0;
        for (int i = 0; i < BGMSound.Length; i++)
        {
            if (name == BGMSound[i].name)
            {
                audioSourceBGM.clip = BGMSound[i];
                currentBGM = BGMSound[i];
                if (time != 0) { yield return new WaitForSeconds(time); }
                audioSourceBGM.Play();
                
                yield return null;
                break;
            }
        }
    }
}
