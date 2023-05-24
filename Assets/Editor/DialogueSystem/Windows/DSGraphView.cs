using Editor.DialogueSystem.Elements;
using UnityEditor.Experimental.GraphView;
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

            CreateNode();
            
            AddStyles();
        }

        private void CreateNode()
        {
            var node = new DSNode();
            
            node.Initialize();
            node.Draw();

            AddElement(node);
        }

        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
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