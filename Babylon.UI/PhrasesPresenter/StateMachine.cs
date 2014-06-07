using System;

namespace Babylon.UI
{
	public class StateMachine
	{
		PhrasesPresenter presenter;

		public StateMachine (PhrasesPresenter presenter)
			: this (presenter, AwaitingInManualState.Instance)
		{
		}

		public StateMachine (PhrasesPresenter presenter, State initialState)
		{
			this.presenter = presenter;
			State = initialState;
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
			State.ExitState (this);
			State = state;
			State.EnterState (this);
		}

		#region Events

		public void RasePreviousEvent ()
		{
			State.HandlePreviousEvent (this);
		}

		public void RaseNextEvent ()
		{
			State.HandleNextEvent (this);
		}

		public void RasePlaySoundStartEvent ()
		{
			State.HandlePlaySoundStartEvent (this);
		}

		public void RasePlaySoundStopEvent ()
		{
			State.HandlePlaySoundStopEvent (this);
		}

		public void RaseEnterAutoModeEvent ()
		{
			State.HandleEnterAutoModeEvent (this);
		}

		public void RaseEnterManualModeEvent ()
		{
			State.HandleEnterManualModeEvent (this);
		}

		public void RaseTimeoutEvent ()
		{
			State.HandleTimeoutEvent (this);
		}

		#endregion


		#region Presenter methods

		public void MoveNext ()
		{
			presenter.MoveNext ();
		}

		public void MovePrevious ()
		{
			presenter.MovePrevious ();
		}

		public void PlaySoundStart ()
		{
			presenter.PlaySoundStart ();
		}

		public void EnterAutoMode ()
		{
			presenter.EnterAutoMode ();
		}

		public void EnterManualMode ()
		{
			presenter.EnterManualMode ();
		}

		#endregion
	}
}