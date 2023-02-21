using UnityEngine;
using UnityEngine.UI;

public class VolumeDisplay : MonoBehaviour
{
    private Text txt;
    [SerializeField]private string volumeName;
    [SerializeField]private string whichText;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        VolumeUpdate();
    }

    private void VolumeUpdate()
    {
        float volumeVaule = PlayerPrefs.GetFloat(volumeName) * 100;
        txt.text = whichText + volumeVaule.ToString();
    }
}
