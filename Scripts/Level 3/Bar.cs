//using UnityEngine;

//public class Bar : MonoBehaviour
//{
//    public GameObject bar;
//    public int time;

//    public static bool isAnimate;
//    private bool isStarted;
//    public static bool stop;

//    void Start()
//    {
//        stop = false;
//        isAnimate = false;
//        isStarted = false;
//    }

//    void Update()
//    {
//        //if(stop)
//        //{
//        //    LeanTween.pauseAll();
//        //}

//        if(isAnimate && !isStarted)
//        {
//            AnimateBar();
//            isStarted = true;
//        }
//    }

//    public void AnimateBar()
//    {
//        LeanTween.scaleY(bar, 1, time);
//    }
//}
