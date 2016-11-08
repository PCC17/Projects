using UnityEngine;
using System.Collections;

public class TouchManager
{
    public enum ETouch
    {
        Ended,
        SwipeUp,
        SwipeRight,
        SwipeDown,
        SwipeLeft,
        Null
    };
    private float minPosChange = 2f;
    private ETouch state;
    private Vector2 lastTouch, currentTouch;
    private bool isNewMove = false;
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
            lastTouch = Input.mousePosition;
            isNewMove = true;
        }
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

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            currentTouch = Input.GetTouch(0).position;

            if (GetTouchPhaseOfTouch(0) == TouchPhase.Began)
            {
                lastTouch = Input.GetTouch(0).position;
                isNewMove = true;
            }
            if ((GetTouchPhaseOfTouch(0) == TouchPhase.Ended || GetTouchPhaseOfTouch(0) == TouchPhase.Canceled) && isNewMove)
            {
                if (IsRightSwipe())
                    state = ETouch.SwipeRight;
                else if (IsLeftSwipe())
                    state = ETouch.SwipeLeft;
                else if (IsUpSwipe())
                    state = ETouch.SwipeUp;
                else if (IsDownSwipe())
                    state = ETouch.SwipeDown;
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

    public ETouch State
    {
        get {
            if (isNewMove)
            {
                return state;
            }
            return ETouch.Null;
        }
    }

    public void Reset()
    {
        isNewMove = false;
        state = ETouch.Null;
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
