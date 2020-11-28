using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackAndFade : MonoBehaviour
{
    private float i;
    public float fadeDuration;
    
    public Image img1;
    public Image img2;
    public Text txt1;
    public Text txt2;

    public float speed;

    private void OnEnable()
    {
        i = 1;
        transform.localPosition = new Vector3(-574f, 194f);
        img1.color = new Color(img1.color.r, img1.color.g, img1.color.b, 1f);
        img2.color = new Color(img2.color.r, img2.color.g, img2.color.b, 1f);
        txt1.color = new Color(txt1.color.r, txt1.color.g, txt1.color.b, 1f);
        txt2.color = new Color(txt2.color.r, txt2.color.g, txt2.color.b, 1f);
    }



    void Update()
    {
        if (i > 0)
        {
            img1.color = new Color(img1.color.r, img1.color.g, img1.color.b, i);
            img2.color = new Color(img2.color.r, img2.color.g, img2.color.b, i);
            txt1.color = new Color(txt1.color.r, txt1.color.g, txt1.color.b, i);
            txt2.color = new Color(txt2.color.r, txt2.color.g, txt2.color.b, i);

            i -= Time.deltaTime / fadeDuration;
            if (i <= 0) i = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime);
    }

    
        
  
}
