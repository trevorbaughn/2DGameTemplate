using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Responsibility : MonoBehaviour
{
    #region Variables

    [Header("Responsibility")]
    public float max;
    [SerializeField] private float _animationSpeed;
    public ResponsibilityBar bar;
    public UnityEvent OnResponsibilityMaxed = new UnityEvent(); //basically a delegate, but is a UnityEvent


    private bool isRunning = false;
    private Coroutine running;
    [SerializeField]  private float _animated;
    public float animated
    {
        get { return _animated; }
        set {
            //stop coroutine if already running
            if (isRunning == true)
            {
                StopCoroutine(running);
                isRunning = false;
            }

            
            //add the different between the animation and actual current.
            //'set' is the time it takes to do so
            running = StartCoroutine(AddTo(current - _animated, value));
        }
    }

    [SerializeField] private float _current;
    public float current
    {
        get { return _current; }
        set
        {
            _current = Mathf.Clamp(value, 0, max);
            animated = _animationSpeed; //sets speed at which animation should go using a setter
            //put "death" check here if not based on animated
        }
    }

    #endregion



    //responsibility change delegate
    public delegate void Change(int toChange, float changeBy, float waitBetween);
    public Change change;



    /// <summary>
    /// Actually add the responsibility, bit by bit for animation
    /// </summary>
    /// <param name="toAdd"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator AddTo(float toAdd, float time)
    {
        isRunning = true;
        float startTime = time;
        float startAnimated = _animated;
        while (true)
        {
            //add portions of toAdd over time
            _animated += (toAdd / startTime) * Time.deltaTime;


            time -= Time.deltaTime;
            if (time > 0)
            {
                yield return null;
            }
            else
            {
                isRunning = false;
                _animated = startAnimated + toAdd;

                //invoke all listeners for the event when maxed
                if (_animated == max)
                {
                    OnResponsibilityMaxed.Invoke(); 
                }
                break;
            }
        }
    }


    //test stuff for events below this point

    //private void OnEnable()
    //{
    //    OnResponsibilityMaxed.AddListener(SuccessTest); //adding SuccessTest as a listener
    //    Debug.Log("Enabled");
    //}

    //private void OnDisable()
    //{
    //    OnResponsibilityMaxed.RemoveListener(SuccessTest); //removing SuccessTest as a listener
    //    Debug.Log("Disabled");
    //}

    //void SuccessTest() 
    //{
    //    Debug.Log("Success");
    //}



}
