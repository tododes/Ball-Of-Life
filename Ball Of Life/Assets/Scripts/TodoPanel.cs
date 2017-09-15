using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TODOENGINE
{
    public class TD_PANEL : MonoBehaviour
    {
        protected RectTransform myRect;

        protected virtual void Start()
        {
            myRect = GetComponent<RectTransform>();
        }

        public IEnumerator TD_ZoomingIn(float speed, float target)
        { 
            while(myRect.position.x < target)
            {
                myRect.position = new Vector3(myRect.position.x + speed * Time.deltaTime, myRect.position.y + speed * Time.deltaTime, myRect.position.z);
            }
            yield return null;
        }

        public IEnumerator TD_ZoomingOut(float speed, float target)
        {
            while (myRect.position.x > target)
            {
                myRect.position = new Vector3(myRect.position.x - speed * Time.deltaTime, myRect.position.y - speed * Time.deltaTime, myRect.position.z);
            }
            yield return null;
        }
    }

    public class TD_CHARACTER : MonoBehaviour
    {
        public float MaxHP, HP;
        public float MaxMana, Mana;
        public float Attack, OAttack;
        public float Armor, OArmor;
        public float Speed, OSpeed;
        public int Evasion, OEvasion;
        protected NavMeshAgent AI;

        public virtual void Awake()
        {
            AI = GetComponent<NavMeshAgent>();
        }

        public virtual void TD_GETDAMAGE(float damage, TD_CHARACTER Origin)
        {
            HP -= (damage - Armor);
        }

        public virtual void TD_GETDAMAGE_WITHEVASION(float damage, TD_CHARACTER Origin)
        {
            int r = Random.Range(0, 100);
            if (r < Evasion)
                HP -= 0f;
            else
                HP -= (damage - Armor);
        }

        public virtual void TD_GETPUREDAMAGE(float damage, TD_CHARACTER Origin)
        {
            HP -= damage;
        }

        public virtual void TD_GETDAMAGEOVERTIME(float damage, TD_CHARACTER Origin)
        {
            HP -= damage * Time.deltaTime;
        }
    }


    public class TD_VOLUME_SLIDER : MonoBehaviour
    {
        public string keyName;
        private Slider mySlider;

        protected void Start()
        {
            mySlider = GetComponent<Slider>();
        }

        public void SetValue()
        {
            PlayerPrefs.SetFloat(keyName, mySlider.value);
        }
    }

    public class TD_LOADING_PANEL : MonoBehaviour
    {
        public GameObject LoadingPanel;

        protected bool loading;
        protected string nextScene;
        protected Image myImage;
        protected float x;
        protected MENUSTATE STATE;
        protected enum MENUSTATE
        {
            PREBEGIN, BEGIN, FINISHED
        }


        protected void Start()
        {
            myImage = GetComponent<Image>();
            loading = false;
            x = 1;
            myImage.color = Color.Lerp(Color.clear, Color.black, x);
        }

        // Update is called once per frame
        protected void Update()
        {
            if (x <= 0f && myImage.enabled)
                myImage.enabled = false;
            if (STATE == MENUSTATE.PREBEGIN && x > 0f)
                x -= 0.8f * Time.deltaTime;
            else if (STATE == MENUSTATE.PREBEGIN && x <= 0f)
                STATE = MENUSTATE.BEGIN;

            if (STATE == MENUSTATE.FINISHED && x < 1f)
            {
                if (!myImage.enabled)
                    myImage.enabled = true;
                x += 0.8f * Time.deltaTime;
            }
            else if (STATE == MENUSTATE.FINISHED && x >= 1f)
            {
                if (!loading)
                {
                    StartCoroutine(LoadingScreen());
                    loading = true;
                }
            }

            myImage.color = Color.Lerp(Color.clear, Color.black, x);
        }

        public void FinishScene(string x)
        {
            STATE = MENUSTATE.FINISHED;
            nextScene = x;
        }

        protected IEnumerator LoadingScreen()
        {
            LoadingPanel.SetActive(true);
            yield return new WaitForSeconds(1);
            AsyncOperation async = Application.LoadLevelAsync(nextScene);
            async.allowSceneActivation = true;
            yield return async;
        }
    }

    public class TD_CONFIRMATION_MENU : MonoBehaviour
    {
        private Canvas PauseCanvas, QuitCanvas;
        private TD_LOADING_PANEL loadingPanel;

        public void StartPause()
        {
            PauseCanvas.enabled = true;
            Time.timeScale = 0f;
        }

        public void StopPause()
        {
            PauseCanvas.enabled = false;
            Time.timeScale = 1f;
        }

        public void QuitMenu()
        {
            PauseCanvas.enabled = false;
            QuitCanvas.enabled = true;
        }

        public void QuitConfirmation(string s)
        {
            Time.timeScale = 1f;
            loadingPanel.FinishScene(s);
            QuitCanvas.enabled = false;
        }

        public void QuitNoConfirmation()
        {
            QuitCanvas.enabled = false;
            PauseCanvas.enabled = true;
        }
    }

    public class TD_SCROLLMENU : MonoBehaviour
    {
        protected int index;
        protected float Destination;
        protected float DestinationFactor;

        public float speed;

        public void IncIndex()
        {
            index++;
        }

        public void DecIndex()
        {
            index--;
        }

        public virtual void Update()
        {
            if (transform.position.x < Destination)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (transform.position.x > Destination)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        public void SetDestination()
        {
            Destination = DestinationFactor * index;
        }
    }

    public class TD_DATA_STRUCTURE : MonoBehaviour
    {
        public static void SORT(int low, int high, int[] x)
        {
            int mid = -1;
           
            if (x.Length == 1)
                return;
            if (low < high)
            {
                mid = (low + high) / 2;
                SORT(low, mid, x);
                SORT(mid + 1, high, x);
                MergePriority(low, mid, high, x);
            }
           
        }

        private static void MergePriority(int low, int mid, int high, int[] x)
        {
            int a = low;
            int b = mid + 1;
            int c = low;
            int[] temp = new int[x.Length];
            while (a <= mid && b <= high)
            {
                if (x[a] < x[b])
                {
                    temp[c] = x[a];
                    a++;
                    c++;
                }
                else
                {
                    temp[c] = x[b];
                    b++;
                    c++;
                }
            }
            while (a <= mid)
            {
                temp[c] = x[a];
                a++;
                c++;
            }
            while (b <= high)
            {
                temp[c] = x[b];
                b++;
                c++;
            }

            for (int i = low; i < c; i++)
            {
                x[i] = temp[i];
            }
           
        }
        public static int TDSearch(int left, int right, int[] a, int search)
        {
            int mid;
            if (a.Length == 1)
            {
                return a[0];
            }
            if (left < right)
            { 
                mid = (left + right)/2;
                if (a[mid] == search)
                {
                    return mid;
                }
                if (search < a[mid])
                {
                    return TDSearch(left, mid, a, search);
                }
                if (search > a[mid])
                {
                    return TDSearch(mid+1, right, a, search);
                }
            }
            return -1;
        }
    }

    public class TD_CHARACTER_CONTROL : MonoBehaviour
    {
        public static void TD_WASD(float speed, Rigidbody rigid)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigid.AddForce(Vector3.forward * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rigid.AddForce(Vector3.left * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rigid.AddForce(Vector3.back * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rigid.AddForce(Vector3.right * speed);
            }
        }
    }
}