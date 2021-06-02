using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Score: " + Player.Instance.score;
    }
}
