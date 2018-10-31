using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Collections.ObjectModel;
using Contracts.SDO;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Startup.Common;
namespace Startup.VewModel
{
    class MainWindowVM : ViewModelBase
    {
        public ObservableCollection<Point> CurrentPoint { get; set; }
        public ObservableCollection<Event> CurrentEvent { get; set; }

        public MainWindowVM()
        {
            FindCommand = new RelayCommand(Find);
            EditCommandPoints = new RelayCommand(EditPoints);
            EditCommandEvents = new RelayCommand(EditEvents);
        }

        public Point SelectedPoint { get; set; }
        public Event SelectedEvent { get; set; }
        public RelayCommand FindCommand { get; set; }
        public RelayCommand EditCommandPoints { get; set; }
        public RelayCommand EditCommandEvents { get; set; }
        void Find() { }

        void EditPoints()
        {
            UniversalEditWindow wnd = new UniversalEditWindow();

            Point pn = new Point { PointId = "pid1", PointName = "pn1", PointType = "pt1" };
            Point pn1 = new Point { PointId = "pid2", PointName = "pn2", PointType = "pt2" };
            List<Point> pointList = new List<Point>();
            pointList.Add(pn);
            pointList.Add(pn1);
            RowElementMappingHelper remh = new RowElementMappingHelper();
            ColumnMapper cmp = new ColumnMapper() {  ClassFieldName="PointID",Column=ColumnsEnum.Column1,ColumnName="PointName"};
            ColumnMapper cmp1 = new ColumnMapper() { ClassFieldName = "PointName", Column = ColumnsEnum.Column2, ColumnName = "Point Name1" };
            List<ColumnMapper> columnMaper = new List<ColumnMapper>();
            columnMaper.Add(cmp);
            columnMaper.Add(cmp1);
          var list=  remh.ConvertToRowElements<Point>(pointList, columnMaper);
            // rowe

            DataGridColumnsMetaData meta = new DataGridColumnsMetaData();
            meta.ColumnMeta1 = new RowMetadata() { ColumName="Имя Точки",IsEnable=true};
            meta.ColumnMeta2= new RowMetadata() { ColumName = "Имя Точки", IsEnable = true };
            meta.ColumnMeta3= new RowMetadata() { ColumName = "Имя Точки", IsEnable = true };
            meta.ColumnMeta4 = new RowMetadata() { ColumName = "Имя Точки", IsEnable = true };
            UniversalWindowVM universalWindowVm = new UniversalWindowVM(list, new List<string>(),meta);
            wnd.DataContext = universalWindowVm;
            wnd.ShowDialog();


            //wnd.ShowDialog();
        }
        void EditEvents() { }

    }
}
