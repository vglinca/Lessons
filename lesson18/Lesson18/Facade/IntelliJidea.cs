using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class IntelliJIdea
    {
        TextEditor _textEditor;
        Maven _maven;

        public IntelliJIdea(TextEditor editor, Maven maven)
        {
            _textEditor = editor;
            _maven = maven;
        }

        public void HandleCodeWriting()
        {
            _textEditor.WriteCode();
        }

        public void BuildProject()
        {
            _textEditor.SaveFile();
            _maven.Build();
        }
    }
}
