using System;

namespace Babylon.UI
{
	public class PhrasesStateMachine
	{
		PhrasesPresenter presenter;
		PhrasesPresenter_State state;

		public PhrasesStateMachine (PhrasesPresenter presenter)
		{
			this.presenter = presenter;
		}

		public void Handle (PhrasesPresenter_Event evt)
		{
			switch (state) {
			case PhrasesPresenter_State.Idle:
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
			case PhrasesPresenter_State.PlayingSound:
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