namespace QC.Lib
{
    public class SearchItem
    {
        private string keyValue;
        private string displayValue;
        private string dataType;
        private string query;

        public string KeyValue
        {
            get
            {
                return keyValue;
            }
        }

        public string DisplayValue
        {
            get
            {
                return displayValue;
            }
        }

        public string DataType
        {
            get
            {
                return dataType;
            }
        }

        public string Query
        {
            get
            {
                return query;
            }
        }

        public SearchItem(string akeyValue, string aDisplayValue, string aDataType, string aQuery)
        {
            keyValue = akeyValue;
            displayValue = aDisplayValue;
            dataType = aDataType;
            query = aQuery;
        }


    }
}
