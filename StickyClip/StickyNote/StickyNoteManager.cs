using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.Libraries.SharpClipboardNS;

using StickyClip.StickyNote;
using System.Windows.Forms;

namespace StickyClip
{
    public class StickyNoteManager : IDisposable
    {
        HashSet<StickyNoteForm> stickyNoteForms;
        SharpClipboard clipBoard;

        string previousText;
        object addNoteLock = new object();

        public StickyNoteManager(string filePath) : this()
        {
            Load(filePath);
        }

        public StickyNoteManager()
        {
            clipBoard = new SharpClipboard();

            clipBoard.ClipboardChanged += ClipBoard_ClipboardChanged;
            previousText = clipBoard.ClipboardText;
        }

        private void ClipBoard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
            {
                if (!clipBoard.ClipboardText.Equals(previousText) &&
                    clipBoard.ClipboardText.StartsWith(Settings.Default.CommandInitiatorToken))
                {
                    lock (addNoteLock)
                    {
                        AddNote();
                    }
                }
            }
        }

        private void AddNote()
        {
            previousText = clipBoard.ClipboardText;

            StickyNoteForm stickyNoteForm = new StickyNoteForm(previousText.Substring(Settings.Default.CommandInitiatorToken.Length));
            stickyNoteForms.Add(stickyNoteForm);

            Application.Run(stickyNoteForm);
        }

        private void Load(string filePath)
        {
            throw new NotImplementedException();
        }

        private void Save(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            foreach (StickyNoteForm stickyNoteForm in stickyNoteForms)
            {
                stickyNoteForm.Close();
            }
        }
    }
}
