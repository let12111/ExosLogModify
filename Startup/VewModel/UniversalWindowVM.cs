using System.Collections.ObjectModel;
namespace Startup.VewModel
{
    class UniversalWindowVM
    {

        public DataGridColumnsMetaData ColumnsMetaData { get; set; }
        public UniversalWindowVM()

        {
            ColumnsMetaData = new DataGridColumnsMetaData()
            {
                ColumnMeta1 = new RowMetadata()
                { ColumName = "columnName1", isEnable = true }
            };
            Header = "test header";
            AllElemens = new ObservableCollection<RowElement>();
            SelectedElements = new ObservableCollection<RowElement>();
            AllElemens.Add(new RowElement()
            { RowID = "id01" });


            SelectedElements.Add(new RowElement()
            {
                RowID = "id0",
             
            });
        }

        public string Header { get; set; }
       
        public ObservableCollection<RowElement> AllElemens { get; set; }

        public ObservableCollection<RowElement> SelectedElements { get; set; }

        public void Ok() { }
        public void AddElement() { }
        public void RemoveElement() {  }

    }
}
