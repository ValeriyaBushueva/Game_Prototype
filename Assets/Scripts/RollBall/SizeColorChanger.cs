using UnityEngine;

public class SizeColorChanger : MonoBehaviour
{
    [SerializeField] public float baseSize = 1f;

      
    public void Update()
    {
        float animation = baseSize + Mathf.Sin(Time.time * 8f) * baseSize / 7f;
        transform.localScale = Vector3.one * animation;
        
        GenerateColor();
    }
    
    public void GenerateColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void Reset()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.red;
    }

}
