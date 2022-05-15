using DocumentFormat.OpenXml.Spreadsheet;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    class ExcelMergeParameters
    {
        public string CellFromName { get; set; }
        public string CellToName { get; set; }
        public string Merge => $"{CellFromName}:{CellToName}";
    }
}
