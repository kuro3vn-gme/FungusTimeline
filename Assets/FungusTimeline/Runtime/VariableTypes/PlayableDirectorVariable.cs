using UnityEngine;
using UnityEngine.Playables;
using Fungus;

namespace FungusExtensions.Playables
{
	[VariableInfo("Timeline", nameof(PlayableDirector))]
	[AddComponentMenu("")]
	[System.Serializable]
	public class PlayableDirectorVariable : VariableBase<PlayableDirector> { }

	[System.Serializable]
	public struct PlayableDirectorData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(PlayableDirectorVariable))]
		public PlayableDirectorVariable playableDirectorRef;

		[SerializeField]
		public PlayableDirector playableDirectorVal;

		public static implicit operator PlayableDirector(PlayableDirectorData playableDirectorData)
		{
			return playableDirectorData.Value;
		}

		public PlayableDirectorData(PlayableDirector v)
		{
			playableDirectorVal = v;
			playableDirectorRef = null;
		}

		public PlayableDirector Value
		{
			get { return (playableDirectorRef == null) ? playableDirectorVal : playableDirectorRef.Value; }
			set { if (playableDirectorRef == null) { playableDirectorVal = value; } else { playableDirectorRef.Value = value; } }
		}

		public string GetDescription()
		{
			if (playableDirectorRef == null)
			{
				return playableDirectorVal != null ? playableDirectorVal.ToString() : "Null";
			}
			else
			{
				return playableDirectorRef.Key;
			}
		}
	}
}