using UnityEngine;
using UnityEngine.Playables;
using Fungus;

namespace FungusExtensions.Playables
{
	[CommandInfo("Timeline",
				 "Pause Timeline",
				 "Pause timeline.")]
	[AddComponentMenu("")]
	public class PauseTimeline : Command
	{
		[Tooltip("Playable Director")]
		[SerializeField] protected PlayableDirectorData playableDirector = new PlayableDirectorData();

		#region Public members

		public override void OnEnter()
		{
			if (playableDirector.Value == null)
			{
				Continue();
				return;
			}

			if (playableDirector.Value.state == PlayState.Playing)
			{
				playableDirector.Value.Pause();
			}
			Continue();
		}

		public override string GetSummary()
		{
			if (playableDirector.Value == null)
			{
				return "Error: No PlayableDirector selected";
			}
			return playableDirector.Value.name;
		}

		public override Color GetButtonColor()
		{
			return new Color32(235, 191, 217, 255);
		}

		public override bool HasReference(Variable variable)
		{
			return base.HasReference(variable) ||
				(playableDirector.playableDirectorRef == variable);
		}

		#endregion
	}
}