using DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Editor.DialogueSystem.Elements
{
    public class DSSingleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            DialogueType = DSDialogueType.SingleChoice;
            
            Choices.Add("Next Dialogue");
        }

        public override void Draw()
        {
            base.Draw();

            DrawOutputContainer();
            
            RefreshExpandedState();
        }

        private void DrawOutputContainer()
        {
            foreach (var choice in Choices)
            {
                var choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single,
                    typeof(bool));

                choicePort.portName = choice;

                outputContainer.Add(choicePort);
            }
        }
    }
}