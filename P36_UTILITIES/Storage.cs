using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P36_UTILITIES
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

            }

            return result;
        }


        public Dictionary<string, string> ReadAllValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {


                //Ottengo tutte le righe dal file
                string[] rows = File.ReadAllLines(filePath);

                //Scarto le eventuali righe vuote
                rows = rows.Where(R => R != "").ToArray();
                values = rows.ToKeyValueDictionary();
            }
            catch (Exception ex)
            {

            }
            return values;
        }

       
        #endregion

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

                //Controllo se è entrato in fase di lettura del valore, in caso contrario vuol dire che mancavano i ":" e quindi scarto la riga.
                if (isReadingValue)
                    values.Add(key.Trim(), value.Trim());
            }

            return values;
        }
    }
    #endregion
}
