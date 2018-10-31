using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Startup.VewModel;

namespace Startup.Common
{
  public  class RowElementMappingHelper
    {
        public List<RowElement>  ConvertToRowElements<T>(List<T> Allelements, List<ColumnMapper> mapper)
        {
            var type = typeof(T);
            List<RowElement> allElements = new List<RowElement>();
           

            foreach (var item in Allelements)
            {

                var rowElement = new RowElement();
                foreach (var mapElement in mapper)
                {
                var currentProp=    type.GetProperty(mapElement.ClassFieldName);

                    var propValue = (string)currentProp.GetValue(item, null);
                    switch (mapElement.Column)
                    {
                        case ColumnsEnum.ColumnID:
                            rowElement.RowID = propValue;
                            break;
                        case ColumnsEnum.Column1:
                            rowElement.RowItem1 = propValue;
                            break;
                        case ColumnsEnum.Column2:
                            rowElement.RowItem2 = propValue;
                            break;
                        case ColumnsEnum.Column3:
                            rowElement.RowItem3 = propValue;
                            break;
                        case ColumnsEnum.Column4:
                            rowElement.RowItem4 = propValue;
                            break;
                        default:
                            break;
                    }

                }

                allElements.Add(rowElement);

                // var rowElement = new RowElement();


                
            }

            return allElements;
            //  type.GetProperties()

        }

    }
}
