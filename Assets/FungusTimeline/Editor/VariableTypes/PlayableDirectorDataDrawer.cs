using UnityEditor;
using Fungus.EditorUtils;
using FungusExtensions.Playables;

namespace FungusExtensions.EditorUtils.Playables
{
	[CustomPropertyDrawer(typeof(PlayableDirectorData))]
	public class PlayableDirectorDataDrawer : VariableDataDrawer<PlayableDirectorVariable> { }
}