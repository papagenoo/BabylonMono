using System;

namespace Babylon.UI
{
	public class PlayingInAutoState : AutoState
	{
		#region implemented abstract members of State

		public override void MovePrevious (StateMachine context)
		{
			throw new NotImplementedException ();
		}

		public override void MoveNext (StateMachine context)
		{
			context.DoMoveNext ();
			context.DoPlaySoundStart ();		}

		public override void PlaySoundStart (StateMachine context)
		{
			throw new NotImplementedException ();
		}

		public override void PlaySoundStop (StateMachine context)
		{
			throw new NotImplementedException ();
		}

		public override void EnterAutoMode (StateMachine context)
		{
			throw new NotImplementedException ();
		}

		public override void ExitAutoMode (StateMachine context)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}