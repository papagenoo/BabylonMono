using System;

namespace Babylon.UI
{
	public class PlayingInManualState : ManualState
	{
		public static PlayingInManualState Instance = new PlayingInManualState ();

		private PlayingInManualState () 
		{
			// Only one stateless instance
		}

		#region implemented abstract members of State

		public override void MovePrevious (StateMachine context)
		{
			context.PresenterMovePrevious ();
			context.PresenterPlaySoundStart ();
		}

		public override void MoveNext (StateMachine context)
		{
			context.PresenterMoveNext ();
			context.PresenterPlaySoundStart ();
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.PresenterPlaySoundStart ();
		}

		public override void PlaySoundStop (StateMachine context)
		{
			context.ChangeState (AwaitingInManualState.Instance);
		}

		public override void EnterAutoMode (StateMachine context)
		{
			context.PresenterEnterAutoMode ();
			context.ChangeState (PlayingInAutoState.Instance);
		}

		#endregion


	}
}