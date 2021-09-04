using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace __UI_____Panda_A_.Core.User_Level
{
    public class Editor : VisualLineElementGenerator
    {
        public override int GetFirstInterestedOffset(int startOffset)
        {
            DocumentLine lastDocumentLine = base.CurrentContext.VisualLine.LastDocumentLine;
            if (lastDocumentLine.Length > 400)
            {
                int num = lastDocumentLine.Offset + 400 - "...".Length;
                if (startOffset <= num)
                {
                    return num;
                }
            }
            return -1;
        }

        public override VisualLineElement ConstructElement(int offset)
        {
            return new FormattedTextElement("...", base.CurrentContext.VisualLine.LastDocumentLine.EndOffset - offset);
        }
    }
}
