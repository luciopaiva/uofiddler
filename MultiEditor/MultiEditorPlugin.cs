﻿/***************************************************************************
 *
 * $Author: MuadDib & Turley
 * 
 * "THE BEER-WARE LICENSE"
 * As long as you retain this notice you can do whatever you want with 
 * this stuff. If we meet some day, and you think this stuff is worth it,
 * you can buy me a beer in return.
 *
 ***************************************************************************/

using System.Windows.Forms;
using PluginInterface;

namespace FiddlerPlugin
{
    public class MultiEditorPlugin : IPlugin
    {
		#region Fields (5) 

        string myAuthor = "MuadDib & Turley";
        string myDescription = "blubb";
        IPluginHost myHost = null;
        string myName = "MultiEditorPlugin";
        string myVersion = "0.0.1";

		#endregion Fields 

		#region Constructors (1) 

        public MultiEditorPlugin()
        {
        }

		#endregion Constructors 

		#region Properties (5) 

        /// <summary>
        /// Author of the plugin
        /// </summary>
        public override string Author { get { return myAuthor; } }

        /// <summary>
        /// Description of the Plugin's purpose
        /// </summary>
        public override string Description { get { return myDescription; } }

        /// <summary>
        /// Host of the plugin.
        /// </summary>
        public override IPluginHost Host { get { return myHost; } set { myHost = value; } }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        public override string Name { get { return myName; } }

        /// <summary>
        /// Version of the plugin
        /// </summary>
        public override string Version { get { return myVersion; } }

		#endregion Properties 

		#region Methods (4) 

		// Public Methods (4) 

        public override void Dispose()
        {
            //fired in Fiddler OnClosing
        }

        public override void Initialize()
        {
            //fired on fiddler startup
        }

        public override void ModifyPluginToolStrip(ToolStripDropDownButton toolstrip)
        {
            //want an entry inside the plugin dropdown?
        }

        // the magic add a new tabpage at the end
        public override void ModifyTabPages(TabControl tabcontrol)
        {
            TabPage page = new TabPage();
            page.Tag = tabcontrol.TabCount + 1; // at end used for undock/dock feature to define the order
            page.Text = "Multi Editor";
            page.Controls.Add(new MultiEditor.MultiEditor() { Dock = DockStyle.Fill });
            tabcontrol.TabPages.Add(page);
        }

		#endregion Methods 
    }
}