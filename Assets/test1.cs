using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{
   // [SerializeField] Image image;
    public Queue<string> Text = new Queue<string>();
    [SerializeField] Text text;
    public string[] sentences = new string[] { "gererge", "greg" };
    void Start()
    {
        foreach (var item in sentences)
        {
            Text.Enqueue(item);
        }
        
       // StartCoroutine(test(2000));
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1f;
        //image.fillAmount -= Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.text = Text.Dequeue();
            //image.fillAmount += 0.2f;
        }
        
    }
    class Dialog
    {
        
    }
    //IEnumerator test(int amount)
    //{
    //    for (int i = 100; i < amount; i++)
    //    {
    //        if (amount - i > 168)
    //        {
    //            i += 168;
    //        }
    //        else
    //        {
    //            i += amount - i;
    //        }
            
    //        yield return new WaitForSeconds(0.1f);
    //        text.text = i.ToString();
    //    }
        
    //}
}
