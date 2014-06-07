using System;

namespace Babylon.UI
{
	public class AwaitingInAutoState : AutoState
	{
		public static AwaitingInAutoState Instance = new AwaitingInAutoState ();
		
		private AwaitingInAutoState () 
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
			//context.ResetTimer ();
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void HandlePlaySoundStartEvent (StateMachine context)
		{
			context.PlaySoundStart ();		
			context.ChangeState (PlayingInAutoState.Instance);
		}

		public override void HandlePlaySoundStopEvent (StateMachine context)
		{
			//throw new InvalidStateTransitionException ();
		}

		public override void HandleEnterManualModeEvent (StateMachine context)
		{
			context.ChangeState (AwaitingInManualState.Instance);
		}

		public override void HandleTimeoutEvent (StateMachine context)
		{
			context.MoveNext ();
			context.PlaySoundStart ();
		}

		#endregion
		
	}
}