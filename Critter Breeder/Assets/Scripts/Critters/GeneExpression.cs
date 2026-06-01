using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneExpression : MonoBehaviour
{
    public Sprite[] bodies;
    public Genes genes;

    Dictionary<string, Sprite> bodySprites = new Dictionary<string, Sprite>();

    private void Start()
    {
        foreach (Sprite sprite in bodies)
        {
            bodySprites.Add(sprite.name, sprite);
        }

        genes = GetComponent<Genes>();

        setBody();
        setColor();
        setSize();        
    }
    void setColor()
    {
        Color mix = Color.Lerp(genes.color_1, genes.color_2, 0.5f);
        GetComponent<SpriteRenderer>().color = mix;
    }

    void setBody()
    {
        GetComponent<SpriteRenderer>().sprite = bodySprites[GetComponent<Genes>().body_1.ToString()];
    }

    void setSize()
    {
        float avgSize = (genes.size_1 + genes.size_2)/2;

        gameObject.transform.localScale = new Vector3(avgSize, avgSize, avgSize);
    }
}
