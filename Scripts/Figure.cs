using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Figure : MonoBehaviour
{
    public static Figure figure { get; private set; }

    [SerializeField] private ParticleSystem ps;

    private Vector3 rotation;

    private void Awake()
    {
        figure = this;
    }

    private void Start()
    {
        rotation = new Vector3(Random.Range(-180f, 180f), Random.Range(-180, 180f), Random.Range(-180f, 180f));
    }

    private void Update()
    {
        if (GameManager.isStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, Finish.finish.transform.position, Time.deltaTime * GameManager.gameManager._speed);
            transform.RotateAround(transform.position, rotation, Time.deltaTime * 200);
            if (transform.localPosition.z < -24f) Destroy(gameObject);
        }
    }

    public void OnMouseDown()
    {
        Firework();
        Destroy(gameObject);
        GameManager.score++;
        UI.ui.Info();
    }

    public void Firework()
    {
        ParticleSystem firework = Instantiate(ps, transform.position, Quaternion.identity);
        firework.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
        firework.GetComponent<ParticleSystem>().Play();
        Destroy(firework, 1f);
    }
}
