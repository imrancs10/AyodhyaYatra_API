using System.Data;

namespace KaashiYatra.API.Utility
{
    public interface IExcelReader
    {
        DataTable ReadExcelasDataTable(string excelFilePath);
    }
}
