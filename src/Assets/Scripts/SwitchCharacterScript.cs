using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3, avatar4, avatar5;
    int _activeAvatar = 1;
    public bool manualSwitch = false;
    
     
    //switches for player animations
    public LayerMask kidSwitchLayerMask;
    public LayerMask teenSwitchLayerMask;
    public LayerMask workerSwitchLayerMask;
    public LayerMask oldSwitchLayerMask;
    private bool kidSwitched = false;
    private bool teenSwitched = false;
    private bool workerSwitched = false;
    private bool oldSwitched = false;
    
    public Rigidbody2D rbPlayer;
    public CapsuleCollider2D bcPlayer;


    // Start is called before the first frame update
    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(false);
        avatar5.gameObject.SetActive(false);
        
        //if (!manualSwitch) { InvokeRepeating(nameof(ChangeAvatar), 4.0f, 4.0f); }
    }
    /*
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
    */



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



        if (InKidPhase() && !kidSwitched)
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            kidSwitched = true;
        }
        else if (InTeenPhase() && !teenSwitched)
        {
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(true);
            teenSwitched = true;
        }
        else if (InWorkerPhase() && !workerSwitched)
        {
            avatar3.gameObject.SetActive(false); 
            avatar4.gameObject.SetActive(true);
            workerSwitched = true;
        }
        else if (InOldPhase() && !oldSwitched)
        {
            avatar4.gameObject.SetActive(false);
            avatar5.gameObject.SetActive(true);
            oldSwitched = true;
        }
        
        
        
    }
    
    
    
    
    bool InKidPhase()
    {
        // Cast our current BoxCollider in the current gravity direction.
        var hitInfo = Physics2D.BoxCast(
            bcPlayer.bounds.center, bcPlayer.bounds.size, 
            0.0f, new Vector2(0,1), 0, 
            kidSwitchLayerMask);

        return hitInfo.collider != null;
    }
    bool InTeenPhase()
    {
        // Cast our current BoxCollider in the current gravity direction.
        var hitInfo = Physics2D.BoxCast(
            bcPlayer.bounds.center, bcPlayer.bounds.size, 
            0.0f, new Vector2(0,1), 0, 
            teenSwitchLayerMask);

        return hitInfo.collider != null;
    }
    bool InWorkerPhase()
    {
        // Cast our current BoxCollider in the current gravity direction.
        var hitInfo = Physics2D.BoxCast(
            bcPlayer.bounds.center, bcPlayer.bounds.size, 
            0.0f, new Vector2(0,1), 0, 
            workerSwitchLayerMask);

        return hitInfo.collider != null;
    }
    bool InOldPhase()
    {
        // Cast our current BoxCollider in the current gravity direction.
        var hitInfo = Physics2D.BoxCast(
            bcPlayer.bounds.center, bcPlayer.bounds.size, 
            0.0f, new Vector2(0,1), 0, 
            oldSwitchLayerMask);

        return hitInfo.collider != null;
    }


    
    
    
    
    
    
    
    
    
}
