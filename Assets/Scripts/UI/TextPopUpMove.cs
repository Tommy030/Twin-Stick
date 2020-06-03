using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextPopUpMove : MonoBehaviour
{
    public float SpeedOfGoingUp;
    public float Timer;
    TextMeshProUGUI Text;
    Color TextC;
    Color OldC;
    private void Awake()
    {
        
        Text = GetComponent<TextMeshProUGUI>();
        OldC = Text.color;
        TextC = Text.color;
    }
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            float Speed = 3f;
            TextC.a -= Speed * Time.deltaTime;
            Text.color = TextC;
            if (TextC.a <= 0)
            {
                TextC = OldC;
                Text.color = OldC;
                gameObject.SetActive(false);

            }
        }
        transform.position += new Vector3(0, SpeedOfGoingUp) * Time.deltaTime;
    }
}
