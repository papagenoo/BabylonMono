using System;

namespace Babylon.UI
{


	public abstract class State : PhrasesPresenterActions
	{
		#region PhrasesPresenterAtions implementation

		public void MoveNext ()
		{
			throw new NotImplementedException ();
		}

		public void MovePrevious ()
		{
			throw new NotImplementedException ();
		}

		public void PlaySound ()
		{
			throw new NotImplementedException ();
		}

		public void EnterAutoMode ()
		{
			throw new NotImplementedException ();
		}

		public void ExitAutoMode ()
		{
			throw new NotImplementedException ();
		}

		#endregion


	}

	//**************

	public abstract class ModeState : State
	{

	}

	public class ManualModeState : ModeState
	{

	}

	public class AutoModeState : ModeState
	{

	}

	//************

	public abstract class PlayingState
	{

	}

	public class PlayPlayingState : PlayingState
	{

	}

	public class IdlePlayingState : PlayingState
	{

	}

	public class AwaitingBeforeAutoMoveNextState : PlayingState
	{

	}


	public enum PhrasesPresenterEvent
	{
		MovePrevious,
		MoveNext,
		PlaySound,
		TimerTick,
		EnterAutoMode,
		ExitAutoMode
	}

	public enum PhrasesPresenterState
	{
		Idle,
		PlayingSound,
		AwaitingBeforeAutoMoveNext
	}

	public class PhrasesStateMachine
	{
		PhrasesPresenter presenter;
		PhrasesPresenterState state;

		public PhrasesStateMachine (PhrasesPresenter presenter)
		{
			this.presenter = presenter;
		}

		public void Handle (PhrasesPresenterEvent evt)
		{
			switch (state) {
			case PhrasesPresenterState.Idle:
				switch (evt) {
				case PhrasesPresenterEvent.MovePrevious:
					presenter.MovePrevious ();
					break;
				case PhrasesPresenterEvent.MoveNext:
					presenter.MoveNext ();
					break;
				case PhrasesPresenterEvent.PlaySound:
					state = PhrasesPresenterState.PlayingSound;
					presenter.PlaySound ();
					break;
				case PhrasesPresenterEvent.EnterAutoMode:
					//state = PhrasesPresenterState.
					break;
				case PhrasesPresenterEvent.ExitAutoMode:
					break;
				case PhrasesPresenterEvent.TimerTick:
					break;
				}
				break;
			case PhrasesPresenterState.PlayingSound:
				switch (evt) {
				case PhrasesPresenterEvent.MovePrevious:
					presenter.MovePrevious ();
					break;
				case PhrasesPresenterEvent.MoveNext:
					presenter.MoveNext ();
					break;
				case PhrasesPresenterEvent.PlaySound:
					state = PhrasesPresenterState.PlayingSound;
					presenter.PlaySound ();
					break;
				case PhrasesPresenterEvent.EnterAutoMode:
					//state = PhrasesPresenterState.
					break;
				case PhrasesPresenterEvent.ExitAutoMode:
					break;
				case PhrasesPresenterEvent.TimerTick:
					break;
				}
				break;
			case PhrasesPresenterState.AwaitingBeforeAutoMoveNext:
				break;
			}
		}
	}
}