using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class PlayerData
{
    public float x, y, z;

    public PlayerData(Vector3 sp)
    {
        x = sp.x;
        y = sp.y;
        z = sp.z;
    }

    public PlayerData()
    {

    }
}

public class Player : MonoBehaviour {

    private static Player playerInstance;
    private Rigidbody rigid;

    [SerializeField]
    private Vector3 CheckPointPos;

    PlayerData playerSaveData;
    PlayerData playerLoadData;

    protected Vector3 RotationRate;

    public bool OnLadder;
    [SerializeField]
    private bool OnSlope;

    public Transform ItemHolder;
    public MirrorBox box;

    [SerializeField]
    private bool OnTheRope;
    private Transform Rope;

 
	// Use this for initialization
	void Awake () 
    {
        playerInstance = this;
        OnLadder = false;
        OnSlope = false;
        playerLoadData = LoadData();
        
       
        //transform.position = new Vector3(playerLoadData.x, playerLoadData.y, playerLoadData.z);
        rigid = GetComponent<Rigidbody>();
        RotationRate = new Vector3(0, 0, 270);
        ItemHolder = GetComponentInChildren<Transform>();
	}
	
    public static Player GetPlayerInstance()
    {
        return playerInstance;
    }

    void Update()
    {
        if (OnTheRope)
        {
            transform.position = Rope.position;
        }
    }
	// Update is called once per frame
	void FixedUpdate () 
    {
	    if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(RotationRate * -1f * Time.deltaTime);
            Walk(Vector3.right);
            rigid.constraints = RigidbodyConstraints.None;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(RotationRate * Time.deltaTime);
            Walk(Vector3.right * -1);
            rigid.constraints = RigidbodyConstraints.None;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !OnSlope)
        {
            rigid.constraints = RigidbodyConstraints.FreezePositionX;
        }

        if(transform.position.y < -12f)
        {
            SaveData();
            Application.LoadLevel(Application.loadedLevelName);
        }
        rigid.useGravity = !OnLadder;

       
	}

    public void Walk(Vector3 dir)
    {
        rigid.MovePosition(transform.position + dir * 3f * Time.deltaTime);
    }

    void JumpForce()
    {
        if (OnTheRope)
            OnTheRope = false;
        rigid.AddForce(new Vector3(0, 13, 0), ForceMode.Impulse);
    }

    public void GetJumpForce(float force)
    {
        if (OnTheRope)
            OnTheRope = false;
        //Debug.Log("GET "+force);
        rigid.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.name == "Checkpoint")
        {
            Debug.Log("Into checkpoint");
            CheckPointPos = coll.gameObject.transform.position;
        }
        else if (coll.name == "Bat Die Trigger")
        {
            Debug.Log("Bat Die");
        }
        else if (coll.name == "Bat" || coll.gameObject.name.Contains("trap") || coll.name.Contains("Falling Ice") || coll.name.Contains("Fire"))
        {
            Debug.Log(coll.gameObject.name + "Die");
            BlackImage.GetBlackImage().FinishScene(Application.loadedLevelName);
        }
        else if (coll.tag == "Next Scene Connector")
            BlackImage.GetBlackImage().FinishScene(Game.GetGame().NextScene);
      
        if (coll.tag == "Ladder")
        {
            OnLadder = true;
        }
        if(coll.name.Contains("Crystal"))
        {
            Game.GetGame().AddCrystal(1);
            Destroy(coll.gameObject);
        }

        if(coll.name.Contains("Switch"))
        {
            coll.GetComponent<Switch>().canSwitch = true;
        }
        if(coll.name.Contains("Special box"))
        {
            coll.GetComponent<MirrorBox>().EnableMirror();

            Destroy(coll.gameObject);
        }

        if(coll.name.Contains("treasure"))
        {
            if(coll.GetComponent<Treasure>().Name == "Dark")
            {
                if(coll.GetComponent<SpriteRenderer>().enabled)
                {
                    if (!Game.GetGame().gemNames.Contains(coll.GetComponent<Treasure>().Name))
                    {
                        Game.GetGame().AddGemName(coll.GetComponent<Treasure>().Name);
                        Game.GetGame().AddSprites(coll.GetComponent<Treasure>().OriSprite);
                    }
                }
            }
            else
            {
                if (!Game.GetGame().gemNames.Contains(coll.GetComponent<Treasure>().Name))
                {
                    Game.GetGame().AddGemName(coll.GetComponent<Treasure>().Name);
                    Game.GetGame().AddSprites(coll.GetComponent<Treasure>().OriSprite);
                }
              
            }
           
        }
        if(coll.name == "RopeRoot")
        {
            OnTheRope = true;
            Rope = coll.transform;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Ladder")
        {
            OnLadder = false;
        }
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.collider.name.Contains("Slope Cube"))
        {
            OnSlope = true;
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.collider.name.Contains("Slope Cube"))
        {
            OnSlope = false;
            rigid.constraints = RigidbodyConstraints.FreezePositionX;
        }
    }

    void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        playerSaveData = new PlayerData(CheckPointPos);
        using(FileStream file = File.Create("Player Data.dat"))
        {
            bf.Serialize(file, playerSaveData);
        }
    }

    PlayerData LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerData pd = new PlayerData();
        using (FileStream file = File.Open("Player Data.dat", FileMode.Open))
        {
            pd = (PlayerData)bf.Deserialize(file);
        }
        return pd;
    }

   
}
