using System;

namespace Babylon.UI
{
	public class StateMachine
	{
		PhrasesPresenter presenter;

		public StateMachine (PhrasesPresenter presenter)
		{
			this.presenter = presenter;
			State = AwaitingInManualState.Instance;
		}

		/// <summary>
		/// Gets or sets the state.
		/// Sets state without proceeding 
		/// </summary>
		/// <value>The state.</value>
		public State State { get; set; }

		/// <summary>
		/// Sets state and proceed ExitState and EnterState actions
		/// </summary>
		/// <param name="state">State.</param>
		public void ChangeState (State state)
		{
			State.ExitState ();
			State = state;
			State.EnterState ();
		}

		#region Events

		public void MovePrevious ()
		{
			State.MovePrevious (this);
		}

		public void MoveNext ()
		{
			State.MoveNext (this);
		}

		public void PlaySoundStart ()
		{
			State.PlaySoundStart (this);
		}

		public void PlaySoundStop ()
		{
			State.PlaySoundStop (this);
		}

		public void EnterAutoMode ()
		{
			State.EnterAutoMode (this);
		}

		public void EnterManualMode ()
		{
			State.EnterManualMode (this);
		}

		#endregion


		#region Presenter methods

		public void PresenterMoveNext ()
		{
			presenter.MoveNext ();
		}

		public void PresenterMovePrevious ()
		{
			presenter.MovePrevious ();
		}

		public void PresenterPlaySoundStart ()
		{
			presenter.PlaySoundStart ();
		}

		public void PresenterEnterAutoMode ()
		{
			presenter.EnterAutoMode ();
		}


		public void PresenterEnterManualMode ()
		{
			presenter.EnterManualMode ();
		}
		#endregion
	}
}