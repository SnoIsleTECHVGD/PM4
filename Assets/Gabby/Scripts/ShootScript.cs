using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public int speed = 5;
    public int distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = 150;
    }

    public IEnumerator shoot(float xLocation, float yLocation)
    {
        yield return new WaitForSeconds(0.001f);
        int rise = (int) (yLocation - transform.position.y);
        int run = (int) (xLocation - transform.position.x);
        bool risePos = true;
        bool runPos = true;
        if (rise < 0)
        {
            risePos = false;
        }
        if (run < 0)
        {
            runPos = false;
        }
        rise = System.Math.Abs(rise);
        run = System.Math.Abs(run);
        for (int r = distance; r > 0; r--)
        {
            for (int i = rise; i > 0; i--)
            {
                if (!risePos)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
                else if (risePos)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            for (int k = run; k > 0; k--)
            {
                if (!runPos)
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if (runPos)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
            }
            yield return new WaitForSeconds(0.002f);
        }
        
    }

    public void shootWithCoroutine(float xLocation, float yLocation, float xStart, float yStart)
    {
     GetComponent<Transform>().position = new Vector3(xStart, yStart, 0);
        StartCoroutine(shoot(xLocation, yLocation));
    }
}
