// Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
    BSD 4-Clause License
    
    Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
    All rights reserved.
    
    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:
    
    1. Redistributions of source code must retain the above copyright notice, this
       list of conditions and the following disclaimer.
    
    2. Redistributions in binary form must reproduce the above copyright notice,
       this list of conditions and the following disclaimer in the documentation
       and/or other materials provided with the distribution.
    
    3. All advertising materials mentioning features or use of this software must
       display the following acknowledgement:
         This product includes software developed by P36 Software.
    
    4. Neither the name of the copyright holder nor the names of its
       contributors may be used to endorse or promote products derived from
       this software without specific prior written permission.
    
    THIS SOFTWARE IS PROVIDED BY COPYRIGHT HOLDER "AS IS" AND ANY EXPRESS OR
    IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
    EVENT SHALL COPYRIGHT HOLDER BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
    SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
    OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
    WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
    OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
    ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Windows.Forms;

namespace DoomModLoader2
{
    /// <summary>
    /// Form used to change user's preferences, mostly for DML 2.X messages.
    /// (The options to disable the check for updated DML 2.X version at startup is in VersionForm.cs)
    /// </summary>
    public partial class Options : Form
    {
        private string cfgPath;
        /// <summary>
        /// Initialize the options menu ("preferences...").
        /// </summary>
        /// <param name="cfgPath"></param>
        public Options(string cfgPath)
        {
            InitializeComponent();
            chk_SHOW_END_MESSAGE.Checked = SharedVar.SHOW_END_MESSAGE;
            chk_SHOW_OVERWRITE_MESSAGE.Checked = SharedVar.SHOW_OVERWRITE_MESSAGE;
            chk_SHOW_SUCCESS_MESSAGE.Checked = SharedVar.SHOW_SUCCESS_MESSAGE;
            chk_SHOW_DELETE_MESSAGE.Checked = SharedVar.SHOW_DELETE_MESSAGE;
            chk_USE_ADVANCED_SELECTION_MODE.Checked = SharedVar.USE_ADVANCED_SELECTION_MODE;

            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            this.cfgPath = cfgPath;
        }

        /// <summary>
        /// Save the options and close the dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveOptions_Click(object sender, EventArgs e)
        {
            SharedVar.SHOW_END_MESSAGE = chk_SHOW_END_MESSAGE.Checked;
            SharedVar.SHOW_OVERWRITE_MESSAGE = chk_SHOW_OVERWRITE_MESSAGE.Checked;
            SharedVar.SHOW_SUCCESS_MESSAGE = chk_SHOW_SUCCESS_MESSAGE.Checked;
            SharedVar.SHOW_DELETE_MESSAGE = chk_SHOW_DELETE_MESSAGE.Checked;
            SharedVar.USE_ADVANCED_SELECTION_MODE = chk_USE_ADVANCED_SELECTION_MODE.Checked;

            Storage storage = new Storage(cfgPath);

            storage.DeleteValue("SHOW_END_MESSAGE");
            storage.SaveValue("SHOW_END_MESSAGE", SharedVar.SHOW_END_MESSAGE.ToString());

            storage.DeleteValue("SHOW_OVERWRITE_MESSAGE");
            storage.SaveValue("SHOW_OVERWRITE_MESSAGE", SharedVar.SHOW_OVERWRITE_MESSAGE.ToString());

            storage.DeleteValue("SHOW_SUCCESS_MESSAGE");
            storage.SaveValue("SHOW_SUCCESS_MESSAGE", SharedVar.SHOW_SUCCESS_MESSAGE.ToString());

            storage.DeleteValue("SHOW_DELETE_MESSAGE");
            storage.SaveValue("SHOW_DELETE_MESSAGE", SharedVar.SHOW_DELETE_MESSAGE.ToString());
            this.Close();
        }

        /// <summary>
        /// Close the option dialog without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuitOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
