using System;

namespace Babylon.UI
{
	public interface PhrasesPresenter : PhrasesPresenterActions
	{
		void NextChosen ();
		void PreviousChosen ();
		void PlaySoundChosen ();
		void EnterAutoModeChosen ();
		void ExitAutoModeChosen ();



	}
}