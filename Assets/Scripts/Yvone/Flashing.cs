using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public Image pressToProceedText;
    public float animSpeedInSec = 1f;
    bool keepAnimating = false;

    private IEnumerator anim()
    {
        Color currentColor = pressToProceedText.color;

        Color invisibleColor = pressToProceedText.color;
        invisibleColor.a = 0; //set alpha to 0

        float oldAnimSpeedInSec = animSpeedInSec;
        float counter = 0;
        while (keepAnimating)
        {
            //hide slowly
            while (counter < oldAnimSpeedInSec)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //reset counter when speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter += Time.deltaTime;
                pressToProceedText.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
            yield return null;

            //show slowly
            while (counter > 0)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //reset counter when speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter -= Time.deltaTime;
                pressToProceedText.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
        }
    }

    void startTextMeshAnimation()
    {
        if (keepAnimating)
        {
            return;
        }
        keepAnimating = true;
        StartCoroutine(anim());
    }

    /*
    void changeTextMeshAnimationSpeed(float animSpeed)
    {
        animSpeedInSec = animSpeed;
    }

    void stopTextMeshAnimation()
    {
        keepAnimating = false;
    }
    */

    void Update()
    {
        startTextMeshAnimation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            //Spawner.levelStarted = true;
            //FindObjectOfType<AudioManager>().Play("Wave");
        }
    }
}