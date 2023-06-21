using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollView : MonoBehaviour
{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;

    [SerializeField] private Transform parent;
    private List<Transform> children = new List<Transform>();
    
    private float spacing;

    private IEnumerator Start()
    {
        yield return null;

        foreach (Transform o in parent)
        {
            children.Add(o);
        }
        
        spacing = children[0].position.y - children[3].position.y;
    }

    private void Update()
    {
        foreach (Transform child in children)
        {
            if (child.transform.position.y > top.position.y)
            {
                Transform lastChild = parent.GetChild(children.Count - 2);
                float newY = lastChild.position.y - spacing;
                child.position = new Vector3(child.position.x, newY, child.position.z);
                child.SetSiblingIndex(children.Count - 1);
            }

            if (child.position.y < bottom.position.y)
            {
                Transform lastChild = parent.GetChild(1);
                float newY = lastChild.position.y + spacing;
                child.position = new Vector3(child.position.x, newY, child.position.z);
                child.SetSiblingIndex(0);
            }
        }
    }
}