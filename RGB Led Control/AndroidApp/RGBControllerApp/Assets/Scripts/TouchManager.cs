using System;
using UnityEngine;
using System.Collections;

public delegate void DelegateClickBegan();
public delegate void DelegateClickEnded();
public delegate void DelegateSwipeRight ();
public delegate void DelegateSwipeLeft();
public delegate void DelegateSwipeUp();
public delegate void DelegateSwipeDown();


public class TouchManager
{

    public DelegateClickBegan delClickBegan;
    public DelegateClickEnded DelClickEnded;
    public DelegateSwipeRight delSwipeRight;
    public DelegateSwipeLeft delSwipeLeft;
    public DelegateSwipeUp delSwipeUp;
    public DelegateSwipeDown delSwipeDown;

    private float minPosChange = 2f;
    private Vector2 lastTouch, currentTouch;
    private static TouchManager instance;


    private TouchManager()
    {
        lastTouch = new Vector2(0, 0);
    }

    public void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
            lastTouch = Input.mousePosition;
        if (Input.GetMouseButton(0))
            currentTouch = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
                if (IsRightSwipe())
                    state = ETouch.SwipeRight;
                else if (IsLeftSwipe())
                    state = ETouch.SwipeLeft;
                else if(IsUpSwipe())
                    state = ETouch.SwipeUp;
                else if (IsDownSwipe())
                    state = ETouch.SwipeDown;
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            //delClickBegan();
            lastTouch = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentTouch = Input.mousePosition;
         
        }
        if (Input.GetMouseButtonUp(0))
            if (IsRightSwipe())
                delSwipeRight();
            else if (IsLeftSwipe())
                delSwipeLeft();
            else if (IsUpSwipe())
                delSwipeUp();
            else if (IsDownSwipe())
                delSwipeDown();
       
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            currentTouch = Input.GetTouch(0).position;

            if (GetTouchPhaseOfTouch(0) == TouchPhase.Began)
            {
                lastTouch = Input.GetTouch(0).position;
            }
            if ((GetTouchPhaseOfTouch(0) == TouchPhase.Ended || GetTouchPhaseOfTouch(0) == TouchPhase.Canceled))
            {
                if (IsRightSwipe())
                    delSwipeRight();
                else if (IsLeftSwipe())
                    delSwipeLeft();
                else if (IsUpSwipe())
                    delSwipeUp();
                else if (IsDownSwipe())
                    delSwipeDown();
        
            }
        }
#endif

    }

    public static TouchManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TouchManager();
            }
            return instance;
        }
    }

    public float MinPosChange
    {
        get { return minPosChange; }
        set { minPosChange = value; }
    }



    private TouchPhase GetTouchPhaseOfTouch(int i)
    {
        return Input.GetTouch(i).phase;
    }

    private bool IsUpSwipe()
    {
        return (currentTouch.y > lastTouch.y + minPosChange) && Mathf.Abs(currentTouch.x - lastTouch.x) < Mathf.Abs(currentTouch.y - lastTouch.y);
    }

    private bool IsDownSwipe()
    {
        return (currentTouch.y + minPosChange < lastTouch.y) && Mathf.Abs(currentTouch.x - lastTouch.x) < Mathf.Abs(currentTouch.y - lastTouch.y);
    }

    private bool IsRightSwipe()
    {
        return (currentTouch.x > lastTouch.x + minPosChange) && Mathf.Abs(currentTouch.x - lastTouch.x) > Mathf.Abs(currentTouch.y - lastTouch.y);
    }

    private bool IsLeftSwipe()
    {
        return (currentTouch.x + minPosChange < lastTouch.x) && Mathf.Abs(currentTouch.x - lastTouch.x) > Mathf.Abs(currentTouch.y - lastTouch.y);
    }



}
