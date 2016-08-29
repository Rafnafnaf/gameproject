using Assets.Scripts.GameLogic.ActionLogic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.BattleUI.ActionSelectUI {

    public delegate void ActionButtonClickHandler(ActionButton button);


    public class ActionButton : MonoBehaviour {

        public event ActionButtonClickHandler ClickEvent;

        private Action assignedAction;


        public Action AssignedAction {
            get { return assignedAction; }
            set {
                assignedAction = value;
                SetIcon(value.Icon);
            }
        }


        public void Click() {
            Debug.Log("Action button clicked: " + assignedAction.name);

            if (ClickEvent != null)
                ClickEvent(this);
        }


        private void SetIcon(Sprite icon) {
            transform.FindChild("Icon").GetComponent<Image>().sprite = icon;
        }

    }

}