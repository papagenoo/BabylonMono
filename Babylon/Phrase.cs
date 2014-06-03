using System;

namespace Babylon
{
	public class Phrase
	{
		public Phrase(string text, string translation, string audioFileName)
		{
			Text = text;
			Translation = translation;
			AudioFileName = audioFileName;
		}

		public string Text { get; private set; }
		public string Translation { get; private set; }
		public string AudioFileName { get; private set; }

		public override bool Equals(System.Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			Phrase p = obj as Phrase;
			if ((System.Object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (Text == p.Text) && 
				   (Translation == p.Translation) && 
				   (AudioFileName == p.AudioFileName);
		}

		public bool Equals(Phrase p)
		{
			// If parameter is null return false:
			if ((object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (Text == p.Text) &&
				   (Translation == p.Translation) &&
				   (AudioFileName == p.AudioFileName);
		}

		public override int GetHashCode()
		{
			return Text.GetHashCode() ^ Translation.GetHashCode() ^ AudioFileName.GetHashCode();
		}
	}
}