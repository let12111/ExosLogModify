using System.Collections.ObjectModel;
using Commutator;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using Startup.messages;
namespace Startup.VewModel
{
    class UniversalWindowVM : ViewModelBase
    {
        public RowElement AllItemsSelectedItem { get; set; }
        public RowElement SelectedItemSelectedItems { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand OKCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public DataGridColumnsMetaData ColumnsMetaData { get; set; }
        public UniversalWindowVM(List<RowElement> allElement, List<string> idSelectedElementList , DataGridColumnsMetaData meta)

        {
            ColumnsMetaData = meta;

            AllElemens = new ObservableCollection<RowElement>(allElement);

            var selectedElement = from el in allElement
                                  join idEl in idSelectedElementList
            on el.RowID equals idEl
                                  select el;

            SelectedElements = new ObservableCollection<RowElement>(selectedElement);
            RemoveCommand = new RelayCommand(() => { RemoveElement(); });
            AddCommand = new RelayCommand(() => { AddElement(); });
            OKCommand = new RelayCommand(() => { Ok(); });
            CancelCommand = new RelayCommand(() => { Cancel(); });
        }

        public string Header { get; set; }

        public ObservableCollection<RowElement> AllElemens { get; set; }

        public ObservableCollection<RowElement> SelectedElements { get; set; }

        void Ok() {
            var messOk = new UniversalEditWindowOK() { SelectedIDList = SelectedElements.Select(x => x.RowID).ToList() };

            Messenger.Default.Send<UniversalEditWindowOK>(messOk);

        }
        void AddElement() {
            if (AllItemsSelectedItem!=null && !SelectedElements.Contains(AllItemsSelectedItem))
            {
                SelectedElements.Add(AllItemsSelectedItem);
            }

        }
        void RemoveElement()
        {
            if (SelectedItemSelectedItems!=null)
            {
                SelectedElements.Remove(SelectedItemSelectedItems);
            }

        }
        void Cancel()
        {
            Messenger.Default.Send<UniversalEditWindowCancel>(new UniversalEditWindowCancel());
        }
    }
}
