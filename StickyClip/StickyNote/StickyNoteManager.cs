using System;
using System.Collections.Generic;
using System.Linq;
using WK.Libraries.SharpClipboardNS;
using StickyClip.StickyNote;
using Newtonsoft.Json;
using System.IO;

namespace StickyClip
{
    public class StickyNoteManager : IDisposable
    {
        List<StickyNoteForm> stickyNoteForms;
        SharpClipboard clipBoard;

        string previousText;
        object addNoteLock = new object();

        public StickyNoteManager()
        {
            stickyNoteForms = new List<StickyNoteForm>();
            LoadStickies();

            clipBoard = new SharpClipboard { ObserveLastEntry = false };

            clipBoard.ClipboardChanged += ClipBoard_ClipboardChanged;
            previousText = TextFilter(clipBoard.ClipboardText);
        }

        private void ClipBoard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
            {
                string cleanText = TextFilter(clipBoard.ClipboardText);

                if (!cleanText.Equals(previousText) &&
                    cleanText.StartsWith(Settings.Default.CommandInitiatorToken))
                {
                    lock (addNoteLock)
                    {
                        previousText = cleanText;
                        AddNote(cleanText.Substring(Settings.Default.CommandInitiatorToken.Length));
                    }
                }
            }
        }

        private string TextFilter(string s)
        {
            return s != null ? s.Trim().Replace("\\n", "\n") : null;
        }

        private void AddNote(string markdown)
        {
            StickyNoteForm stickyNoteForm =
                new StickyNoteForm(markdown);

            stickyNoteForm.FormClosed += StickyNoteForm_FormClosed;
            stickyNoteForms.Add(stickyNoteForm);
            stickyNoteForm.Show();
        }

        private void StickyNoteForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (e.CloseReason != System.Windows.Forms.CloseReason.ApplicationExitCall)
            {
                stickyNoteForms.Remove((StickyNoteForm)sender);
            }
        }

        private void LoadStickies()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Settings.Default.SaveFile))
                {
                    string json = reader.ReadToEnd();
                    string[] stickies = JsonConvert.DeserializeObject<string[]>(json);

                    if (stickies != null)
                    {
                        foreach (string markdown in stickies)
                        {
                            AddNote(markdown);
                        }
                    }
                }
            }
            catch
            { }
        }

        private void SaveStickies()
        {
            using (StreamWriter writer = new StreamWriter(Settings.Default.SaveFile))
            {
                string[] stickies = stickyNoteForms.Select(e => e.MarkdownString).ToArray();
                string json = JsonConvert.SerializeObject(stickies);
                writer.WriteLine(json);
            }
        }

        public void Dispose()
        {
            SaveStickies();
        }
    }
}
