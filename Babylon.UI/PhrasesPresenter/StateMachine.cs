using System;

namespace Babylon.UI
{
	public class StateMachine
	{
		internal static AwaitingInAutoState awaitingInAutoState =
			new AwaitingInAutoState ();

		internal static AwaitingInManualState awaitingInManualState =
			new AwaitingInManualState ();

		internal static PlayingInAutoState playingInAutoState =
			new PlayingInAutoState ();

		internal static PlayingInManualState playingInManualState =
			new PlayingInManualState ();
			
		PhrasesPresenter presenter;
		internal State state = awaitingInManualState;

		public StateMachine (PhrasesPresenter presenter)
		{
			this.presenter = presenter;
		}

		public void SetAwaitingInAutoState ()
		{
			state = awaitingInAutoState;
		}

		public bool IsAwaitingInAutoState ()
		{
			return state == awaitingInAutoState;
		}

		public void SetAwaitingInManualState ()
		{
			state = awaitingInManualState;
		}

		public bool IsAwaitingInManualState ()
		{
			return state == awaitingInManualState;
		}



		public void SetPlayingInAutoState ()
		{
			state = playingInAutoState;
		}

		public bool IsPlayingInAutoState ()
		{
			return state == playingInAutoState;
		}

		public void SetPlayingInManualState ()
		{
			state = playingInManualState;
		}

		public bool IsPlayingInManualState ()
		{
			return state == playingInManualState;
		}


		#region Events implementation

		public void MovePrevious ()
		{
			state.MovePrevious (this);
		}

		public void MoveNext ()
		{
			state.MoveNext (this);
		}

		public void PlaySoundStart ()
		{
			state.PlaySoundStart (this);
		}

		public void PlaySoundStop ()
		{
			state.PlaySoundStop (this);
		}

		public void EnterAutoMode ()
		{
			state.EnterAutoMode (this);
		}

		public void ExitAutoMode ()
		{
			state.ExitAutoMode (this);
		}

		#endregion

		public void DoMoveNext () 
		{
			presenter.MoveNext ();
		}

		public void DoMovePrevious () 
		{
			presenter.MovePrevious ();
		}

		public void DoPlaySoundStart () 
		{
			presenter.PlaySoundStart ();
		}

		public void DoEnterAutoMode () 
		{
			presenter.EnterAutoMode ();
		}
	}
}