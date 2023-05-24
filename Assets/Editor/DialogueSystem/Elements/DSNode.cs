using System.Collections.Generic;
using DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.DialogueSystem.Elements
{
    public class DSNode : Node
    {
        public string DialogueName;
        public List<string> Choices;
        public string Text;
        public DSDialogueType DialogueType;

        public void Initialize(Vector2 position)
        {
            DialogueName = "DialogueName";
            Choices = new List<string>();
            Text = "Dialogue text.";
            
            SetPosition(new Rect(position, Vector2.zero));
        }

        public void Draw()
        {
            DrawTitleContainer();
            DrawInputContainer();
            DrawExtensionContainer();
            
            RefreshExpandedState();
        }

        private void DrawTitleContainer()
        {
            var dialogueNameTextField = new TextField()
            {
                value = DialogueName
            };

            titleContainer.Insert(0, dialogueNameTextField);
        }

        private void DrawInputContainer()
        {
            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            inputPort.portName = "Dialogue Connection";

            inputContainer.Add(inputPort);
        }

        private void DrawExtensionContainer()
        {
            var customDataContainer = new VisualElement();

            var textFoldout = new Foldout()
            {
                text = "Dialogue Text"
            };

            var textTextField = new TextField()
            {
                value = Text
            };

            textFoldout.Add(textTextField);

            customDataContainer.Add(textFoldout);
            extensionContainer.Add(customDataContainer);
        }
    }
}