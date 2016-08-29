using System.Collections.Generic;
using Assets.Scripts.BattleUI.ActionSelectUI;
using Assets.Scripts.GameLogic.ActionLogic;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.BattleUI.ActionUI {

    public class ActionUIController : MonoBehaviour {

        public delegate void ConfirmActionHandler(Action confirmedAction, Actor target);

        public delegate void SelectActionHandler(Action selectedAction);

        public event ConfirmActionHandler ConfirmActionEvent;
        public event SelectActionHandler SelectActionEvent;

        private ICollection<ActionButton> actionButtons = new HashSet<ActionButton>();


        private ConfirmActionButton ConfirmButton {
            get { return GetComponentInChildren<ConfirmActionButton>(true); }
        }


        public void ActivateSelection(ICollection<Action> actions, Action defaultAction) {
            Debug.Log("Action selection activated");
            foreach (Action action in actions) CreateActionButton(action);
            ActivateConfirmButton();
        }


        private void Deactivate() {
            Debug.Log("Hero action UI deactivated");
            DestroyActionButtons();
            DeactivateConfirmButton();
        }


        private void OnConfirmButtonClick() {
            if (ConfirmActionEvent != null) {
                Deactivate();
                
            }
        }


        private void OnActionButtonClick(ActionButton button) {
            if (SelectActionEvent != null)
                SelectActionEvent(button.AssignedAction);
        }


        private void ActivateConfirmButton() {
            ConfirmButton.gameObject.SetActive(true);
            ConfirmButton.ClickEvent += OnConfirmButtonClick;
        }


        private void DeactivateConfirmButton() {
            ConfirmButton.gameObject.SetActive(false);
            ConfirmButton.ClickEvent += OnConfirmButtonClick;
        }


        private void DestroyActionButtons() {
            GameObject obj = new GameObject();
            foreach (var button in actionButtons)
                button.transform.SetParent(obj.transform);
            actionButtons.Clear();
            Destroy(obj);
        }


        private void CreateActionButton(Action action) {
            ActionButton button = Instantiate(Resources.Load<ActionButton>("Prefabs/UI/ActionButton"));
            actionButtons.Add(button);
            button.transform.SetParent(transform.FindChild("ActionButtons"));
            button.AssignedAction = action;
            button.transform.localScale = Vector3.one;
            button.ClickEvent += OnActionButtonClick;
        }

    }

}