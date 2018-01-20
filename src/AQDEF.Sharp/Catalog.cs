using System;
using System.Collections.Generic;

namespace AQDEF.Sharp {
    public sealed class Catalog {
        //*******************************************
        // Attributes
        //*******************************************

        public static readonly Catalog SUPPLIER = new Catalog("SUPPLIER", InnerEnum.SUPPLIER, "LIEFERAN");
        public static readonly Catalog CUSTOMER = new Catalog("CUSTOMER", InnerEnum.CUSTOMER, "KUNDE");
        public static readonly Catalog EMPLOYEE = new Catalog("EMPLOYEE", InnerEnum.EMPLOYEE, "MITARB");
        public static readonly Catalog OPERATOR = new Catalog("OPERATOR", InnerEnum.OPERATOR, "PRUEFER");
        public static readonly Catalog MACHINE = new Catalog("MACHINE", InnerEnum.MACHINE, "MASCHINE");
        public static readonly Catalog TOOL = new Catalog("TOOL", InnerEnum.TOOL, "NEST");
        public static readonly Catalog MANUFACTURER = new Catalog("MANUFACTURER", InnerEnum.MANUFACTURER, "HERSTELL");
        public static readonly Catalog MATERIAL = new Catalog("MATERIAL", InnerEnum.MATERIAL, "WERKSTOF");
        public static readonly Catalog UNIT = new Catalog("UNIT", InnerEnum.UNIT, "EINHEIT");
        public static readonly Catalog DRAWING = new Catalog("DRAWING", InnerEnum.DRAWING, "ZEICHN");
        public static readonly Catalog PRODUCT = new Catalog("PRODUCT", InnerEnum.PRODUCT, "ERZEUGNIS");
        public static readonly Catalog PURCHASE_ORDER = new Catalog("PURCHASE_ORDER", InnerEnum.PURCHASE_ORDER, "PAUFTRAG");

        /// <summary>
        /// BEWARE - table is the same for Event, Cause and Measure catalogs - catalogs are separated by ID offset (OMG WTF?)
        /// </summary>
        public static readonly Catalog EVENT = new Catalog("EVENT", InnerEnum.EVENT, "EREIGTXT");

        /// <summary>
        /// BEWARE - table is the same for Event, Cause and Measure catalogs - catalogs are separated by ID offset (OMG WTF?)
        /// </summary>
        public static readonly Catalog CAUSE = new Catalog("CAUSE", InnerEnum.CAUSE, "EREIGTXT");
        /// <summary>
        /// BEWARE - table is the same for Event, Cause and Measure catalogs - catalogs are separated by ID offset (OMG WTF?)
        /// </summary>
        public static readonly Catalog MEASURE = new Catalog("MEASURE", InnerEnum.MEASURE, "EREIGTXT");

        public static readonly Catalog ORDINAL_CLASS = new Catalog("ORDINAL_CLASS", InnerEnum.ORDINAL_CLASS, "ORDKLASS");
        public static readonly Catalog CONTRACTOR = new Catalog("CONTRACTOR", InnerEnum.CONTRACTOR, "AUFTRGEB");
        public static readonly Catalog GAGE = new Catalog("GAGE", InnerEnum.GAGE, "PRUEFMIT");
        public static readonly Catalog PROCESS_PARAMETER = new Catalog("PROCESS_PARAMETER", InnerEnum.PROCESS_PARAMETER, "PROZPARAMTXT");
        public static readonly Catalog K0061 = new Catalog("K0061", InnerEnum.K0061, "KAT_4270");
        public static readonly Catalog K0062 = new Catalog("K0062", InnerEnum.K0062, "KAT_4280");
        public static readonly Catalog K0063 = new Catalog("K0063", InnerEnum.K0063, "KAT_4290");

        private static readonly IDictionary<string,Catalog> valueList = new Dictionary<string, Catalog>();

        private enum InnerEnum {
            SUPPLIER,
            CUSTOMER,
            EMPLOYEE,
            OPERATOR,
            MACHINE,
            TOOL,
            MANUFACTURER,
            MATERIAL,
            UNIT,
            DRAWING,
            PRODUCT,
            PURCHASE_ORDER,
            EVENT,
            CAUSE,
            MEASURE,
            ORDINAL_CLASS,
            CONTRACTOR,
            GAGE,
            PROCESS_PARAMETER,
            K0061,
            K0062,
            K0063
        }

        private readonly InnerEnum innerEnumValue;
        private readonly string nameValue;

        private readonly string tableName;

        //*******************************************
        // Constructors
        //*******************************************

        private Catalog(string name, InnerEnum catalogType, string tableName) {
            this.tableName = tableName;
            nameValue = name;
            this.innerEnumValue = catalogType;
            valueList.Add(name,this);
        }

        //*******************************************
        // Getters / setters
        //*******************************************

        public string TableName {
            get {
                return tableName;
            }
        }


        public static ICollection<Catalog> Values {
            get { return valueList.Values; }
        }

        public int Ordinal {
            get { return (int) innerEnumValue; }
        }

        public override string ToString() {
            return nameValue;
        }

        public static Catalog ValueOf(string name) {
            Catalog result = null;
           if(valueList.TryGetValue(name, out result)) {
               return result;
           }
            
            throw new IndexOutOfRangeException($"Catalog {name} Not Existed");
        }
    }
}