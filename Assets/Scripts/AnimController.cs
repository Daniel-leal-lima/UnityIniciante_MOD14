using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] float returnTime;
    [SerializeField] AnimationCurve animCurve =  new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    const string ANIMIDBOUNCE = "Bounce";
    public void Bounce()
    {
        anim.Play(ANIMIDBOUNCE);
        StartCoroutine(nameof(test));
    }

    public void Stop()
    {
        anim.Stop();
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(anim[ANIMIDBOUNCE].clip.length);
        Vector3 localPosition = transform.localPosition;
        float initialYValue = localPosition.y;
        float estimatedTime = returnTime;
        float elapsedTime = 0;
        while (elapsedTime < estimatedTime)
        {
            float interpolation = elapsedTime / estimatedTime;
            float yValue = Mathf.Lerp(initialYValue, 0, animCurve.Evaluate(interpolation));
            transform.localPosition = new Vector3(localPosition.x, yValue, localPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = new Vector3(localPosition.x, 0, localPosition.z);

    }
}
