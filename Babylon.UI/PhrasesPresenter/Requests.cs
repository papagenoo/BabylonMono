using System;

namespace Babylon.UI
{
	public interface PhrasesPresenter_Requests
	{
		void MoveNextRequest ();
		void MovePreviousRequest ();
		void PlaySoundRequest ();
		void EnterAutoModeRequest ();
		void ExitAutoModeRequest ();
	}
}