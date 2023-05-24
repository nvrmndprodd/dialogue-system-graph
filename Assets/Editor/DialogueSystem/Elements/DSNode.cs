using System.Collections.Generic;
using DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;

namespace Editor.DialogueSystem.Elements
{
    public class DSNode : Node
    {
        public string DialogueName;
        public List<string> Choices;
        public string Text;
        public DSDialogueType DialogueType;

        public void Initialize()
        {
            DialogueName = "DialogueName";
            Choices = new List<string>();
            Text = "Dialogue text.";
            
        }
    }
}