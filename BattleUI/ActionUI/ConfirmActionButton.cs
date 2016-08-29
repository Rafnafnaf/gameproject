using UnityEngine;


namespace Assets.Scripts.BattleUI {

    public delegate void ConfirmActionButtonClickHandler();

    public class ConfirmActionButton : MonoBehaviour {

        public event ConfirmActionButtonClickHandler ClickEvent;  


        public void Click() {
            Debug.Log("Confirm action clicked");

            if (ClickEvent != null)
                ClickEvent();
        }

    }

}