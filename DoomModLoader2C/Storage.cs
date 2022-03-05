// Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
BSD 3-Clause License

Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
    public class Storage
    {
        private string filePath { get; set; }

        public Storage(string filePath)
        {
            this.filePath = filePath;
        }

        #region KEY-VALUE READ/WRITE
        public void SaveValue(string key, string value)
        {
            try
            {
                StringBuilder lineToSave = new StringBuilder();
                lineToSave.AppendFormat("{0}:{1}", key, value);
                lineToSave.AppendLine();
                File.AppendAllText(filePath, lineToSave.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveValues(Dictionary<string, string> values, bool overwrite = false)
        {
            try
            {
                StringBuilder lineToSave = new StringBuilder();
                foreach (var v in values)
                {
                    lineToSave.AppendFormat("{0}:{1}", v.Key, v.Value);
                    lineToSave.AppendLine();
                }

                if (overwrite)
                {
                    File.WriteAllText(filePath, lineToSave.ToString());
                }
                else
                {
                    File.AppendAllText(filePath, lineToSave.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteValue(string key)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values = ReadAllValues();
            values = values.Where(P => P.Key != key).ToDictionary(p => p.Key, p => p.Value);
            SaveValues(values, true);
        }
        public string ReadValue(string key)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string result = "";
            try
            {
                values = ReadAllValues();
                result = values.Where(p => p.Key == key).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public Dictionary<string, string> ReadAllValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {


                //Get all the rows from a text file
                string[] rows = File.ReadAllLines(filePath);

                //Discard empty lines
                rows = rows.Where(R => R != "").ToArray();
                values = rows.ToKeyValueDictionary();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return values;
        }


        #endregion

        #region UPDATE CONFIGURATION FILE
        public void UpdateConfig(string ItemPath, bool ignore_warning = false)
        {

            try
            {
                string s = File.ReadAllLines(filePath).Where(P => P == ItemPath).FirstOrDefault();
                if (s == null)
                {
                    File.AppendAllText(filePath, ItemPath + Environment.NewLine);
                }
                else if (!ignore_warning)
                {
                    MessageBox.Show("Cannot add the same file multiple time!" + Environment.NewLine +
                                    "The following path has already been added:" + Environment.NewLine +
                                    "\"" + ItemPath + "\"", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                UpdateRemoveConfigError(ex);
            }


        }

        public void RemoveConfig(string itemPath, bool show_message = true)
        {
            try
            {
                if (itemPath != null && itemPath != string.Empty)
                {
                    DialogResult ris = DialogResult.OK;
                    if (show_message)
                    {
                        ris = MessageBox.Show("Are you sure you want to remove \"" + itemPath + "\""
                                          , "REMOVE PATH", MessageBoxButtons.OKCancel);
                    }
                    if (ris == DialogResult.OK)
                    {
                        string[] s = File.ReadAllLines(filePath).Where(P => P != itemPath).ToArray();

                        File.WriteAllLines(filePath, s);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateRemoveConfigError(ex);
            }
        }

        private void UpdateRemoveConfigError(Exception ex)
        {
            StringBuilder errore = new StringBuilder();
            errore.AppendLine("Something went wrong while trying to update a configuration file...");
            errore.AppendLine("Please check if your account have the permission to write in:");
            errore.AppendLine(@"""" + filePath + @"""");
            errore.AppendLine();
            errore.AppendLine("Error Message:");
            errore.AppendLine(ex.Message);

            MessageBox.Show(errore.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        # endregion

    }

    #region text parser
    public static class TextParser
    {
        public static Dictionary<string, string> ToKeyValueDictionary(this string[] rows)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            foreach (string row in rows)
            {
                string key = "";
                string value = "";
                bool isReadingValue = false;
                foreach (char c in row)
                {
                    if (c.Equals(':') && !isReadingValue)
                    {
                        isReadingValue = true;
                        continue;
                    }

                    if (isReadingValue)
                    {
                        value += c;
                    }
                    else
                    {
                        key += c;
                    }
                }

                if (isReadingValue)
                    values.Add(key.Trim(), value);
            }

            return values;
        }
    }
    #endregion
}
