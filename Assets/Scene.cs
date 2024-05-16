using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    public GameObject killer;
    public Canvas deathcanvas;
    public Image panel;
    public TextMeshProUGUI deathScreen;
    public GameObject player;

    public bool dead = false;
    private float alpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Death();
            deathScreen.text = "You Died";
            deathcanvas.enabled = enabled;
        }
    }

    private void FixedUpdate()
    {
        if (dead)
        {
            panel.color = new Color(0, 0, 0, alpha);
            alpha += 0.3f * Time.deltaTime;
            
            if (alpha > 1)
            {
                dead = false;
                alpha = 0f;
                RestartScene();
            }
        }
        
    }
    public void Death()
    {
        player.gameObject.GetComponent<CharcMove>().pause = true;
        Instantiate(killer, transform.position + new Vector3(0, 2f, 0), transform.rotation, transform);
        gameObject.GetComponent<CharcMove>().enabled = false;
        dead = true;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
