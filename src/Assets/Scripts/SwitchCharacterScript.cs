using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3, avatar4, avatar5;
    int _activeAvatar = 1;
    public bool manualSwitch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(false);
        avatar5.gameObject.SetActive(false);
        if (!manualSwitch)
        {
            InvokeRepeating(nameof(ChangeAvatar), 4.0f, 4.0f);
        }
    }
    
    // change after time
    void ChangeAvatar()
    {
        switch (_activeAvatar)
        {
            case 1:
                _activeAvatar = 2;
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                break;
            case 2:
                _activeAvatar = 3;
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(true);
                break;
            case 3:
                _activeAvatar = 4;
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(true);
                break;
            case 4:
                _activeAvatar = 5;
                avatar4.gameObject.SetActive(false);
                avatar5.gameObject.SetActive(true);
                break;
            case 5:
                _activeAvatar = 5;
                avatar5.gameObject.SetActive(true);
                break;

        }
    }



    // manual switching
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && manualSwitch)
        {
            print(_activeAvatar);
            switch (_activeAvatar)
            {
                case 1:
                    _activeAvatar = 2;
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
                    break;
                case 2:
                    _activeAvatar = 3;
                    avatar2.gameObject.SetActive(false);
                    avatar3.gameObject.SetActive(true);
                    break;
                case 3:
                    _activeAvatar = 4;
                    avatar3.gameObject.SetActive(false);
                    avatar4.gameObject.SetActive(true);
                    break;
                case 4:
                    _activeAvatar = 5;
                    avatar4.gameObject.SetActive(false);
                    avatar5.gameObject.SetActive(true);
                    break;
                case 5:
                    _activeAvatar = 1;
                    avatar5.gameObject.SetActive(false);
                    avatar1.gameObject.SetActive(true);
                    break;

            }
        }
        
    }
}
