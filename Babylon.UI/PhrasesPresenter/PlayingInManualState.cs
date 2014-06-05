using System;

namespace Babylon.UI
{
	public class PlayingInManualState : ManualState
	{
		#region implemented abstract members of State

		public override void MovePrevious (StateMachine context)
		{
			context.DoMovePrevious ();
			context.DoPlaySoundStart ();
		}

		public override void MoveNext (StateMachine context)
		{
			context.DoMoveNext ();
			context.DoPlaySoundStart ();
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.DoPlaySoundStart ();
		}

		public override void PlaySoundStop (StateMachine context)
		{
			context.SetAwaitingInManualState ();
		}

		public override void EnterAutoMode (StateMachine context)
		{
			context.SetPlayingInAutoState ();
			context.DoEnterAutoMode ();
		}

		public override void ExitAutoMode (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		#endregion


	}
}