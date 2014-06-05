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

		public override void HandlePreviousEvent (StateMachine context)
		{
			context.MovePrevious ();
			context.PlaySoundStart ();
		}

		public override void HandleNextEvent (StateMachine context)
		{
			context.MoveNext ();
			context.PlaySoundStart ();
		}

		public override void HandlePlaySoundStartEvent (StateMachine context)
		{
			context.PlaySoundStart ();
		}

		public override void HandlePlaySoundStopEvent (StateMachine context)
		{
			context.ChangeState (AwaitingInManualState.Instance);
		}

		public override void HandleEnterAutoModeEvent (StateMachine context)
		{
			context.EnterAutoMode ();
			context.ChangeState (PlayingInAutoState.Instance);
		}

		#endregion


	}
}