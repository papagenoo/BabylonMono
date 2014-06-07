using System;

namespace Babylon.UI
{
	public class PlayingInAutoState : AutoState
	{
		public static PlayingInAutoState Instance = new PlayingInAutoState ();
		
		private PlayingInAutoState () 
		{
			// Only one stateless instance
		}

		#region implemented abstract members of State

		public override void HandlePreviousEvent (StateMachine context)
		{
			context.MovePrevious ();
			context.PlaySoundStart ();		
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void HandleNextEvent (StateMachine context)
		{
			context.MoveNext ();
			context.PlaySoundStart ();	
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void HandlePlaySoundStartEvent (StateMachine context)
		{
			context.PlaySoundStart ();		
		}

		public override void HandlePlaySoundStopEvent (StateMachine context)
		{
			context.ChangeState (AwaitingInAutoState.Instance);
		}

		public override void HandleEnterAutoModeEvent (StateMachine context)
		{
		}

		public override void HandleEnterManualModeEvent (StateMachine context)
		{
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void HandleTimeoutEvent (StateMachine stateMachine)
		{
		}

		#endregion


	}
}