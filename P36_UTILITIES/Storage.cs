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

        public string ReadValue(string key)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {

                values = ReadAllValues();
                
            }
            catch (Exception ex)
            {
                
            }

            return values.Where(p=> p.Key == key).FirstOrDefault().Value;
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
                    if (c.Equals(':')) { 
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
                if(isReadingValue)
                values.Add(key, value);
            }

            return values;
        }
    }
    #endregion
}
