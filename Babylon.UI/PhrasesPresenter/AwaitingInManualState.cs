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

		public override void MovePrevious (StateMachine context)
		{
			context.PresenterMovePrevious ();
			context.PresenterPlaySoundStart ();
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void MoveNext (StateMachine context)
		{
			context.PresenterMoveNext ();
			context.PresenterPlaySoundStart ();
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.PresenterPlaySoundStart ();
			context.ChangeState (PlayingInManualState.Instance);
		}

		public override void PlaySoundStop (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void EnterAutoMode (StateMachine context)
		{
			context.PresenterEnterAutoMode ();
			context.ChangeState(AwaitingInAutoState.Instance);
		}

		#endregion		
	}
}