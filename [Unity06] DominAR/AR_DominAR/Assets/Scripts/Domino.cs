using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    public enum Select { None, Temp, Formal }
    public Select select { get; set; } = Select.None;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private Rigidbody rigidbody2;

    public Vector3 defaultScale { get; private set; }

    public Vector3 position { get; private set; }
    public float rotation { get; set; } = 0f;
    public float scale { get; set; } = 1f;
    public Color color { get; set; }

    private List<Domino> dominoes = new List<Domino>();
    private bool isTransparentizing = true;
    private float alpha = 1f;

    public static Domino InstantiateDomino(
        GameObject prefab, Vector3 position, float rotation, float scale, Color color)
    {
        if (prefab == null) return null;

        GameObject obj = 
            Instantiate(prefab, position, Quaternion.Euler(0f, rotation, 0f));
        Domino domino = obj.GetComponent<Domino>();
        if (domino != null)
        {
            domino.meshRenderer = domino.GetComponent<MeshRenderer>();
            domino.boxCollider = domino.GetComponent<BoxCollider>();
            domino.rigidbody2 = domino.GetComponent<Rigidbody>();

            domino.defaultScale = domino.transform.localScale;

            domino.rotation = rotation;
            domino.scale = scale;
            domino.color = color;

            domino.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
            domino.transform.localScale *= scale;

            return domino;
        }
        else
        {
            Destroy(obj);
        }
        
        return null;
    }

    private void Update()
    {
        switch (select)
        {
            case Select.None:
                if(meshRenderer != null)
                    meshRenderer.material.color = color;
                break;
            case Select.Temp:
                if (meshRenderer != null)
                    meshRenderer.material.color = Color.Lerp(color, Color.clear, 0.5f);
                break;
            case Select.Formal:
                if (isTransparentizing)
                {
                    alpha -= Time.deltaTime * 3f;
                    if (alpha <= 0f)
                    {
                        alpha = 0f;
                        isTransparentizing = false;
                    }
                }
                else
                {
                    alpha += Time.deltaTime * 3f;
                    if (alpha >= 1f)
                    {
                        alpha = 1f;
                        isTransparentizing = true;
                    }
                }
                if (meshRenderer != null)
                    meshRenderer.material.color =  new Color(color.r, color.g, color.b, alpha);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Domino domino = other.GetComponent<Domino>();
        if (domino != null)
        {
            dominoes.Add(domino);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Domino domino = other.GetComponent<Domino>();
        if (domino != null)
        {
            dominoes.Remove(domino);
        }
    }

    public bool PlaceEnable()
    {
        if (dominoes.Count > 0)
        {
            return false;
        }

        return true;
    }

    public void SetSelect()
    {
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);

        if (boxCollider != null)
        {
            boxCollider.isTrigger = true;
        }

        if (rigidbody2 != null)
        {
            rigidbody2.useGravity = false;
        }
    }

    public void SetPlace()
    {
        position = transform.position;

        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }

        if (rigidbody2 != null)
        {
            rigidbody2.useGravity = true;
        }
    }

    public void AddForce(Vector3 normal)
    {
        if (rigidbody2 != null)
        {
            Vector3 force = -normal * 15f;
            Vector3 position = 
                transform.position + Vector3.up * transform.localScale.y / 2f;
            rigidbody2.AddForceAtPosition(force, position);
        }
    }
}
