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

		public override void MovePrevious (StateMachine context)
		{
			context.PresenterMovePrevious ();
			context.PresenterPlaySoundStart ();
			context.ChangeState (PlayingInAutoState.Instance);
		}

		public override void MoveNext (StateMachine context)
		{
			context.PresenterMoveNext ();
			context.PresenterPlaySoundStart ();
			//context.ResetTimer ();
			context.ChangeState (PlayingInAutoState.Instance);
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.PresenterPlaySoundStart ();		
			context.ChangeState (PlayingInAutoState.Instance);
		}

		public override void PlaySoundStop (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void EnterAutoMode (StateMachine context)
		{

		}

		public override void EnterManualMode (StateMachine context)
		{
			context.PresenterEnterManualMode ();		
			context.ChangeState (AwaitingInManualState.Instance);
		}

		#endregion
		
	}
}