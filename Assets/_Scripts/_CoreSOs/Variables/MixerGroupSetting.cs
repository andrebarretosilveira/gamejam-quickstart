using UnityEngine;
using UnityEngine.Audio;

namespace Euchromata.Core.Variables
{
    [CreateAssetMenu(menuName = "Audio/Mixer Group Setting")]
    public class MixerGroupSetting : ScriptableObject
    {
        [Header("Mixer Setting")]
        public AudioMixer mixer;

        [Header("Exposed Parameters")]
        public string volParam;

        private float volume;
        public float Volume
        {
            get { return this.volume; }
            set
            {
                value = value > 0 ? value : 0.00001f;
                mixer.SetFloat(volParam, Mathf.Log10(value) * 20);

                this.volume = value;
            }
        }

        // public void SetVolume(float value)
        // {
        //     value = value > 0 ? value : 0.00001f;
        //     mixer.SetFloat(volParamName, Mathf.Log10(value) * 20);

        //     this.volume = value;
        // }

    }
}