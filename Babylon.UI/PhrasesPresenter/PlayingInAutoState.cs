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
			context.ChangeState (AwaitingInAutoState.Instance);
		}

		public override void EnterAutoMode (StateMachine context)
		{
		}

		public override void EnterManualMode (StateMachine context)
		{
			context.PresenterEnterManualMode ();
			context.ChangeState (PlayingInManualState.Instance);
		}

		#endregion


	}
}