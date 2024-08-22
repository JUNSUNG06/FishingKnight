using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterDialogue : CharacterComponent
{
    [SerializeField] private UIInputSO input;

    [Space]
    [SerializeField] private string speakerName;

    private List<DialogueAction> dialogueActions;
    private int currentActionIndex;

    private DialogueUIPanel dialogueUIPanel;

    protected Entity dialoguePartner;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        dialogueActions = new List<DialogueAction>();
        
        currentActionIndex = 0;
    }

    public override void PostInitialize()
    {
        base.PostInitialize();

        SetDialogueUIPanel();
    }

    protected virtual void SetDialogueUIPanel()
    {
        dialogueUIPanel = Manager.UI.MainCanvas.GetPanel<DialogueUIPanel>();
    }

    protected void AddDialogueAction(DialogueAction dialogueAction)
    {
        dialogueActions.Add(dialogueAction);    
    }

    public void StartDialogue(Entity partner)
    {
        if (dialogueActions == null)
            return;
        
        dialoguePartner = partner;

        currentActionIndex = -1;

        dialogueUIPanel.SetSpeakerName(speakerName);
        dialogueUIPanel.Show();
        ShowDialogue();

        input.RegistAction(UIInputActionType.Select, ShowDialogueByInput);
    }

    private void ShowDialogue()
    {
        Debug.Log("show");
        if(currentActionIndex == dialogueActions.Count)
        {
            //Debug.Log(currentActionIndex);
            EndDialogue();

            return;
        }
        //Debug.Log($"curent Index : {currentActionIndex}");
        dialogueUIPanel.ShowDialogue(dialogueActions[++currentActionIndex]);
    }

    private void ShowDialogueByInput(CallbackContext context)
    {
        if (context.started)
        {
            if (dialogueActions[currentActionIndex].ActionType == DialogueActionType.Talk)
            {
                ShowDialogue();
            }
        }
    }

    protected void EndDialogue()
    {
        input.UnregistAction(UIInputActionType.Select, ShowDialogueByInput);
        Manager.UI.HidePanel();
    }
}
