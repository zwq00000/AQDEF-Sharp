using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp {
    internal class CatalogField {
        /*
        public static readonly CatalogField K4020 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4020_ID"), KKeyMetadata.of<int>("LILFDNR"), CatalogFieldType.ID);
        public static readonly CatalogField K4022 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4022"), KKeyMetadata.of("LINR", typeof(string), 20));
        public static readonly CatalogField K4023 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4023"), KKeyMetadata.of("LINAME1",typeof(string), 80));
        public static readonly CatalogField K4024 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4024"), KKeyMetadata.of("LINAME2",typeof(string), 80));
        public static readonly CatalogField K4025 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4025"), KKeyMetadata.of("LIWERKSSCHL",typeof(string), 50));
        public static readonly CatalogField K4026 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4026"), KKeyMetadata.of("LIWERK",typeof(string), 50));
        public static readonly CatalogField K4027 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4027"), KKeyMetadata.of("LISTRASSE",typeof(string), 50));
        public static readonly CatalogField K4028 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4028"), KKeyMetadata.of("LIORT",typeof(string), 50));
        public static readonly CatalogField K4029 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4029"), KKeyMetadata.of("LILAND",typeof(string), 50));
        public static readonly CatalogField K4521 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4521"), KKeyMetadata.of("LISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4522 = new CatalogField(Catalog.SUPPLIER, KKey.of("K4522"), KKeyMetadata.of("LIMEMO",typeof(string), 255));

        public static readonly CatalogField K4000 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4000_ID"), KKeyMetadata.of("KULFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4002 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4002"), KKeyMetadata.of("KUNR",typeof(string), 20));
        public static readonly CatalogField K4003 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4003"), KKeyMetadata.of("KUNAME1",typeof(string), 80));
        public static readonly CatalogField K4004 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4004"), KKeyMetadata.of("KUNAME2",typeof(string), 80));
        public static readonly CatalogField K4005 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4005"), KKeyMetadata.of("KUWERKSSCHL",typeof(string), 50));
        public static readonly CatalogField K4006 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4006"), KKeyMetadata.of("KUWERK",typeof(string), 50));
        public static readonly CatalogField K4007 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4007"), KKeyMetadata.of("KUSTRASSE",typeof(string), 50));
        public static readonly CatalogField K4008 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4008"), KKeyMetadata.of("KUORT",typeof(string), 50));
        public static readonly CatalogField K4009 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4009"), KKeyMetadata.of("KULAND",typeof(string), 50));
        public static readonly CatalogField K4501 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4501"), KKeyMetadata.of("KUSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4502 = new CatalogField(Catalog.CUSTOMER, KKey.of("K4502"), KKeyMetadata.of("KUMEMO",typeof(string), 255));

        public static readonly CatalogField K4120 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4120_ID"), KKeyMetadata.of("MIMITARB", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4122 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4122"), KKeyMetadata.of("MINAME1",typeof(string), 50));
        public static readonly CatalogField K4123 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4123"), KKeyMetadata.of("MINAME2",typeof(string), 50));
        public static readonly CatalogField K4124 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4124"), KKeyMetadata.of("MIABT",typeof(string), 50));
        public static readonly CatalogField K4125 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4125"), KKeyMetadata.of("MITELEFON",typeof(string), 50));
        public static readonly CatalogField K4126 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4126"), KKeyMetadata.of("MIFAX",typeof(string), 50));
        public static readonly CatalogField K4127 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4127"), KKeyMetadata.of("MIEMAIL",typeof(string), 50));
        public static readonly CatalogField K4128 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4128"), KKeyMetadata.of("MIPOS",typeof(string), 30));
        public static readonly CatalogField K4129 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4129"), KKeyMetadata.of("MIANREDE",typeof(string), 15));
        public static readonly CatalogField K4621 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4621"), KKeyMetadata.of("MISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4622 = new CatalogField(Catalog.EMPLOYEE, KKey.of("K4622"), KKeyMetadata.of("MIBEMERK",typeof(string), 200));

        public static readonly CatalogField K4090 = new CatalogField(Catalog.OPERATOR, KKey.of("K4090_ID"), KKeyMetadata.of("PRPRUEFER", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4092 = new CatalogField(Catalog.OPERATOR, KKey.of("K4092"), KKeyMetadata.of("PRNAME",typeof(string), 50));
        public static readonly CatalogField K4093 = new CatalogField(Catalog.OPERATOR, KKey.of("K4093"), KKeyMetadata.of("PRVORNAME",typeof(string), 50));
        public static readonly CatalogField K4094 = new CatalogField(Catalog.OPERATOR, KKey.of("K4094"), KKeyMetadata.of("PRABT",typeof(string), 50));
        public static readonly CatalogField K4095 = new CatalogField(Catalog.OPERATOR, KKey.of("K4095"), KKeyMetadata.of("PRTELEFON",typeof(string), 50));
        public static readonly CatalogField K4096 = new CatalogField(Catalog.OPERATOR, KKey.of("K4096"), KKeyMetadata.of("PRFAX",typeof(string), 50));
        public static readonly CatalogField K4097 = new CatalogField(Catalog.OPERATOR, KKey.of("K4097"), KKeyMetadata.of("PREMAIL",typeof(string), 50));
        public static readonly CatalogField K4098 = new CatalogField(Catalog.OPERATOR, KKey.of("K4098"), KKeyMetadata.of("PRPOS",typeof(string), 30));
        public static readonly CatalogField K4099 = new CatalogField(Catalog.OPERATOR, KKey.of("K4099"), KKeyMetadata.of("PRANREDE",typeof(string), 15));
        public static readonly CatalogField K4591 = new CatalogField(Catalog.OPERATOR, KKey.of("K4591"), KKeyMetadata.of("PRSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4592 = new CatalogField(Catalog.OPERATOR, KKey.of("K4592"), KKeyMetadata.of("PRBEMERK",typeof(string), 200));

        public static readonly CatalogField K4060 = new CatalogField(Catalog.MACHINE, KKey.of("K4060_ID"), KKeyMetadata.of("MAMASCHINE", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4062 = new CatalogField(Catalog.MACHINE, KKey.of("K4062"), KKeyMetadata.of("MANR",typeof(string), 40));
        public static readonly CatalogField K4063 = new CatalogField(Catalog.MACHINE, KKey.of("K4063"), KKeyMetadata.of("MABEZ",typeof(string), 100));
        public static readonly CatalogField K4064 = new CatalogField(Catalog.MACHINE, KKey.of("K4064"), KKeyMetadata.of("MABEREICH",typeof(string), 50));
        public static readonly CatalogField K4065 = new CatalogField(Catalog.MACHINE, KKey.of("K4065"), KKeyMetadata.of("MAABT",typeof(string), 50));
        public static readonly CatalogField K4066 = new CatalogField(Catalog.MACHINE, KKey.of("K4066"), KKeyMetadata.of("MAOPNR",typeof(string), 50));
        public static readonly CatalogField K4067 = new CatalogField(Catalog.MACHINE, KKey.of("K4067"), KKeyMetadata.of("MAEXTREFNR",typeof(string), 50));
        public static readonly CatalogField K4561 = new CatalogField(Catalog.MACHINE, KKey.of("K4561"), KKeyMetadata.of("MASTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4562 = new CatalogField(Catalog.MACHINE, KKey.of("K4562"), KKeyMetadata.of("MABESCH",typeof(string), 200));

        public static readonly CatalogField K4250 = new CatalogField(Catalog.TOOL, KKey.of("K4250_ID"), KKeyMetadata.of("NENEST", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4252 = new CatalogField(Catalog.TOOL, KKey.of("K4252"), KKeyMetadata.of("NEBESCH",typeof(string), 80));
        public static readonly CatalogField K4253 = new CatalogField(Catalog.TOOL, KKey.of("K4253"), KKeyMetadata.of("SMART_NENR",typeof(string), 100));
        public static readonly CatalogField K4751 = new CatalogField(Catalog.TOOL, KKey.of("K4751"), KKeyMetadata.of("NESTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4752 = new CatalogField(Catalog.TOOL, KKey.of("K4752"), KKeyMetadata.of("NEBEMERK",typeof(string), 200));

        public static readonly CatalogField K4010 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4010_ID"), KKeyMetadata.of("HELFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4012 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4012"), KKeyMetadata.of("HENR",typeof(string), 50));
        public static readonly CatalogField K4013 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4013"), KKeyMetadata.of("HENAME1",typeof(string), 80));
        public static readonly CatalogField K4014 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4014"), KKeyMetadata.of("HENAME2",typeof(string), 80));
        public static readonly CatalogField K4015 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4015"), KKeyMetadata.of("HEWERKSSCHL",typeof(string), 50));
        public static readonly CatalogField K4016 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4016"), KKeyMetadata.of("HEWERK",typeof(string), 50));
        public static readonly CatalogField K4017 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4017"), KKeyMetadata.of("HESTRASSE",typeof(string), 50));
        public static readonly CatalogField K4018 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4018"), KKeyMetadata.of("HEORT",typeof(string), 50));
        public static readonly CatalogField K4019 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4019"), KKeyMetadata.of("HELAND",typeof(string), 50));
        public static readonly CatalogField K4512 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4512"), KKeyMetadata.of("HEMEMO", typeof(string)));
        public static readonly CatalogField K4511 = new CatalogField(Catalog.MANUFACTURER, KKey.of("K4511"), KKeyMetadata.of("HESTATE", typeof(int)), CatalogFieldType.STATE);

        public static readonly CatalogField K4040 = new CatalogField(Catalog.MATERIAL, KKey.of("K4040_ID"), KKeyMetadata.of("WSLFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4042 = new CatalogField(Catalog.MATERIAL, KKey.of("K4042"), KKeyMetadata.of("WSNR",typeof(string), 50));
        public static readonly CatalogField K4043 = new CatalogField(Catalog.MATERIAL, KKey.of("K4043"), KKeyMetadata.of("WSBEZEICH",typeof(string), 100));
        public static readonly CatalogField K4541 = new CatalogField(Catalog.MATERIAL, KKey.of("K4541"), KKeyMetadata.of("WSSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4542 = new CatalogField(Catalog.MATERIAL, KKey.of("K4542"), KKeyMetadata.of("WSBEMERK",typeof(string), 200));

        public static readonly CatalogField K4080 = new CatalogField(Catalog.UNIT, KKey.of("K4080_ID"), KKeyMetadata.of("EIEINHEIT", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4082 = new CatalogField(Catalog.UNIT, KKey.of("K4082"), KKeyMetadata.of("EIEINHTEXT",typeof(string), 100));
        public static readonly CatalogField K4581 = new CatalogField(Catalog.UNIT, KKey.of("K4581"), KKeyMetadata.of("EISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4582 = new CatalogField(Catalog.UNIT, KKey.of("K4582"), KKeyMetadata.of("EIBEMERK",typeof(string), 200));

        public static readonly CatalogField K4050 = new CatalogField(Catalog.DRAWING, KKey.of("K4050_ID"), KKeyMetadata.of("ZNTEIL", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4052 = new CatalogField(Catalog.DRAWING, KKey.of("K4052"), KKeyMetadata.of("ZNZNR",typeof(string), 40));
        public static readonly CatalogField K4053 = new CatalogField(Catalog.DRAWING, KKey.of("K4053"), KKeyMetadata.of("ZNZNRINDEX",typeof(string), 100));
        public static readonly CatalogField K4551 = new CatalogField(Catalog.DRAWING, KKey.of("K4551"), KKeyMetadata.of("ZNSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4552 = new CatalogField(Catalog.DRAWING, KKey.of("K4552"), KKeyMetadata.of("ZNBEMERK",typeof(string), 200));

        public static readonly CatalogField K4110 = new CatalogField(Catalog.PRODUCT, KKey.of("K4110_ID"), KKeyMetadata.of("EZERZEUGNIS", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4112 = new CatalogField(Catalog.PRODUCT, KKey.of("K4112"), KKeyMetadata.of("EZNUMMER",typeof(string), 20));
        public static readonly CatalogField K4113 = new CatalogField(Catalog.PRODUCT, KKey.of("K4113"), KKeyMetadata.of("EZBEZ",typeof(string), 80));

        public static readonly CatalogField K4114 =
            new CatalogField(Catalog.PRODUCT, KKey.of("K4114"), KKeyMetadata.of("EZKUNDE", typeof(int))); // vazba na CUSTOME;
        public static readonly CatalogField K4611 = new CatalogField(Catalog.PRODUCT, KKey.of("K4611"), KKeyMetadata.of("EZSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4612 = new CatalogField(Catalog.PRODUCT, KKey.of("K4612"), KKeyMetadata.of("EZBEMERK",typeof(string), 200));

        public static readonly CatalogField K4030 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.of("K4030_ID"), KKeyMetadata.of("PAAUFTRAG", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4032 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.of("K4032"), KKeyMetadata.of("PAAUFTRAGNR",typeof(string), 40));
        public static readonly CatalogField K4033 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.of("K4033"), KKeyMetadata.of("PABEZEICH",typeof(string), 100));
        public static readonly CatalogField K4531 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.of("K4531"), KKeyMetadata.of("PASTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4532 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.of("K4532"), KKeyMetadata.of("PABEMERK",typeof(string), 200));

        public static readonly CatalogField K4230 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4230_ID"), KKeyMetadata.of("OKKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4232 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4232"), KKeyMetadata.of("OKNR",typeof(string), 40));
        public static readonly CatalogField K4233 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4233"), KKeyMetadata.of("OKBEZ",typeof(string), 100));
        public static readonly CatalogField K4234 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4234"), KKeyMetadata.of("OKKURZBEZ",typeof(string), 20));
        public static readonly CatalogField K4235 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4235"), KKeyMetadata.of("OKBEWERT", typeof(int)));
        public static readonly CatalogField K4236 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4236"), KKeyMetadata.of("OKSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4731 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4731"), KKeyMetadata.of("OKRANG", typeof(int)));
        public static readonly CatalogField K4732 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.of("K4732"), KKeyMetadata.of("OKBEMERK",typeof(string), 200));

        public static readonly CatalogField K4100 = new CatalogField(Catalog.CONTRACTOR, KKey.of("K4100_ID"), KKeyMetadata.of("AULFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4102 = new CatalogField(Catalog.CONTRACTOR, KKey.of("K4102"), KKeyMetadata.of("AUNR",typeof(string), 50));
        public static readonly CatalogField K4103 = new CatalogField(Catalog.CONTRACTOR, KKey.of("K4103"), KKeyMetadata.of("AUNAME1",typeof(string), 100));
        public static readonly CatalogField K4601 = new CatalogField(Catalog.CONTRACTOR, KKey.of("K4601"), KKeyMetadata.of("AUGSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4602 = new CatalogField(Catalog.CONTRACTOR, KKey.of("K4602"), KKeyMetadata.of("AUMEMO", typeof(string)));

        public static readonly CatalogField K4070 = new CatalogField(Catalog.GAGE, KKey.of("K4070"), KKeyMetadata.of("PMPRUEFMIT", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4072 = new CatalogField(Catalog.GAGE, KKey.of("K4072"), KKeyMetadata.of("PMNR",typeof(string), 40));
        public static readonly CatalogField K4073 = new CatalogField(Catalog.GAGE, KKey.of("K4073"), KKeyMetadata.of("PMBEZ",typeof(string), 80));

        public static readonly CatalogField K4074 =
            new CatalogField(Catalog.GAGE, KKey.of("K4074"), KKeyMetadata.of("PMGRUPPE", typeof(int))); // vazb;
        public static readonly CatalogField K4075 = new CatalogField(Catalog.GAGE, KKey.of("K4075"), KKeyMetadata.of("PMLETZTDAT", typeof(DateTime)));
        public static readonly CatalogField K4076 = new CatalogField(Catalog.GAGE, KKey.of("K4076"), KKeyMetadata.of("PMNAECHDAT", typeof(DateTime)));
        public static readonly CatalogField K4077 = new CatalogField(Catalog.GAGE, KKey.of("K4077"), KKeyMetadata.of("PMIPADDR",typeof(string), 30));
        public static readonly CatalogField K4078 = new CatalogField(Catalog.GAGE, KKey.of("K4078"), KKeyMetadata.of("PMEINSORT",typeof(string), 50));
        public static readonly CatalogField K4079 = new CatalogField(Catalog.GAGE, KKey.of("K4079"), KKeyMetadata.of("PMCOMP",typeof(string), 50));
        public static readonly CatalogField K4571 = new CatalogField(Catalog.GAGE, KKey.of("K4571"), KKeyMetadata.of("PMSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4572 = new CatalogField(Catalog.GAGE, KKey.of("K4572"), KKeyMetadata.of("PM_BESCH",typeof(string), 200));
        public static readonly CatalogField K4575 = new CatalogField(Catalog.GAGE, KKey.of("K4575"), KKeyMetadata.of("PMQVERS",typeof(string), 30));
        public static readonly CatalogField K4576 = new CatalogField(Catalog.GAGE, KKey.of("K4576"), KKeyMetadata.of("PMSOFTW",typeof(string), 50));

        public static readonly CatalogField K4240 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4240_ID"), KKeyMetadata.of("PPNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4242 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4242"), KKeyMetadata.of("PPNRTEXT",typeof(string), 40));
        public static readonly CatalogField K4244 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4244"), KKeyMetadata.of("PPKURZTEXT",typeof(string), 20));
        public static readonly CatalogField K4243 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4243"), KKeyMetadata.of("PPLANGTEXT",typeof(string), 100));
        public static readonly CatalogField K4741 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4741"), KKeyMetadata.of("PPSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4742 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.of("K4742"), KKeyMetadata.of("PPBEMERK",typeof(string), 200));

        public static readonly CatalogField K4270 = new CatalogField(Catalog.K0061, KKey.of("K4270_ID"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4272 = new CatalogField(Catalog.K0061, KKey.of("K4272"), KKeyMetadata.of("NR",typeof(string), 20));
        public static readonly CatalogField K4273 = new CatalogField(Catalog.K0061, KKey.of("K4273"), KKeyMetadata.of("BEZ",typeof(string), 100));
        public static readonly CatalogField K4771 = new CatalogField(Catalog.K0061, KKey.of("K4771"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4772 = new CatalogField(Catalog.K0061, KKey.of("K4772"), KKeyMetadata.of("BEMERK",typeof(string), 200));

        public static readonly CatalogField K4280 = new CatalogField(Catalog.K0062, KKey.of("K4280_ID"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4282 = new CatalogField(Catalog.K0062, KKey.of("K4282"), KKeyMetadata.of("NR",typeof(string), 20));
        public static readonly CatalogField K4283 = new CatalogField(Catalog.K0062, KKey.of("K4283"), KKeyMetadata.of("BEZ",typeof(string), 100));
        public static readonly CatalogField K4781 = new CatalogField(Catalog.K0062, KKey.of("K4781"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4782 = new CatalogField(Catalog.K0062, KKey.of("K4782"), KKeyMetadata.of("BEMERK",typeof(string), 200));

        public static readonly CatalogField K4290 = new CatalogField(Catalog.K0063, KKey.of("K4290"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4292 = new CatalogField(Catalog.K0063, KKey.of("K4292"), KKeyMetadata.of("NR",typeof(string), 20));
        public static readonly CatalogField K4293 = new CatalogField(Catalog.K0063, KKey.of("K4293"), KKeyMetadata.of("BEZ",typeof(string), 100));
        public static readonly CatalogField K4791 = new CatalogField(Catalog.K0063, KKey.of("K4791"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4792 = new CatalogField(Catalog.K0063, KKey.of("K4792"), KKeyMetadata.of("BEMERK",typeof(string), 200));

        */
        public static readonly CatalogField K4020 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4020_ID"), KKeyMetadata.of("LILFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4022 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4022"), KKeyMetadata.of("LINR", typeof(string), 20));
        public static readonly CatalogField K4023 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4023"), KKeyMetadata.of("LINAME1", typeof(string), 80));
        public static readonly CatalogField K4024 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4024"), KKeyMetadata.of("LINAME2", typeof(string), 80));
        public static readonly CatalogField K4025 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4025"), KKeyMetadata.of("LIWERKSSCHL", typeof(string), 50));
        public static readonly CatalogField K4026 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4026"), KKeyMetadata.of("LIWERK", typeof(string), 50));
        public static readonly CatalogField K4027 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4027"), KKeyMetadata.of("LISTRASSE", typeof(string), 50));
        public static readonly CatalogField K4028 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4028"), KKeyMetadata.of("LIORT", typeof(string), 50));
        public static readonly CatalogField K4029 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4029"), KKeyMetadata.of("LILAND", typeof(string), 50));
        public static readonly CatalogField K4521 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4521"), KKeyMetadata.of("LISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4522 = new CatalogField(Catalog.SUPPLIER, KKey.Of("K4522"), KKeyMetadata.of("LIMEMO", typeof(string), 255));

        public static readonly CatalogField K4000 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4000_ID"), KKeyMetadata.of("KULFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4002 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4002"), KKeyMetadata.of("KUNR", typeof(string), 20));
        public static readonly CatalogField K4003 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4003"), KKeyMetadata.of("KUNAME1", typeof(string), 80));
        public static readonly CatalogField K4004 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4004"), KKeyMetadata.of("KUNAME2", typeof(string), 80));
        public static readonly CatalogField K4005 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4005"), KKeyMetadata.of("KUWERKSSCHL", typeof(string), 50));
        public static readonly CatalogField K4006 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4006"), KKeyMetadata.of("KUWERK", typeof(string), 50));
        public static readonly CatalogField K4007 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4007"), KKeyMetadata.of("KUSTRASSE", typeof(string), 50));
        public static readonly CatalogField K4008 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4008"), KKeyMetadata.of("KUORT", typeof(string), 50));
        public static readonly CatalogField K4009 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4009"), KKeyMetadata.of("KULAND", typeof(string), 50));
        public static readonly CatalogField K4501 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4501"), KKeyMetadata.of("KUSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4502 = new CatalogField(Catalog.CUSTOMER, KKey.Of("K4502"), KKeyMetadata.of("KUMEMO", typeof(string), 255));

        public static readonly CatalogField K4120 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4120_ID"), KKeyMetadata.of("MIMITARB", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4122 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4122"), KKeyMetadata.of("MINAME1", typeof(string), 50));
        public static readonly CatalogField K4123 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4123"), KKeyMetadata.of("MINAME2", typeof(string), 50));
        public static readonly CatalogField K4124 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4124"), KKeyMetadata.of("MIABT", typeof(string), 50));
        public static readonly CatalogField K4125 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4125"), KKeyMetadata.of("MITELEFON", typeof(string), 50));
        public static readonly CatalogField K4126 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4126"), KKeyMetadata.of("MIFAX", typeof(string), 50));
        public static readonly CatalogField K4127 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4127"), KKeyMetadata.of("MIEMAIL", typeof(string), 50));
        public static readonly CatalogField K4128 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4128"), KKeyMetadata.of("MIPOS", typeof(string), 30));
        public static readonly CatalogField K4129 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4129"), KKeyMetadata.of("MIANREDE", typeof(string), 15));
        public static readonly CatalogField K4621 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4621"), KKeyMetadata.of("MISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4622 = new CatalogField(Catalog.EMPLOYEE, KKey.Of("K4622"), KKeyMetadata.of("MIBEMERK", typeof(string), 200));

        public static readonly CatalogField K4090 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4090_ID"), KKeyMetadata.of("PRPRUEFER", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4092 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4092"), KKeyMetadata.of("PRNAME", typeof(string), 50));
        public static readonly CatalogField K4093 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4093"), KKeyMetadata.of("PRVORNAME", typeof(string), 50));
        public static readonly CatalogField K4094 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4094"), KKeyMetadata.of("PRABT", typeof(string), 50));
        public static readonly CatalogField K4095 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4095"), KKeyMetadata.of("PRTELEFON", typeof(string), 50));
        public static readonly CatalogField K4096 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4096"), KKeyMetadata.of("PRFAX", typeof(string), 50));
        public static readonly CatalogField K4097 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4097"), KKeyMetadata.of("PREMAIL", typeof(string), 50));
        public static readonly CatalogField K4098 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4098"), KKeyMetadata.of("PRPOS", typeof(string), 30));
        public static readonly CatalogField K4099 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4099"), KKeyMetadata.of("PRANREDE", typeof(string), 15));
        public static readonly CatalogField K4591 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4591"), KKeyMetadata.of("PRSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4592 = new CatalogField(Catalog.OPERATOR, KKey.Of("K4592"), KKeyMetadata.of("PRBEMERK", typeof(string), 200));

        public static readonly CatalogField K4060 = new CatalogField(Catalog.MACHINE, KKey.Of("K4060_ID"), KKeyMetadata.of("MAMASCHINE", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4062 = new CatalogField(Catalog.MACHINE, KKey.Of("K4062"), KKeyMetadata.of("MANR", typeof(string), 40));
        public static readonly CatalogField K4063 = new CatalogField(Catalog.MACHINE, KKey.Of("K4063"), KKeyMetadata.of("MABEZ", typeof(string), 100));
        public static readonly CatalogField K4064 = new CatalogField(Catalog.MACHINE, KKey.Of("K4064"), KKeyMetadata.of("MABEREICH", typeof(string), 50));
        public static readonly CatalogField K4065 = new CatalogField(Catalog.MACHINE, KKey.Of("K4065"), KKeyMetadata.of("MAABT", typeof(string), 50));
        public static readonly CatalogField K4066 = new CatalogField(Catalog.MACHINE, KKey.Of("K4066"), KKeyMetadata.of("MAOPNR", typeof(string), 50));
        public static readonly CatalogField K4067 = new CatalogField(Catalog.MACHINE, KKey.Of("K4067"), KKeyMetadata.of("MAEXTREFNR", typeof(string), 50));
        public static readonly CatalogField K4561 = new CatalogField(Catalog.MACHINE, KKey.Of("K4561"), KKeyMetadata.of("MASTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4562 = new CatalogField(Catalog.MACHINE, KKey.Of("K4562"), KKeyMetadata.of("MABESCH", typeof(string), 200));

        public static readonly CatalogField K4250 = new CatalogField(Catalog.TOOL, KKey.Of("K4250_ID"), KKeyMetadata.of("NENEST", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4252 = new CatalogField(Catalog.TOOL, KKey.Of("K4252"), KKeyMetadata.of("NEBESCH", typeof(string), 80));
        public static readonly CatalogField K4253 = new CatalogField(Catalog.TOOL, KKey.Of("K4253"), KKeyMetadata.of("SMART_NENR", typeof(string), 100));
        public static readonly CatalogField K4751 = new CatalogField(Catalog.TOOL, KKey.Of("K4751"), KKeyMetadata.of("NESTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4752 = new CatalogField(Catalog.TOOL, KKey.Of("K4752"), KKeyMetadata.of("NEBEMERK", typeof(string), 200));

        public static readonly CatalogField K4010 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4010_ID"), KKeyMetadata.of("HELFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4012 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4012"), KKeyMetadata.of("HENR", typeof(string), 50));
        public static readonly CatalogField K4013 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4013"), KKeyMetadata.of("HENAME1", typeof(string), 80));
        public static readonly CatalogField K4014 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4014"), KKeyMetadata.of("HENAME2", typeof(string), 80));
        public static readonly CatalogField K4015 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4015"), KKeyMetadata.of("HEWERKSSCHL", typeof(string), 50));
        public static readonly CatalogField K4016 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4016"), KKeyMetadata.of("HEWERK", typeof(string), 50));
        public static readonly CatalogField K4017 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4017"), KKeyMetadata.of("HESTRASSE", typeof(string), 50));
        public static readonly CatalogField K4018 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4018"), KKeyMetadata.of("HEORT", typeof(string), 50));
        public static readonly CatalogField K4019 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4019"), KKeyMetadata.of("HELAND", typeof(string), 50));
        public static readonly CatalogField K4512 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4512"), KKeyMetadata.of("HEMEMO", typeof(string)));
        public static readonly CatalogField K4511 = new CatalogField(Catalog.MANUFACTURER, KKey.Of("K4511"), KKeyMetadata.of("HESTATE", typeof(int)), CatalogFieldType.STATE);

        public static readonly CatalogField K4040 = new CatalogField(Catalog.MATERIAL, KKey.Of("K4040_ID"), KKeyMetadata.of("WSLFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4042 = new CatalogField(Catalog.MATERIAL, KKey.Of("K4042"), KKeyMetadata.of("WSNR", typeof(string), 50));
        public static readonly CatalogField K4043 = new CatalogField(Catalog.MATERIAL, KKey.Of("K4043"), KKeyMetadata.of("WSBEZEICH", typeof(string), 100));
        public static readonly CatalogField K4541 = new CatalogField(Catalog.MATERIAL, KKey.Of("K4541"), KKeyMetadata.of("WSSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4542 = new CatalogField(Catalog.MATERIAL, KKey.Of("K4542"), KKeyMetadata.of("WSBEMERK", typeof(string), 200));

        public static readonly CatalogField K4080 = new CatalogField(Catalog.UNIT, KKey.Of("K4080_ID"), KKeyMetadata.of("EIEINHEIT", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4082 = new CatalogField(Catalog.UNIT, KKey.Of("K4082"), KKeyMetadata.of("EIEINHTEXT", typeof(string), 100));
        public static readonly CatalogField K4581 = new CatalogField(Catalog.UNIT, KKey.Of("K4581"), KKeyMetadata.of("EISTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4582 = new CatalogField(Catalog.UNIT, KKey.Of("K4582"), KKeyMetadata.of("EIBEMERK", typeof(string), 200));

        public static readonly CatalogField K4050 = new CatalogField(Catalog.DRAWING, KKey.Of("K4050_ID"), KKeyMetadata.of("ZNTEIL", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4052 = new CatalogField(Catalog.DRAWING, KKey.Of("K4052"), KKeyMetadata.of("ZNZNR", typeof(string), 40));
        public static readonly CatalogField K4053 = new CatalogField(Catalog.DRAWING, KKey.Of("K4053"), KKeyMetadata.of("ZNZNRINDEX", typeof(string), 100));
        public static readonly CatalogField K4551 = new CatalogField(Catalog.DRAWING, KKey.Of("K4551"), KKeyMetadata.of("ZNSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4552 = new CatalogField(Catalog.DRAWING, KKey.Of("K4552"), KKeyMetadata.of("ZNBEMERK", typeof(string), 200));
        public static readonly CatalogField K4110 = new CatalogField(Catalog.PRODUCT, KKey.Of("K4110_ID"), KKeyMetadata.of("EZERZEUGNIS", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4112 = new CatalogField(Catalog.PRODUCT, KKey.Of("K4112"), KKeyMetadata.of("EZNUMMER", typeof(string), 20));
        public static readonly CatalogField K4113 = new CatalogField(Catalog.PRODUCT, KKey.Of("K4113"), KKeyMetadata.of("EZBEZ", typeof(string), 80));

        public static readonly CatalogField K4114 =
            new CatalogField(Catalog.PRODUCT, KKey.Of("K4114"), KKeyMetadata.of("EZKUNDE", typeof(int))); // vazba na CUSTOME;

        public static readonly CatalogField K4611 = new CatalogField(Catalog.PRODUCT, KKey.Of("K4611"), KKeyMetadata.of("EZSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4612 = new CatalogField(Catalog.PRODUCT, KKey.Of("K4612"), KKeyMetadata.of("EZBEMERK", typeof(string), 200));

        public static readonly CatalogField K4030 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.Of("K4030_ID"), KKeyMetadata.of("PAAUFTRAG", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4032 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.Of("K4032"), KKeyMetadata.of("PAAUFTRAGNR", typeof(string), 40));
        public static readonly CatalogField K4033 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.Of("K4033"), KKeyMetadata.of("PABEZEICH", typeof(string), 100));
        public static readonly CatalogField K4531 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.Of("K4531"), KKeyMetadata.of("PASTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4532 = new CatalogField(Catalog.PURCHASE_ORDER, KKey.Of("K4532"), KKeyMetadata.of("PABEMERK", typeof(string), 200));

        public static readonly CatalogField K4230 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4230_ID"), KKeyMetadata.of("OKKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4232 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4232"), KKeyMetadata.of("OKNR", typeof(string), 40));
        public static readonly CatalogField K4233 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4233"), KKeyMetadata.of("OKBEZ", typeof(string), 100));
        public static readonly CatalogField K4234 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4234"), KKeyMetadata.of("OKKURZBEZ", typeof(string), 20));
        public static readonly CatalogField K4235 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4235"), KKeyMetadata.of("OKBEWERT", typeof(int)));
        public static readonly CatalogField K4236 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4236"), KKeyMetadata.of("OKSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4731 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4731"), KKeyMetadata.of("OKRANG", typeof(int)));
        public static readonly CatalogField K4732 = new CatalogField(Catalog.ORDINAL_CLASS, KKey.Of("K4732"), KKeyMetadata.of("OKBEMERK", typeof(string), 200));

        public static readonly CatalogField K4100 = new CatalogField(Catalog.CONTRACTOR, KKey.Of("K4100_ID"), KKeyMetadata.of("AULFDNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4102 = new CatalogField(Catalog.CONTRACTOR, KKey.Of("K4102"), KKeyMetadata.of("AUNR", typeof(string), 50));
        public static readonly CatalogField K4103 = new CatalogField(Catalog.CONTRACTOR, KKey.Of("K4103"), KKeyMetadata.of("AUNAME1", typeof(string), 100));
        public static readonly CatalogField K4601 = new CatalogField(Catalog.CONTRACTOR, KKey.Of("K4601"), KKeyMetadata.of("AUGSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4602 = new CatalogField(Catalog.CONTRACTOR, KKey.Of("K4602"), KKeyMetadata.of("AUMEMO", typeof(string)));

        public static readonly CatalogField K4070 = new CatalogField(Catalog.GAGE, KKey.Of("K4070"), KKeyMetadata.of("PMPRUEFMIT", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4072 = new CatalogField(Catalog.GAGE, KKey.Of("K4072"), KKeyMetadata.of("PMNR", typeof(string), 40));
        public static readonly CatalogField K4073 = new CatalogField(Catalog.GAGE, KKey.Of("K4073"), KKeyMetadata.of("PMBEZ", typeof(string), 80));
        public static readonly CatalogField K4074 = new CatalogField(Catalog.GAGE, KKey.Of("K4074"), KKeyMetadata.of("PMGRUPPE", typeof(int))); // vazba;
        public static readonly CatalogField K4075 = new CatalogField(Catalog.GAGE, KKey.Of("K4075"), KKeyMetadata.of("PMLETZTDAT", typeof(DateTime)));
        public static readonly CatalogField K4076 = new CatalogField(Catalog.GAGE, KKey.Of("K4076"), KKeyMetadata.of("PMNAECHDAT", typeof(DateTime)));
        public static readonly CatalogField K4077 = new CatalogField(Catalog.GAGE, KKey.Of("K4077"), KKeyMetadata.of("PMIPADDR", typeof(string), 30));
        public static readonly CatalogField K4078 = new CatalogField(Catalog.GAGE, KKey.Of("K4078"), KKeyMetadata.of("PMEINSORT", typeof(string), 50));
        public static readonly CatalogField K4079 = new CatalogField(Catalog.GAGE, KKey.Of("K4079"), KKeyMetadata.of("PMCOMP", typeof(string), 50));
        public static readonly CatalogField K4571 = new CatalogField(Catalog.GAGE, KKey.Of("K4571"), KKeyMetadata.of("PMSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4572 = new CatalogField(Catalog.GAGE, KKey.Of("K4572"), KKeyMetadata.of("PM_BESCH", typeof(string), 200));
        public static readonly CatalogField K4575 = new CatalogField(Catalog.GAGE, KKey.Of("K4575"), KKeyMetadata.of("PMQVERS", typeof(string), 30));
        public static readonly CatalogField K4576 = new CatalogField(Catalog.GAGE, KKey.Of("K4576"), KKeyMetadata.of("PMSOFTW", typeof(string), 50));

        public static readonly CatalogField K4240 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4240_ID"), KKeyMetadata.of("PPNR", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4242 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4242"), KKeyMetadata.of("PPNRTEXT", typeof(string), 40));
        public static readonly CatalogField K4244 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4244"), KKeyMetadata.of("PPKURZTEXT", typeof(string), 20));
        public static readonly CatalogField K4243 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4243"), KKeyMetadata.of("PPLANGTEXT", typeof(string), 100));
        public static readonly CatalogField K4741 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4741"), KKeyMetadata.of("PPSTATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4742 = new CatalogField(Catalog.PROCESS_PARAMETER, KKey.Of("K4742"), KKeyMetadata.of("PPBEMERK", typeof(string), 200));

        public static readonly CatalogField K4270 = new CatalogField(Catalog.K0061, KKey.Of("K4270_ID"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4272 = new CatalogField(Catalog.K0061, KKey.Of("K4272"), KKeyMetadata.of("NR", typeof(string), 20));
        public static readonly CatalogField K4273 = new CatalogField(Catalog.K0061, KKey.Of("K4273"), KKeyMetadata.of("BEZ", typeof(string), 100));
        public static readonly CatalogField K4771 = new CatalogField(Catalog.K0061, KKey.Of("K4771"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4772 = new CatalogField(Catalog.K0061, KKey.Of("K4772"), KKeyMetadata.of("BEMERK", typeof(string), 200));

        public static readonly CatalogField K4280 = new CatalogField(Catalog.K0062, KKey.Of("K4280_ID"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4282 = new CatalogField(Catalog.K0062, KKey.Of("K4282"), KKeyMetadata.of("NR", typeof(string), 20));
        public static readonly CatalogField K4283 = new CatalogField(Catalog.K0062, KKey.Of("K4283"), KKeyMetadata.of("BEZ", typeof(string), 100));
        public static readonly CatalogField K4781 = new CatalogField(Catalog.K0062, KKey.Of("K4781"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4782 = new CatalogField(Catalog.K0062, KKey.Of("K4782"), KKeyMetadata.of("BEMERK", typeof(string), 200));
        public static readonly CatalogField K4290 = new CatalogField(Catalog.K0063, KKey.Of("K4290"), KKeyMetadata.of("KATKEY", typeof(int)), CatalogFieldType.ID);
        public static readonly CatalogField K4292 = new CatalogField(Catalog.K0063, KKey.Of("K4292"), KKeyMetadata.of("NR", typeof(string), 20));
        public static readonly CatalogField K4293 = new CatalogField(Catalog.K0063, KKey.Of("K4293"), KKeyMetadata.of("BEZ", typeof(string), 100));
        public static readonly CatalogField K4791 = new CatalogField(Catalog.K0063, KKey.Of("K4791"), KKeyMetadata.of("STATE", typeof(int)), CatalogFieldType.STATE);
        public static readonly CatalogField K4792 = new CatalogField(Catalog.K0063, KKey.Of("K4792"), KKeyMetadata.of("BEMERK", typeof(string), 200));

        static readonly IDictionary<KKey,CatalogField> FIELDS_BY_KEY = new ConcurrentDictionary<KKey, CatalogField>();

        private CatalogField(Catalog catalog, KKey kKey, KKeyMetadata metadata, CatalogFieldType fieldType = CatalogFieldType.DATA) {
            this.Catalog = catalog;
            this.KKey = kKey;
            this.Metadata = metadata;
            this.Type = fieldType;
            FIELDS_BY_KEY.Add(kKey,this);
        }

        public CatalogFieldType Type { get;  }

        public KKeyMetadata Metadata { get;  }

        public KKey KKey { get; set; }

        public Catalog Catalog { get;  }


        /// <summary>
        /// @return whether this field contains data of catalog entry (is not an identifier of active/non-active state field)
        /// </summary>
        /// <value></value>
        public bool isDataField {
            get { return Type == CatalogFieldType.DATA; }
        }

        /// <summary>
        /// @return whether this field is identifier (surrogate key) of the given catalog
        /// </summary>
        /// <value></value>
        public bool isIdField {
            get { return Type == CatalogFieldType.ID; }
        }

        public static IEnumerable<Catalog> catalogsWithDefinedFields() {
            //return new HashSet<>(FIELDS_BY_CATALOG.keySet());
            return FIELDS_BY_KEY.Values.Select(f => f.Catalog).Distinct();
        }

        /**
         * @param catalog
         * @return
         * @throws IllegalArgumentException if there are no {@link CatalogField fields} defined for the given catalog
         */
        public static IEnumerable<CatalogField> fieldsOfCatalog(Catalog catalog) {
            return FIELDS_BY_KEY.Values.Where(f => f.Catalog == catalog);
        }

        /**
         * Gets the {@link CatalogField field} which is identifier (surrogate key) of the given catalog.
         *
         * @param catalog
         * @return
         */
        public static CatalogField idFieldOfCatalog(Catalog catalog) {
            return FIELDS_BY_KEY.Values
                .FirstOrDefault(f => f.Catalog == catalog && f.Type == CatalogFieldType.ID);
        }

        public static IEnumerable<KKey> getKKeysOfCatalog(Catalog catalog) {
            return getKKeysOfCatalog(catalog, e=> true);
        }

        public static IEnumerable<KKey> getKKeysOfCatalog(Catalog catalog, Predicate<CatalogField> predicate) {
            return fieldsOfCatalog(catalog).Where(f=>predicate(f)).OrderBy(f=>f.KKey).Select(f=>f.KKey);
        }

        public static CatalogField forKKey(KKey kKey) {
            CatalogField result = null;
            FIELDS_BY_KEY.TryGetValue(kKey,out result) ;
            return result;
        }

        public static KKeyMetadata getMetadataFor(KKey kKey) {
            CatalogField field = forKKey(kKey);
            return field?.Metadata;
        }
    }
}