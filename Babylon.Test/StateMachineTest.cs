using System;
using NUnit.Framework;
using Babylon.UI;
using System.Threading;

namespace Babylon.Test
{
	public class StateMachine_AwaitingInManual_Test
	{
		class PhrasesPresenterMock : PhrasesPresenter
		{

			public int MoveNextCounter = 0;
			public int MovePreviousCounter = 0;
			public int PlaySoundCounter = 0;
			public int EnterAutoModeCounter = 0;
			public int ExitAutoModeCounter = 0;

			public void MoveNext ()
			{
				MoveNextCounter++;
			}

			public void MovePrevious ()
			{
				MovePreviousCounter++;
			}

			public void PlaySoundStart ()
			{
				PlaySoundCounter++;
			}

			public void EnterAutoMode ()
			{
				EnterAutoModeCounter++;
			}

			public void ExitAutoMode ()
			{
				ExitAutoModeCounter++;
			}



		}

		PhrasesPresenterMock presenter;
		StateMachine stateMachine;

		[TestFixtureSetUp ()]
		public void SetUpOnce ()
		{
			Logger.Instance = new LoggerIml ();
		}

		[SetUp ()]
		public void SetUpEach ()
		{
			presenter = new PhrasesPresenterMock ();
			stateMachine = new StateMachine (presenter);
		}

		//***********************************

		[Test ()]
		public void InitialStateTest()
		{
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsTrue(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		//***********************************

		[Test ()]
		public void SetAwaitingInAutoStateTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			Assert.IsTrue(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void SetPlayingInAutoStateTest()
		{
			stateMachine.SetPlayingInAutoState ();
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsTrue(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void SetPlayingInManualStateTest()
		{
			stateMachine.SetPlayingInManualState ();
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		//***********************************

		[Test ()]
		public void MoveNext_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MoveNext ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void MovePrevious_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MovePrevious ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStart_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.PlaySoundStart ();
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void PlaySoundStop_In_AwaitingInManualTest()
		{
			stateMachine.PlaySoundStop ();
		}

		[Test ()]
		public void EnterAutoMode_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.EnterAutoModeCounter);
			stateMachine.EnterAutoMode ();
			Assert.AreEqual (1, presenter.EnterAutoModeCounter);
			Assert.IsTrue(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void ExitAutoMode_In_AwaitingInManualTest()
		{
			stateMachine.ExitAutoMode ();
		}

		//***********************************


		[Test ()]
		public void MoveNext_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MoveNext ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void MovePrevious_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MovePrevious ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStart_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.PlaySoundStart ();
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsTrue(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStop_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			stateMachine.PlaySoundStop ();
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsTrue(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void EnterAutoMode_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			Assert.AreEqual (0, presenter.EnterAutoModeCounter);
			stateMachine.EnterAutoMode ();
			Assert.AreEqual (1, presenter.EnterAutoModeCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsTrue(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void ExitAutoMode_In_PlayingInManualTest()
		{
			stateMachine.SetPlayingInManualState ();
			stateMachine.ExitAutoMode ();
		}

		//************************


		[Test ()]
		public void MoveNext_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MoveNext ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsTrue(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void MovePrevious_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.MovePrevious ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsTrue(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStart_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			Assert.AreEqual (0, presenter.PlaySoundCounter);
			stateMachine.PlaySoundStart ();
			Assert.AreEqual (1, presenter.PlaySoundCounter);
			Assert.IsFalse(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsTrue(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void PlaySoundStop_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			stateMachine.PlaySoundStop ();
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void EnterAutoMode_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			stateMachine.EnterAutoMode ();
		}

		[Test ()]
		public void ExitAutoMode_In_AwaitingInAutoTest()
		{
			stateMachine.SetAwaitingInAutoState ();
			Assert.AreEqual (0, presenter.ExitAutoModeCounter);
			stateMachine.ExitAutoMode ();
			Assert.AreEqual (0, presenter.ExitAutoModeCounter);
			Assert.IsTrue(stateMachine.IsAwaitingInAutoState ());
			Assert.IsFalse(stateMachine.IsAwaitingInManualState ());
			Assert.IsFalse(stateMachine.IsPlayingInAutoState ());
			Assert.IsFalse(stateMachine.IsPlayingInManualState ());
		}


	}
}

