using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float timeValue = 0;
    private TextMeshPro _time;
    
    // Start is called before the first frame update
    void Start()
    {
        _time = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        timeValue += Time.deltaTime;
        _time.SetText("Time to grow up: " + timeValue);
    }
}
