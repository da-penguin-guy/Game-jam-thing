using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.Playables;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] idle, moving, shooting, reloading, talking, dying;
    public AnimatorState currentState;
    public AnimatorState tempState;
    public SpriteRenderer renderer;
    public int currentSprite;
    public float timer;
    public float frameRate;
    public void Init()
    {
        currentSprite = 0;
        renderer.sprite = GetCurrentAnims()[currentSprite];
    }
    public void PlayAnim(AnimatorState state)
    {
        tempState = state;
    }
    public void PlayAnimWait(AnimatorState state)
    {
        currentState = state; 
    }
    public void UpdateSprite()
    {
        timer += Time.deltaTime;
        if (timer > 1/frameRate)
        {
            currentSprite = (currentSprite + 1) % GetCurrentAnims().Length;
            renderer.sprite = GetCurrentAnims()[currentSprite];
            timer -= 1/frameRate;
            if(currentSprite == 0)
            {
                OnAnimFinished();
            }
        }
    }
    public void OnAnimFinished()
    {
        tempState = currentState;
    }
    Sprite[] GetCurrentAnims()
    {
        if(tempState == AnimatorState.Idle)
        {
            return idle;
        }
        if(tempState == AnimatorState.Moving)
        {
            return moving;
        }
        if(tempState == AnimatorState.Shooting)
        {
            return shooting;
        }
        if(tempState == AnimatorState.Reloading)
        {
            return reloading;
        }
        if(tempState == AnimatorState.Talking)
        {
            return talking;
        }
        if(tempState == AnimatorState.Dying)
        {
            return dying;
        }
        return idle;
    }
}
public enum AnimatorState
{
    Idle,Moving,Shooting,Reloading,Talking,Dying
}
