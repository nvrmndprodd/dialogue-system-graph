using DialogueSystem.Enumerations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.DialogueSystem.Elements
{
    public class DSMultipleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            DialogueType = DSDialogueType.MultipleChoice;
            
            Choices.Add("New Choice");
        }

        public override void Draw()
        {
            base.Draw();

            var addChoiceButton = new Button()
            {
                text = "Add Choice"
            };
            
            mainContainer.Insert(1, addChoiceButton);
            
            foreach (var choice in Choices)
            {
                var choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single,
                    typeof(bool));

                choicePort.portName = "";

                var deleteChoiceButton = new Button()
                {
                    text = "X"
                };

                var choiceTextField = new TextField()
                {
                    value = choice
                };
                
                choicePort.Add(choiceTextField);
                choicePort.Add(deleteChoiceButton);

                outputContainer.Add(choicePort);
            }
        }
    }
}