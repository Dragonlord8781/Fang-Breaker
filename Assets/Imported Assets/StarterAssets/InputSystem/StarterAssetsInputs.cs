using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool reload;
		public bool shoot;
		public bool pause;
		public bool swap;
        public bool click;
        public Vector2 moveClicker;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public GameManager manager;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (manager.gameIsPaused == false)
				MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook && manager.gameIsPaused == false)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
            if (manager.gameIsPaused == false)
                JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
            if (manager.gameIsPaused == false)
                SprintInput(value.isPressed);
		}

        public void OnShoot(InputValue value)
        {
            if (manager.gameIsPaused == false)
                ShootInput(value.isPressed);
        }

        public void OnReload(InputValue value)
        {
            if (manager.gameIsPaused == false)
                ReloadInput(value.isPressed);
        }

        public void OnSwapWeapon(InputValue value)
        {
            if (manager.gameIsPaused == false)
                SwapInput(value.isPressed);
        }

        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }

        public void OnClick(InputValue value)
        {
            if (manager.gameIsPaused == true)
                ClickInput(value.isPressed);
        }

        public void OnMoveClicker(InputValue value)
        {
            if (manager.gameIsPaused == true)
                MoveClickerInput(value.Get<Vector2>());
        }

#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
            if (manager.gameIsPaused == false)
                move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
            if (manager.gameIsPaused == false)
            {
#if (UNITY_IOS || UNITY_ANDROID)
                look = newLookDirection * 50;
#else
                look = newLookDirection;
#endif
            }
                
		}

		public void JumpInput(bool newJumpState)
		{
            if (manager.gameIsPaused == false)
                jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
            if (manager.gameIsPaused == false)
                sprint = newSprintState;
		}

        public void ShootInput(bool newShootState)
        {
            if (manager.gameIsPaused == false)
                shoot = newShootState;
        }

        public void ReloadInput(bool newReloadState)
        {
            if (manager.gameIsPaused == false)
                reload = newReloadState;
        }

        public void SwapInput(bool newSwapState)
        {
            if (manager.gameIsPaused == false)
                swap = newSwapState;
        }

        public void PauseInput(bool newPauseState)
        {
                pause = !pause;
            if (pause)
            {
                SetCursorState(false);
                manager.Pause();
                look = Vector2.zero;
            }
            else
            {
                SetCursorState(true);
                manager.Resume();
            }

        }

        public void ClickInput(bool newClickState)
        {
            if (manager.gameIsPaused == true)
                click = newClickState;
        }

        public void MoveClickerInput(Vector2 newClickerDirection)
        {
            if (manager.gameIsPaused == true)
                moveClicker = newClickerDirection;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
                SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
                Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}