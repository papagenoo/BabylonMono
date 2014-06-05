using System;

namespace Babylon.UI
{
	public class AwaitingInManualState : ManualState
	{
		public static AwaitingInManualState Instance = new AwaitingInManualState ();

		private AwaitingInManualState () 
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
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void HandlePlaySoundStopEvent (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void HandleEnterAutoModeEvent (StateMachine context)
		{
			context.EnterAutoMode ();
			context.ChangeState(AwaitingInAutoState.Instance);
		}

		#endregion		
	}
}