using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BIAB
{
    public static class ConsoleHandler
    {
        public static List<string> Lines;

        #region Overloads
        public static void LogError(string condition, string stackTrace, LogType type)
        {
            LogError(condition + "\n" + stackTrace + "\n" + type.ToString());
        }
        public static void LogError(System.Exception e)
        {
            LogError(e.Message);
        }
        public static void Log(string msg)
        {
            Log(msg, false);
        }
        public static void LogError(string msg)
        {
            Log(msg, true);
        }

        public static ProgressBar CreateProgressBar(int Progress, string Text, int Min = 0, int Max = 100, string Additional = "")
        {
            int index = StartLivingLine();
            return new ProgressBar(index, Progress, Text, Min, Max, Additional);
        }
        #endregion
        #region Base
        public static void Log(string msg, bool isError)
        {
            AddLine(msg);
            //if(isError) Debug.LogError(msg);
            //else Debug.Log(msg);
        }

        private static int AddLine(string Line)
        {
            if (Lines == null)
                Lines = new List<string>();
            Lines.Add(Line);
            return Lines.Count - 1;
        }

        public static int StartLivingLine()
        {
            return AddLine("Living Line Start");
        }
        public static void EndLivingLine(int i, bool isError = false)
        {
            Log(Lines[i], isError);
        }


        #endregion
    }

    public class ProgressBar
    {
        public int index;
        public int Progress;
        public int Min;
        public int Max;
        public string Text;
        public string Additional;

        public ProgressBar(int index, int Progress, string Text, int Min = 0, int Max = 100, string Additional = "")
        {
            this.index = index;
            this.Progress = Progress;
            this.Text = Text;
            this.Min = Min;
            this.Max = Max;
            this.Additional = Additional;
        }
        public void UpdateProgress(int progress)
        {
            this.Progress = progress;
            Draw();
        }
        public void UpdateText(string Text, string Additional)
        {
            this.Text = Text;
            this.Additional = Additional;
            Draw();
        }

        private void Draw()
        {
            ConsoleHandler.Lines[index] = this.ToString();
        }

        public new string ToString()
        {
            string val = Text;
            val += " [";
            int a = Mathf.RoundToInt((((Progress - Min) * 1f) / (Max - Min)) * 10f);
            for (int x = 0; x < 10; x++)
            {
                if (x <= a) val += "X";
                else val += " ";
            }
            val += "] " + Additional;
            return val;
        }
    }
}