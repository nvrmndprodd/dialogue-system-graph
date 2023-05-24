using Editor.DialogueSystem.Elements;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.DialogueSystem.Windows
{
    using Utilities;

    public class DSGraphView : GraphView
    {
        public DSGraphView()
        {
            AddManipulators();
            AddGridBackground();

            AddStyles();
        }

        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(CreateNodeContextualMenu());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new ContentDragger());
        }

        private IManipulator CreateNodeContextualMenu()
        {
            var contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction("Add Node",
                    actionEvent => AddElement(CreateNode(actionEvent.eventInfo.localMousePosition))));

            return contextualMenuManipulator;
        }

        private DSNode CreateNode(Vector2 position)
        {
            var node = new DSNode();

            node.Initialize(position);
            node.Draw();

            return node;
        }

        private void AddGridBackground()
        {
            var gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }

        private void AddStyles()
        {
            this.AddStyleSheets(
                "DialogueSystem/DSGraphViewStyles.uss"
            );
        }
    }
}