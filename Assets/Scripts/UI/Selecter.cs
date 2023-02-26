using UnityEngine;
using UnityEngine.UI;

public class Selecter : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    private int currentPos;
    [SerializeField] private AudioClip optionSound;
    [SerializeField] private AudioClip confirmSound;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
            ChangePosition(-1);
        else if(Input.GetKeyDown(KeyCode.S))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            Interaction();
    }

    private void ChangePosition(int _change)
    {
        currentPos += _change;

        if(_change != 0)
            SoundManager.instance.PlaySound(optionSound);

        if(currentPos < 0)
            currentPos = options.Length - 1;
        else if (currentPos > options.Length -1)
            currentPos = 0;

        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);
    }

    private void Interaction()
    {
        SoundManager.instance.PlaySound(confirmSound);

        options[currentPos].GetComponent<Button>().onClick.Invoke();
    }
    
}
