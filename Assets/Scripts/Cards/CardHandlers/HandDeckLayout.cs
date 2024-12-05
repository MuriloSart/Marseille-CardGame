using System.Collections.Generic;
using UnityEngine;

public class HandDeckLayout : MonoBehaviour
{
    public List<Vector3> gameObjects;
    void Start()
    {
        float largura = this.gameObject.GetComponent<RectTransform>().rect.width;
        float StartPosition = this.gameObject.transform.position.x - largura/2;

        foreach(Transform t in transform)
        {
            gameObjects.Add(t.localPosition);
        }
    }
}
