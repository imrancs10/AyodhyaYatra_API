using System.Data;

namespace AyodhyaYatra.API.Utility
{
    public interface IExcelReader
    {
        DataTable ReadExcelasDataTable(string excelFilePath);
    }
}
