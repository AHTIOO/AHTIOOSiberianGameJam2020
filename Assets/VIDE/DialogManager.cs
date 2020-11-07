using UnityEngine;
using System.Collections;
using VIDE_Data; //Access VD class to retrieve node data
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject container_NPC;
    public GameObject container_PLAYER;
    public Text text_NPC;
    public Text[] text_Choices;
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        VD.LoadDialogues();
        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) &&(VD.isActive))
        {
            VD.Next();
        }
    }

    public void Begin(string dialog, Character character)
    {
        Debug.Log("!");
        VIDE_Assign Dial = GetComponent<VIDE_Assign>();
        Dial.alias = "Кеноби";
        Dial.assignedDialogue = dialog;
        print((string)VD.nodeData.extraVars["avaleble"]);
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
    }

    void UpdateUI(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
        if (data.isPlayer)
        {
            container_PLAYER.SetActive(true);
            for (int i = 0; i < text_Choices.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    text_Choices[i].transform.parent.gameObject.SetActive(true);
                    text_Choices[i].text = data.comments[i];
                }
                else
                {
                    text_Choices[i].transform.parent.gameObject.SetActive(false);
                }
            }
            text_Choices[0].transform.parent.GetComponent<Button>().Select();
        }
        else
        {
            container_NPC.SetActive(true);
            text_NPC.text = data.comments[data.commentIndex];
            //Play Audio if any
            if (audioSource != null)
            {
                if (data.audios[data.commentIndex] != null)
                    audioSource.clip = data.audios[data.commentIndex];
                audioSource.Play();
            }
        }
    }


    void End(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    void OnDisable()
    {
        if (container_NPC != null)
            End(null);
    }

    public void SetPlayerChoice(int choice)
    {
       VD.nodeData.commentIndex = choice;
       if (Input.GetMouseButtonUp(0))
            VD.Next();
    }
}
