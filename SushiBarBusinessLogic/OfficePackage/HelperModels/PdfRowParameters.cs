using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    class PdfRowParameters
    {
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public ParagraphAlignment ParagraphAlignment { get; set; }
    }
}
