using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    private float fadeTime = 0.1f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("TwinkleLoop");
    }

    private IEnumerator TwinkleLoop()
    {
        while(true)
        {
            // Alpha 값을 1에서 0으로 : FadeOut
            yield return StartCoroutine(FadeEffect(1, 0));
            // Alpha 값을 0에서 1로 : Fade In
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }

    private IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            // fadeTime 시간동안 while 문 실행
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            // 유니티 클래스에 설정되어 있는 spriteRenderer.colo, transform.position은 property로
            // spriteRenderer.color.a = 1.0f 와 같이 설정 불가능하다
            // spriteRenderer.color = new Color(spriteRenderer.color.r , ... , .. , 1.0f) 와 같이 설정해야 한다.

            Color color = spriteRenderer.color;
            // start와 end 사이의 값중 percent 위치에 있는 값을 반환 ex) 0, 100일때 percent가 0.3이면 30을 반환
            color.a = Mathf.Lerp(start, end, percent);
            spriteRenderer.color = color;

            yield return null;
        }
    }






    /*
     * Desc
     * 코루틴 메소드의 yield return 문항에서 StartCoroutine()을 실행할 경우 
     * StartCoroutine()의 코루틴이 모두 끝나야 다음 문항으로 넘어갈 수 있다.
     */

}
