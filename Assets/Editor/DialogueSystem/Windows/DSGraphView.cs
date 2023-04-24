using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Editor.DialogueSystem.Windows
{
    using Utilities;
    
    public class DSGraphView : GraphView
    {
        
        public DSGraphView()
        {
            AddGridBackground();
            
            AddStyles();
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