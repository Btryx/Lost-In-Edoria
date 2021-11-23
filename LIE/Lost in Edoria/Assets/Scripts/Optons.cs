using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Optons : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider volume;
    public Toggle fullscreen;
    Resolution[] resArray;
    public TMPro.TMP_Dropdown resDropdown;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0) {
            resArray = Screen.resolutions;
            resDropdown.ClearOptions();
            List<string> options = new List<string>();
            int currentResolutionIndex = 0;
            for (int i = 0; i < resArray.Length; i++)
            {
                string option = resArray[i].width + "x" + resArray[i].height;
                options.Add(option);

                if(resArray[i].width == Screen.currentResolution.width && resArray[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            resDropdown.AddOptions(options);

            resDropdown.value = currentResolutionIndex;
            resDropdown.RefreshShownValue();

            volume.value = Data.Instance.volume;
            fullscreen.isOn = Data.Instance.isFullscreen;
            
        }

    }
    public void Volume(float vol)
    {
        audiomixer.SetFloat("ExposedVol", vol);
        Data.Instance.volume = volume.value;
    }

    public void FullScreen(bool IsFull)
    {
        Screen.fullScreen = IsFull;
        Data.Instance.isFullscreen = fullscreen.isOn;
    }
    public void Resolution(int resIndex)
    {
        Resolution r = resArray[resIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);

    }
}
