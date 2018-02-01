using System;
using System.Collections.Generic;
using System.Linq;

#if NETCORE
    using System.Collections.Immutable;
#endif

namespace AQDEF.Sharp
{
    public class KKeyRepository
    {

        public class DefaultKKeyProvider
        {

            public IDictionary<string, KKeyMetadata> CreateKKeysWithMetadata()
            {
                var keys = new Dictionary<string, KKeyMetadata>();
                //Buildrepository(keys);
                return getSource().GroupBy(m=>m.KeyCode).ToDictionary(g=>g.Key,g=>g.First());
                //return keys;
            }

            private IEnumerable<KKeyMetadata> getSource()
            {
                //测量值
                yield return new KKeyMetadata("K0001", KKeyFieldType.F, 22, "measured value");
                //定性
                yield return new KKeyMetadata("K0002", KKeyFieldType.I5, 5, "attribute");
                //时间
                yield return new KKeyMetadata("K0004", KKeyFieldType.D, 0, "Time");
                //事件
                yield return new KKeyMetadata("K0005", KKeyFieldType.S, 0, "Event");
                //批次编码
                yield return new KKeyMetadata("K0006", KKeyFieldType.A, 14, "Batch number");
                //巢穴编号
                yield return new KKeyMetadata("K0007", KKeyFieldType.I10, 10, "Cavity number");
                //检验员姓名
                yield return new KKeyMetadata("K0008", KKeyFieldType.I10, 10, "Operator name");
                //文字
                yield return new KKeyMetadata("K0009", KKeyFieldType.A, 255, "Text");
                //机器编号
                yield return new KKeyMetadata("K0010", KKeyFieldType.I10, 10, "Machine number");
                //过程参数
                yield return new KKeyMetadata("K0011", KKeyFieldType.S, 0, "Process parameter");
                //检测工具编号
                yield return new KKeyMetadata("K0012", KKeyFieldType.I10, 10, "Gage number");
                //零件 ID
                yield return new KKeyMetadata("K0014", KKeyFieldType.A, 40, "Part ID number");
                //检验的依据
                yield return new KKeyMetadata("K0015", KKeyFieldType.I5, 5, "Reason for test");
                //子组容量
                yield return new KKeyMetadata("K0020", KKeyFieldType.I5, 5, "Subgroup size");
                //缺陷数目
                yield return new KKeyMetadata("K0021", KKeyFieldType.I5, 5, "No. of errors");
                //定单
                yield return new KKeyMetadata("K0053", KKeyFieldType.A, 20, "Order");
                //文件中的参数总数
                yield return new KKeyMetadata("K0100", KKeyFieldType.I5, 5, "Total no. of characteristics in file");
                //零件号
                yield return new KKeyMetadata("K1001", KKeyFieldType.A, 30, "Part number");
                //零件名
                yield return new KKeyMetadata("K1002", KKeyFieldType.A, 80, "Part description");
                //零件简称
                yield return new KKeyMetadata("K1003", KKeyFieldType.A, 20, "Part abbreviation");
                //零件更改状态
                yield return new KKeyMetadata("K1004", KKeyFieldType.A, 20, "Part Amendment status");
                //产品
                yield return new KKeyMetadata("K1005", KKeyFieldType.A, 40, "Product");
                //零件编号简称
                yield return new KKeyMetadata("K1007", KKeyFieldType.A, 20, "Abbreviation Part no.");
                //零件类型
                yield return new KKeyMetadata("K1008", KKeyFieldType.A, 20, "Part type");
                //零件代码
                yield return new KKeyMetadata("K1009", KKeyFieldType.A, 20, "Part code");
                //受控文件
                yield return new KKeyMetadata("K1010", KKeyFieldType.I3, 3, "Control item");
                //变型
                yield return new KKeyMetadata("K1011", KKeyFieldType.A, 20, "Variant");
                //识别号 附件
                yield return new KKeyMetadata("K1012", KKeyFieldType.A, 20, "ID number annex");
                //识别号 索引
                yield return new KKeyMetadata("K1013", KKeyFieldType.A, 20, "ID number index");
                //零件识别
                yield return new KKeyMetadata("K1014", KKeyFieldType.A, 20, "Parts ID");
                //制造商目录
                yield return new KKeyMetadata("K1020", KKeyFieldType.I5, 5, "Manufacturer Catalog");
                //制造商编号
                yield return new KKeyMetadata("K1021", KKeyFieldType.A, 20, "Manufacturer No.");
                //制造商名称
                yield return new KKeyMetadata("K1022", KKeyFieldType.A, 80, "Manufacturer name");
                //制造商名称
                yield return new KKeyMetadata("K1023", KKeyFieldType.I10, 10, "Manufacturer number");
                //材料目录
                yield return new KKeyMetadata("K1030", KKeyFieldType.I5, 5, "Materials Catalog");
                //材料编号
                yield return new KKeyMetadata("K1031", KKeyFieldType.A, 20, "Material number");
                //材料名称
                yield return new KKeyMetadata("K1032", KKeyFieldType.A, 40, "Material Description");
                //材料编号
                yield return new KKeyMetadata("K1033", KKeyFieldType.I10, 10, "Material number");
                //图纸目录
                yield return new KKeyMetadata("K1040", KKeyFieldType.I5, 5, "Drawing Catalog");
                //图纸编号
                yield return new KKeyMetadata("K1041", KKeyFieldType.A, 30, "Drawing number");
                //图纸更改
                yield return new KKeyMetadata("K1042", KKeyFieldType.A, 20, "Drawing Amendment");
                //图纸索引
                yield return new KKeyMetadata("K1043", KKeyFieldType.A, 40, "Drawing Index");
                //图纸编号
                yield return new KKeyMetadata("K1044", KKeyFieldType.I10, 10, "Drawing Number");
                //委托方-目录
                yield return new KKeyMetadata("K1050", KKeyFieldType.I5, 5, "Contractor Catalog");
                //委托方-编号
                yield return new KKeyMetadata("K1051", KKeyFieldType.A, 20, "Contractor Number");
                //委托方名称
                yield return new KKeyMetadata("K1052", KKeyFieldType.A, 40, "Contractor Name");
                //合同
                yield return new KKeyMetadata("K1053", KKeyFieldType.A, 40, "Contract");
                //委托方-编号
                yield return new KKeyMetadata("K1054", KKeyFieldType.I10, 10, "Contractor Number");
                //用户目录
                yield return new KKeyMetadata("K1060", KKeyFieldType.I5, 5, "Customer Catalog");
                //用户编号
                yield return new KKeyMetadata("K1061", KKeyFieldType.A, 20, "Customer Number");
                //用户名称
                yield return new KKeyMetadata("K1062", KKeyFieldType.A, 40, "Customer Name");
                //用户编号
                yield return new KKeyMetadata("K1063", KKeyFieldType.I10, 10, "Customer Number");
                //供应商目录
                yield return new KKeyMetadata("K1070", KKeyFieldType.I5, 5, "Supplier Catalog");
                //供应商编号
                yield return new KKeyMetadata("K1071", KKeyFieldType.A, 20, "Supplier Number");
                //供应商名称
                yield return new KKeyMetadata("K1072", KKeyFieldType.A, 40, "Supplier Name");
                //供应商编号
                yield return new KKeyMetadata("K1073", KKeyFieldType.I10, 10, "Supplier Number");
                //机器目录
                yield return new KKeyMetadata("K1080", KKeyFieldType.I5, 5, "Machine Catalog");
                //机器编号
                yield return new KKeyMetadata("K1081", KKeyFieldType.A, 24, "Machine Number");
                //机器名称
                yield return new KKeyMetadata("K1082", KKeyFieldType.A, 40, "Machine Description");
                //机器编号
                yield return new KKeyMetadata("K1083", KKeyFieldType.I5, 5, "Machine Number");
                //机器位置
                yield return new KKeyMetadata("K1085", KKeyFieldType.A, 40, "Machine Location");
                //道序
                yield return new KKeyMetadata("K1086", KKeyFieldType.A, 40, "Work Cycle / Operation no.");
                //工厂范围
                yield return new KKeyMetadata("K1100", KKeyFieldType.A, 40, "Plant Sector");
                //部门
                yield return new KKeyMetadata("K1101", KKeyFieldType.A, 40, "Department");
                //车间/范围
                yield return new KKeyMetadata("K1102", KKeyFieldType.A, 40, "Workshop/sector");
                //成本核算点
                yield return new KKeyMetadata("K1103", KKeyFieldType.A, 40, "Cost centre");
                //班次
                yield return new KKeyMetadata("K1104", KKeyFieldType.A, 20, "Shift");
                //订货号
                yield return new KKeyMetadata("K1110", KKeyFieldType.A, 20, "Order number");
                //进货编号
                yield return new KKeyMetadata("K1111", KKeyFieldType.A, 20, "Goods received number");
                //Cube
                yield return new KKeyMetadata("K1112", KKeyFieldType.A, 20, "Cube");
                //位置
                yield return new KKeyMetadata("K1113", KKeyFieldType.A, 20, "Location");
                //设备
                yield return new KKeyMetadata("K1114", KKeyFieldType.A, 40, "Device");
                //生产日期
                yield return new KKeyMetadata("K1115", KKeyFieldType.A, 40, "Production date");
                //检验设备编号
                yield return new KKeyMetadata("K1201", KKeyFieldType.A, 24, "Test Facility Number");
                //检验设备名称
                yield return new KKeyMetadata("K1202", KKeyFieldType.A, 40, "Test Facility Description");
                //检验原因
                yield return new KKeyMetadata("K1203", KKeyFieldType.A, 80, "Reason for Test");
                //检验开始
                yield return new KKeyMetadata("K1204", KKeyFieldType.D, 20, "Test Begin");
                //检验结束
                yield return new KKeyMetadata("K1205", KKeyFieldType.D, 20, "Test End");
                //检验台
                yield return new KKeyMetadata("K1206", KKeyFieldType.A, 40, "Test Location");
                //检验计划编制者
                yield return new KKeyMetadata("K1207", KKeyFieldType.A, 40, "Test Plan Developer");
                //检验设备编号
                yield return new KKeyMetadata("K1208", KKeyFieldType.I10, 10, "Test Facility No.");
                //检验方法
                yield return new KKeyMetadata("K1209", KKeyFieldType.A, 20, "Inspection type");
                //测量类型
                yield return new KKeyMetadata("K1210", KKeyFieldType.I10, 10, "measurement type");
                //样件编号
                yield return new KKeyMetadata("K1211", KKeyFieldType.A, 40, "Standard Number");
                //样件名称
                yield return new KKeyMetadata("K1212", KKeyFieldType.A, 40, "Standard description");
                //样件编号
                yield return new KKeyMetadata("K1215", KKeyFieldType.I10, 10, "Standard number");
                //检验员编号
                yield return new KKeyMetadata("K1221", KKeyFieldType.A, 20, "Inspector number");
                //检验员名称
                yield return new KKeyMetadata("K1222", KKeyFieldType.A, 40, "Inspector name");
                //检验员编号
                yield return new KKeyMetadata("K1223", KKeyFieldType.I10, 10, "Inspector number");
                //测量室
                yield return new KKeyMetadata("K1230", KKeyFieldType.A, 40, "Gage room");
                //测量程序编号
                yield return new KKeyMetadata("K1231", KKeyFieldType.A, 20, "Measuring program number");
                //测量程序版本
                yield return new KKeyMetadata("K1232", KKeyFieldType.A, 20, "Measuring program version");
                //工厂
                yield return new KKeyMetadata("K1303", KKeyFieldType.A, 40, "Plant");
                //说明
                yield return new KKeyMetadata("K1900", KKeyFieldType.A, 255, "Remark");
                //被检参数编号
                yield return new KKeyMetadata("K2001", KKeyFieldType.A, 20, "Characteristic Number");
                //被检参数名称
                yield return new KKeyMetadata("K2002", KKeyFieldType.A, 80, "Characteristic Description");
                //被测参数简称
                yield return new KKeyMetadata("K2003", KKeyFieldType.A, 20, "Characteristic Abbreviation");
                //被测参数类型
                yield return new KKeyMetadata("K2004", KKeyFieldType.I5, 5, "Characteristic Type");
                //被测参数级别
                yield return new KKeyMetadata("K2005", KKeyFieldType.I5, 5, "Characteristics Class");
                //受控文件
                yield return new KKeyMetadata("K2006", KKeyFieldType.I5, 5, "Control Item");
                //控制方式
                yield return new KKeyMetadata("K2007", KKeyFieldType.I5, 5, "Control Type");
                //分布
                yield return new KKeyMetadata("K2011", KKeyFieldType.I5, 5, "Distribution");
                //自然级宽
                yield return new KKeyMetadata("K2013", KKeyFieldType.F, 22, "natural class width");
                //逻辑运算公式
                yield return new KKeyMetadata("K2021", KKeyFieldType.A, 255, "Logical Operation Formula");
                //小数点位数
                yield return new KKeyMetadata("K2022", KKeyFieldType.I5, 5, "Decimal Places");
                //转换方式
                yield return new KKeyMetadata("K2023", KKeyFieldType.I3, 3, "Transformation Type");
                //转换参数 a
                yield return new KKeyMetadata("K2024", KKeyFieldType.F, 22, "Transformation Parameter a");
                //转换参数 b
                yield return new KKeyMetadata("K2025", KKeyFieldType.F, 22, "Transformation Parameter b");
                //转换参数 c
                yield return new KKeyMetadata("K2026", KKeyFieldType.F, 22, "Transformation Parameter c");
                //转换参数 d
                yield return new KKeyMetadata("K2027", KKeyFieldType.F, 22, "Transformation Parameter d");
                //组编号
                yield return new KKeyMetadata("K2030", KKeyFieldType.I5, 5, "Group Number");
                //组元素编号
                yield return new KKeyMetadata("K2031", KKeyFieldType.I5, 5, "Group Element Number");
                //采录方式
                yield return new KKeyMetadata("K2041", KKeyFieldType.I3, 3, "Recording Type");
                //采录设备编号
                yield return new KKeyMetadata("K2042", KKeyFieldType.I5, 5, "Recording Device Number");
                //采录设备名称
                yield return new KKeyMetadata("K2043", KKeyFieldType.A, 40, "Recording Device Name");
                //采录设备索引
                yield return new KKeyMetadata("K2044", KKeyFieldType.I5, 5, "Recording Device Index");
                //采录通道
                yield return new KKeyMetadata("K2045", KKeyFieldType.I3, 3, "Recording Channel");
                //采录亚通道
                yield return new KKeyMetadata("K2046", KKeyFieldType.I3, 3, "Recording Subchannel");
                //软件要求索引
                yield return new KKeyMetadata("K2047", KKeyFieldType.I3, 3, "Software Requirement Index");
                //录取通道
                yield return new KKeyMetadata("K2048", KKeyFieldType.I3, 3, "Takeover channel");
                //通道初始化
                yield return new KKeyMetadata("K2049", KKeyFieldType.I3, 3, "Channel initialization");
                //界面
                yield return new KKeyMetadata("K2051", KKeyFieldType.I3, 3, "Interface");
                //波特率
                yield return new KKeyMetadata("K2052", KKeyFieldType.I5, 5, "Baud Rate");
                //奇偶性
                yield return new KKeyMetadata("K2054", KKeyFieldType.I3, 3, "Parity");
                //Datenbits
                yield return new KKeyMetadata("K2055", KKeyFieldType.I3, 3, "Data bits");
                //Stopbits
                yield return new KKeyMetadata("K2056", KKeyFieldType.I3, 3, "Stop bits");
                //事件目录
                yield return new KKeyMetadata("K2060", KKeyFieldType.I5, 5, "Events Catalog");
                //过程参数目录
                yield return new KKeyMetadata("K2061", KKeyFieldType.I5, 5, "Process Parameter Catalog");
                //巢穴目录
                yield return new KKeyMetadata("K2062", KKeyFieldType.I5, 5, "Cavity catalog");
                //机器目录
                yield return new KKeyMetadata("K2063", KKeyFieldType.I5, 5, "Machine catalog");
                //量具目录
                yield return new KKeyMetadata("K2064", KKeyFieldType.I5, 5, "Gage catalog");
                //操作员目录
                yield return new KKeyMetadata("K2065", KKeyFieldType.I5, 5, "Operator catalog");
                //附加常数
                yield return new KKeyMetadata("K2071", KKeyFieldType.F, 22, "Accumulating Constant");
                //乘数因子
                yield return new KKeyMetadata("K2072", KKeyFieldType.F, 22, "Multiplication factor");
                //被测参数状态(选定, 去选, …)
                yield return new KKeyMetadata("K2080", KKeyFieldType.I5, 5, "Characteristics status (selected, unselected, ...)");
                //被测参数索引
                yield return new KKeyMetadata("K2091", KKeyFieldType.A, 20, "Characteristic index");
                //被检参数说明
                yield return new KKeyMetadata("K2092", KKeyFieldType.A, 50, "Characteristic text");
                //加工状态
                yield return new KKeyMetadata("K2093", KKeyFieldType.A, 80, "Processing status");
                //组件代码
                yield return new KKeyMetadata("K2095", KKeyFieldType.A, 40, "Element code");
                //组件索引
                yield return new KKeyMetadata("K2096", KKeyFieldType.A, 20, "Element index");
                //组件说明
                yield return new KKeyMetadata("K2097", KKeyFieldType.A, 50, "Element text");
                //组件地址
                yield return new KKeyMetadata("K2098", KKeyFieldType.A, 20, "Element address");
                //名义-/目标值
                yield return new KKeyMetadata("K2100", KKeyFieldType.F, 22, "Target value");
                //名义值
                yield return new KKeyMetadata("K2101", KKeyFieldType.F, 22, "Nominal value");
                //Pmax
                yield return new KKeyMetadata("K2102", KKeyFieldType.F, 22, "Pmax");
                //审查时零件时合格
                yield return new KKeyMetadata("K2105", KKeyFieldType.I5, 5, "Parts OK at Censoring");
                //下限
                yield return new KKeyMetadata("K2110", KKeyFieldType.F, 22, "Lower Specification Limit");
                //上限
                yield return new KKeyMetadata("K2111", KKeyFieldType.F, 22, "Upper Specification Limit");
                //下公差
                yield return new KKeyMetadata("K2112", KKeyFieldType.F, 22, "Lower Allowance");
                //上公差
                yield return new KKeyMetadata("K2113", KKeyFieldType.F, 22, "Upper Allowance");
                //下报废界限
                yield return new KKeyMetadata("K2114", KKeyFieldType.F, 22, "Lower Scrap Limit");
                //上报废界限
                yield return new KKeyMetadata("K2115", KKeyFieldType.F, 22, "Upper Scrap Limit");
                //界限
                yield return new KKeyMetadata("K2120", KKeyFieldType.I3, 3, "Boundary");
                //界限
                yield return new KKeyMetadata("K2121", KKeyFieldType.I3, 3, "Boundary");
                //下置信界限
                yield return new KKeyMetadata("K2130", KKeyFieldType.F, 22, "Lower Plausibility Limit");
                //上置信界限
                yield return new KKeyMetadata("K2131", KKeyFieldType.F, 22, "Upper Plausibility Limit");
                //单位
                yield return new KKeyMetadata("K2141", KKeyFieldType.I5, 5, "Unit");
                //单位
                yield return new KKeyMetadata("K2142", KKeyFieldType.A, 20, "Unit");
                //相对单位
                yield return new KKeyMetadata("K2143", KKeyFieldType.A, 20, "Unit relative");
                //附加常数 相对的
                yield return new KKeyMetadata("K2144", KKeyFieldType.F, 22, "Adding constant relative");
                //相对乘数因子
                yield return new KKeyMetadata("K2145", KKeyFieldType.F, 22, "Multiplication factor relative");
                //公差
                yield return new KKeyMetadata("K2151", KKeyFieldType.A, 40, "Tolerance");
                //计算的公差
                yield return new KKeyMetadata("K2152", KKeyFieldType.F, 22, "Calculated Tolerance");
                //分批大小
                yield return new KKeyMetadata("K2160", KKeyFieldType.I10, 10, "Batch size");
                //返工成本
                yield return new KKeyMetadata("K2161", KKeyFieldType.F, 22, "Re-work Cost");
                //报废成本
                yield return new KKeyMetadata("K2162", KKeyFieldType.F, 22, "Rejects Cost");
                //缺陷成本
                yield return new KKeyMetadata("K2163", KKeyFieldType.F, 22, "Error Cost");
                //审查时间点
                yield return new KKeyMetadata("K2170", KKeyFieldType.F, 22, "Censoring Time");
                //推断
                yield return new KKeyMetadata("K2171", KKeyFieldType.F, 22, "Extrapolation");
                //过程离散
                yield return new KKeyMetadata("K2201", KKeyFieldType.F, 22, "Process Variation");
                //评定方法
                yield return new KKeyMetadata("K2202", KKeyFieldType.I3, 3, "Evaluation Type");
                //零件数目
                yield return new KKeyMetadata("K2205", KKeyFieldType.I5, 5, "Number of Parts");
                //样件目录
                yield return new KKeyMetadata("K2210", KKeyFieldType.I5, 5, "Master Catalog");
                //样件编号
                yield return new KKeyMetadata("K2211", KKeyFieldType.A, 40, "Master Number");
                //标准件名称
                yield return new KKeyMetadata("K2212", KKeyFieldType.A, 40, "Master Description");
                //样件实际值
                yield return new KKeyMetadata("K2213", KKeyFieldType.F, 22, "Standard actual value");
                //样件温度
                yield return new KKeyMetadata("K2214", KKeyFieldType.F, 22, "Master Temperature");
                //样件编号
                yield return new KKeyMetadata("K2215", KKeyFieldType.I5, 5, "Master Number");
                //样件系列号
                yield return new KKeyMetadata("K2216", KKeyFieldType.A, 20, "Master Serial Number");
                //检验员数量
                yield return new KKeyMetadata("K2220", KKeyFieldType.I5, 5, "Number of operators");
                //测量次数
                yield return new KKeyMetadata("K2221", KKeyFieldType.I5, 5, "No. of Trials");
                //标准件测量次数
                yield return new KKeyMetadata("K2222", KKeyFieldType.I5, 5, "Number of reference measurements");
                //Cg-值
                yield return new KKeyMetadata("K2225", KKeyFieldType.F, 22, "Cg value");
                //Cgk-值
                yield return new KKeyMetadata("K2226", KKeyFieldType.F, 22, "Cgk value");
                //偏离方法1
                yield return new KKeyMetadata("K2227", KKeyFieldType.F, 22, "Deviation from Type 1");
                //Sg
                yield return new KKeyMetadata("K2228", KKeyFieldType.F, 22, "Sg");
                //图纸文件名
                yield return new KKeyMetadata("K2243", KKeyFieldType.A, 80, "Drawing file name");
                //图纸基准点 X
                yield return new KKeyMetadata("K2244", KKeyFieldType.I5, 5, "drawing reference point X");
                //图纸基准点 Y
                yield return new KKeyMetadata("K2245", KKeyFieldType.I5, 5, "drawing reference point Y");
                //机器编号
                yield return new KKeyMetadata("K2301", KKeyFieldType.A, 20, "Machine number");
                //机器名称
                yield return new KKeyMetadata("K2302", KKeyFieldType.A, 40, "Machine Description");
                //部门/成本位置
                yield return new KKeyMetadata("K2303", KKeyFieldType.A, 40, "Department/Cost center");
                //机器位置
                yield return new KKeyMetadata("K2304", KKeyFieldType.A, 40, "Machine Location");
                //机器编号
                yield return new KKeyMetadata("K2305", KKeyFieldType.I5, 5, "Machine Number");
                //区域 工厂/车间
                yield return new KKeyMetadata("K2306", KKeyFieldType.A, 40, "Plant/Hall Sector");
                //PTM 编号
                yield return new KKeyMetadata("K2307", KKeyFieldType.A, 40, "PTM Number");
                //产品类型
                yield return new KKeyMetadata("K2311", KKeyFieldType.A, 20, "Production Type");
                //产品类型名称
                yield return new KKeyMetadata("K2312", KKeyFieldType.A, 40, "Production Type Description");
                //产品类型编号
                yield return new KKeyMetadata("K2313", KKeyFieldType.I5, 5, "Production Type Number");
                //合同编号
                yield return new KKeyMetadata("K2320", KKeyFieldType.A, 20, "Contract Number");
                //委托方-编号
                yield return new KKeyMetadata("K2321", KKeyFieldType.A, 20, "Contractor Number");
                //委托方姓名
                yield return new KKeyMetadata("K2322", KKeyFieldType.A, 40, "Contractor Name");
                //委托方-编号
                yield return new KKeyMetadata("K2323", KKeyFieldType.I5, 5, "Contractor Number");
                //工件编号
                yield return new KKeyMetadata("K2331", KKeyFieldType.A, 20, "Work piece Number");
                //工件名称
                yield return new KKeyMetadata("K2332", KKeyFieldType.A, 40, "Work piece Description");
                //工件编号
                yield return new KKeyMetadata("K2333", KKeyFieldType.I5, 5, "Work piece Number");
                //检验计划编号
                yield return new KKeyMetadata("K2341", KKeyFieldType.A, 20, "Test Plan Number");
                //检验计划名称
                yield return new KKeyMetadata("K2342", KKeyFieldType.A, 40, "Test Plan Name");
                //检验计划编制日期
                yield return new KKeyMetadata("K2343", KKeyFieldType.D, 20, "Test Plan Development Date");
                //检验计划编制者
                yield return new KKeyMetadata("K2344", KKeyFieldType.A, 40, "Test Plan Developer");
                //检具编号
                yield return new KKeyMetadata("K2401", KKeyFieldType.A, 40, "Gage Number");
                //检具名称
                yield return new KKeyMetadata("K2402", KKeyFieldType.A, 40, "Gage Description");
                //检具组
                yield return new KKeyMetadata("K2403", KKeyFieldType.A, 20, "Gage Group");
                //检具精度
                yield return new KKeyMetadata("K2404", KKeyFieldType.F, 22, "Gage Resolution");
                //检具编号
                yield return new KKeyMetadata("K2405", KKeyFieldType.I5, 5, "Gage Number");
                //检具制造商
                yield return new KKeyMetadata("K2406", KKeyFieldType.A, 40, "Gage Manufacturer");
                //SPC-设备编号
                yield return new KKeyMetadata("K2407", KKeyFieldType.A, 20, "SPC device number");
                //SPC-设备制造商
                yield return new KKeyMetadata("K2408", KKeyFieldType.A, 40, "SPC device manufacturer");
                //SPC-设备-型号
                yield return new KKeyMetadata("K2409", KKeyFieldType.A, 20, "SPC device type");
                //检验地点
                yield return new KKeyMetadata("K2410", KKeyFieldType.A, 40, "Test Location");
                //检验开始
                yield return new KKeyMetadata("K2411", KKeyFieldType.D, 40, "Test Begin");
                //检验结束
                yield return new KKeyMetadata("K2412", KKeyFieldType.D, 40, "Test End");
                //检具系列号
                yield return new KKeyMetadata("K2415", KKeyFieldType.A, 20, "Gage serial number");
                //显示仪
                yield return new KKeyMetadata("K2416", KKeyFieldType.A, 40, "Display");
                //检验员编号
                yield return new KKeyMetadata("K2421", KKeyFieldType.A, 20, "Operator Number");
                //检验员名称
                yield return new KKeyMetadata("K2422", KKeyFieldType.A, 40, "Operator Name");
                //检验员编号
                yield return new KKeyMetadata("K2423", KKeyFieldType.I5, 5, "Operator Number");
                //用户域名称 1
                yield return new KKeyMetadata("K2800", KKeyFieldType.A, 50, "user field description 1");
                //用户域类型 1
                yield return new KKeyMetadata("K2801", KKeyFieldType.A, 1, "user field type 1");
                //用户域内容 1
                yield return new KKeyMetadata("K2802", KKeyFieldType.A, 255, "user field contents 1");
                //用户域名称 2
                yield return new KKeyMetadata("K2810", KKeyFieldType.A, 50, "user field description 2");
                //用户域类型 2
                yield return new KKeyMetadata("K2811", KKeyFieldType.A, 1, "user field type 2");
                //用户域内容 2
                yield return new KKeyMetadata("K2812", KKeyFieldType.A, 255, "user field contents 2");
                //用户域名称 3
                yield return new KKeyMetadata("K2820", KKeyFieldType.A, 50, "user field description 3");
                //用户域类型 3
                yield return new KKeyMetadata("K2821", KKeyFieldType.A, 1, "user field type 3");
                //用户域内容 3
                yield return new KKeyMetadata("K2822", KKeyFieldType.A, 255, "user field contents 3");
                //用户域名称 4
                yield return new KKeyMetadata("K2830", KKeyFieldType.A, 50, "user field description 4");
                //用户域类型 4
                yield return new KKeyMetadata("K2831", KKeyFieldType.A, 1, "user field type 4");
                //用户域内容 4
                yield return new KKeyMetadata("K2832", KKeyFieldType.A, 255, "user field contents 4");
                //用户域名称 5
                yield return new KKeyMetadata("K2840", KKeyFieldType.A, 50, "user field description 5");
                //用户域类型 5
                yield return new KKeyMetadata("K2841", KKeyFieldType.A, 1, "user field type 5");
                //用户域内容 5
                yield return new KKeyMetadata("K2842", KKeyFieldType.A, 255, "user field contents 5");
                //用户域名称 6
                yield return new KKeyMetadata("K2850", KKeyFieldType.A, 50, "user field description 6");
                //用户域类型 6
                yield return new KKeyMetadata("K2851", KKeyFieldType.A, 1, "user field type 6");
                //用户域内容 6
                yield return new KKeyMetadata("K2852", KKeyFieldType.A, 255, "user field contents 6");
                //用户域名称 7
                yield return new KKeyMetadata("K2860", KKeyFieldType.A, 50, "user field description 7");
                //用户域类型 7
                yield return new KKeyMetadata("K2861", KKeyFieldType.A, 1, "user field type 7");
                //用户域内容 7
                yield return new KKeyMetadata("K2862", KKeyFieldType.A, 255, "user field contents 7");
                //用户域名称 8
                yield return new KKeyMetadata("K2870", KKeyFieldType.A, 50, "user field description 8");
                //用户域类型 8
                yield return new KKeyMetadata("K2871", KKeyFieldType.A, 1, "user field type 8");
                //用户域内容 8
                yield return new KKeyMetadata("K2872", KKeyFieldType.A, 255, "user field contents 8");
                //用户域名称 9
                yield return new KKeyMetadata("K2880", KKeyFieldType.A, 50, "user field description 9");
                //用户域类型 9
                yield return new KKeyMetadata("K2881", KKeyFieldType.A, 1, "user field type 9");
                //用户域内容 9
                yield return new KKeyMetadata("K2882", KKeyFieldType.A, 255, "user field contents 9");
                //用户域名称 10
                yield return new KKeyMetadata("K2890", KKeyFieldType.A, 50, "user field description 10");
                //用户域类型 10
                yield return new KKeyMetadata("K2891", KKeyFieldType.A, 1, "user field type 10");
                //用户域内容 10
                yield return new KKeyMetadata("K2892", KKeyFieldType.A, 255, "user field contents 10");
                //说明
                yield return new KKeyMetadata("K2900", KKeyFieldType.A, 255, "Remark");
                //检验条件
                yield return new KKeyMetadata("K2901", KKeyFieldType.A, 80, "Test Conditions");
                //内部的 qs-STAT 设置
                yield return new KKeyMetadata("K2998", KKeyFieldType.A, 255, "internal qs-STAT configuration");
                //下报警界限(位置)
                yield return new KKeyMetadata("K8006", KKeyFieldType.F, 22, "lo. alarm lim. (location)");
                //上报警界限(位置)
                yield return new KKeyMetadata("K8007", KKeyFieldType.F, 22, "up. alarm lim. (location)");
                //控制图类型 (位置)
                yield return new KKeyMetadata("K8010", KKeyFieldType.S, 0, "Chart Type (Loc)");
                //中间位置 (位置)
                yield return new KKeyMetadata("K8011", KKeyFieldType.F, 22, "Central Position (Loc)");
                //下控制界限 (位置)
                yield return new KKeyMetadata("K8012", KKeyFieldType.F, 22, "lower Control Limit (Loc)");
                //上控制界限 (位置)
                yield return new KKeyMetadata("K8013", KKeyFieldType.F, 22, "upper Control Limit (Loc)");
                //下警告界限 (位置)
                yield return new KKeyMetadata("K8014", KKeyFieldType.F, 22, "lower Warning Limit (Loc)");
                //上警告界限 (位置)
                yield return new KKeyMetadata("K8015", KKeyFieldType.F, 22, "upper Warning Limit (Loc)");
                //控制图类型(变动)
                yield return new KKeyMetadata("K8110", KKeyFieldType.S, 0, "Chart Type (Variation)");
                //中间位置(变动)
                yield return new KKeyMetadata("K8111", KKeyFieldType.F, 22, "Central Position (Variation)");
                //下控制界限(变动)
                yield return new KKeyMetadata("K8112", KKeyFieldType.F, 22, "lower Control lim. (Variation)");
                //上控制界限(变动)
                yield return new KKeyMetadata("K8113", KKeyFieldType.F, 22, "upper Control Limit (Variation)");
                //下警告界限(变动)
                yield return new KKeyMetadata("K8114", KKeyFieldType.F, 22, "lower Warning Limit (Variation)");
                //上警告界限(变动)
                yield return new KKeyMetadata("K8115", KKeyFieldType.F, 22, "upper Warning Limit (Variation)");
                //子组容量
                yield return new KKeyMetadata("K8500", KKeyFieldType.I5, 5, "Subgroup size");
                //子组类型
                yield return new KKeyMetadata("K8501", KKeyFieldType.I3, 3, "Subgroup type");
                //抽检频率
                yield return new KKeyMetadata("K8502", KKeyFieldType.A, 40, "Subgroup frequency");
                //恒定的子组容量
                yield return new KKeyMetadata("K8503", KKeyFieldType.I3, 3, "stable subgroup size");
                //抽检频率
                yield return new KKeyMetadata("K8504", KKeyFieldType.I5, 5, "Subgroup incidence");
                //要求的 Cp-值
                yield return new KKeyMetadata("K8520", KKeyFieldType.F, 22, "required Cp value");
                //要求的 Cpk-值
                yield return new KKeyMetadata("K8521", KKeyFieldType.F, 22, "required Cpk value");
                //固定的Cp-值
                yield return new KKeyMetadata("K8522", KKeyFieldType.F, 22, "fixed Cp value");
                //固定的Cpk-值
                yield return new KKeyMetadata("K8523", KKeyFieldType.F, 22, "fixed Cpk value");
                //修正的策略
                yield return new KKeyMetadata("K8600", KKeyFieldType.I3, 3, "Correction Strategy");
                //下修正界限
                yield return new KKeyMetadata("K8610", KKeyFieldType.F, 22, "lower Correction Limit");
                //上修正界限
                yield return new KKeyMetadata("K8611", KKeyFieldType.F, 22, "upper Correction Limit");
                //缓冲器大小
                yield return new KKeyMetadata("K8612", KKeyFieldType.I3, 3, "Buffer size");
                //修正目标值
                yield return new KKeyMetadata("K8613", KKeyFieldType.F, 22, "Correction target value");

            }

            /*
                        private static void Buildrepository(IDictionary<KKey, KKeyMetadata> keys)
                        {
                            keys.Add(KKey.Of("K1001"), KKeyMetadata.of("TETEILNR", typeof(string), 30)); //Teile-Nr  (K1001)
                            keys.Add(KKey.Of("K1002"), KKeyMetadata.of("TEBEZEICH", typeof(string), 80)); //Bezeichnung des Teiles (K1002)
                            keys.Add(KKey.Of("K1010"), KKeyMetadata.of("TEDPFLICHT", typeof(int), 3)); //Dokumentationspflicht / Wichtung  (K1010)
                            keys.Add(KKey.Of("K1900"), KKeyMetadata.of("TEBEM", typeof(string), 255)); //Bemerkung (K1900)
                            keys.Add(KKey.Of("K1021"), KKeyMetadata.of("TEHERSTELLERNR", typeof(string), 20)); //Hersteller-Nr. (K1021)
                            keys.Add(KKey.Of("K1022"), KKeyMetadata.of("TEHERSTELLERBEZ", typeof(string), 80)); //Hersteller-Bezeichnung (K1022)
                            keys.Add(KKey.Of("K1031"), KKeyMetadata.of("TEWERKSTOFFNR", typeof(string), 20)); //Werkstoff-Nr. (K1031)
                            keys.Add(KKey.Of("K1032"), KKeyMetadata.of("TEWERKSTOFFBEZ", typeof(string), 40)); //Werkstoff-Bezeichnung (K1032)
                            keys.Add(KKey.Of("K1041"), KKeyMetadata.of("TEZEICHNUNGNR", typeof(string), 30)); //Zeichnuns-Nr. (K1041)
                            keys.Add(KKey.Of("K1042"), KKeyMetadata.of("TEZEICHNUNGAEND", typeof(string), 20)); //Zeichnung ï¿½nderung (K1042)
                            keys.Add(KKey.Of("K1043"), KKeyMetadata.of("TEZEICHNUNGINDEX", typeof(string), 40)); //Zeichnung Index (K1043)
                            keys.Add(KKey.Of("K1053"), KKeyMetadata.of("TEAUFTRAGSTR", typeof(string), 40)); //Auftrags-Nr. (K1053)
                            keys.Add(KKey.Of("K1051"), KKeyMetadata.of("TEAUFTRAGGBNR", typeof(string), 20)); //Auftraggeber-Nr (K1051)
                            keys.Add(KKey.Of("K1052"), KKeyMetadata.of("TEAUFTRAGGBBEZ", typeof(string), 40)); //Auftraggeber-Bezeichnung (K1052)
                            keys.Add(KKey.Of("K1061"), KKeyMetadata.of("TEKUNDENR", typeof(string), 20)); //Kunden-Nr. (K1061)
                            keys.Add(KKey.Of("K1062"), KKeyMetadata.of("TEKUNDEBEZ", typeof(string), 40)); //Kunden-Bezeichnung (K1062)
                            keys.Add(KKey.Of("K1071"), KKeyMetadata.of("TELIEFERANTNR", typeof(string), 20)); //Lieferanten-Nr. (K1071)
                            keys.Add(KKey.Of("K1072"), KKeyMetadata.of("TELIEFERANTBEZ", typeof(string), 40)); //Lieferanten-Bezeichnung (K1072)
                            keys.Add(KKey.Of("K1201"), KKeyMetadata.of("TEPREINRNR", typeof(string), 24)); //Prï¿½feinrichtungs-Nr. (K1201)
                            keys.Add(KKey.Of("K1202"), KKeyMetadata.of("TEPREINRBEZ", typeof(string), 40)); //Prï¿½feinrichtungs-Bezeichnung (K1202)
                            keys.Add(KKey.Of("K1203"), KKeyMetadata.of("TEPRGRUNDBEZ", typeof(string), 80)); //Prï¿½fgrund (K1203)
                            keys.Add(KKey.Of("K1204"), KKeyMetadata.of("TEPRBEGINNSTR", typeof(string), 40)); //Prï¿½fbeginn (K1204)
                            keys.Add(KKey.Of("K1205"), KKeyMetadata.of("TEPRENDESTR", typeof(string), 40)); //Prï¿½fende (K1205)
                            keys.Add(KKey.Of("K1003"), KKeyMetadata.of("TEKURZBEZEICH", typeof(string), 20)); //Teil Kurzbezeichnung (K1003)
                            keys.Add(KKey.Of("K1004"), KKeyMetadata.of("TEAENDSTAND", typeof(string), 20)); //ï¿½nderungsstand des Teils (K1004)
                            keys.Add(KKey.Of("K1005"), KKeyMetadata.of("TEERZEUGNIS", typeof(string), 40)); //Erzeugnis (K1005)
                            keys.Add(KKey.Of("K1081"), KKeyMetadata.of("TEMASCHINENR", typeof(string), 24)); //Maschine Nummer (K1081)
                            keys.Add(KKey.Of("K1082"), KKeyMetadata.of("TEMASCHINEBEZ", typeof(string), 40)); //Maschine Bezeichnung (K1082)
                            keys.Add(KKey.Of("K1085"), KKeyMetadata.of("TEMASCHINEORT", typeof(string), 40)); //Maschine Standort (K1085)
                            keys.Add(KKey.Of("K1086"), KKeyMetadata.of("TEARBEITSGANG", typeof(string), 40)); //Arbeitsgang (K1086)
                            keys.Add(KKey.Of("K1100"), KKeyMetadata.of("TEBEREICH", typeof(string), 40)); //Bereich im Werk (K1100)
                            keys.Add(KKey.Of("K1101"), KKeyMetadata.of("TEABT", typeof(string), 40)); //Abteilung (K1101)
                            keys.Add(KKey.Of("K1206"), KKeyMetadata.of("TEPRPLATZ", typeof(string), 40)); //Prï¿½fplatz (K1206)
                            keys.Add(KKey.Of("K1207"), KKeyMetadata.of("TEPPLANERST", typeof(string))); //Prï¿½fplanersteller (K1207)
                            keys.Add(KKey.Of("K1023"), KKeyMetadata.of("TEHERSTELLERKEY", typeof(int), 5)); //Key des Herstellers (K1023)
                            keys.Add(KKey.Of("K1033"), KKeyMetadata.of("TEWERKSTOFFKEY", typeof(int), 5)); //Key des Werkstoffes (K1033)
                            keys.Add(KKey.Of("K1044"), KKeyMetadata.of("TEZEICHNUNGKEY", typeof(int), 5)); //Key der Zeichnung (K1044)
                            keys.Add(KKey.Of("K1054"), KKeyMetadata.of("TEAUFTRAGGBKEY", typeof(int), 5)); //Key des Auftraggebers (K1054)
                            keys.Add(KKey.Of("K1063"), KKeyMetadata.of("TEKUNDEKEY", typeof(int), 5)); //Key des Kunden (K1063)
                            keys.Add(KKey.Of("K1073"), KKeyMetadata.of("TELIEFERANTKEY", typeof(int), 5)); //Key des Lieferanten (K1073)
                            keys.Add(KKey.Of("K1083"), KKeyMetadata.of("TEMASCHINEKEY", typeof(int), 5)); //Key der Maschine (K1083)
                            keys.Add(KKey.Of("K1208"), KKeyMetadata.of("TEPREINRKEY", typeof(int), 5)); //Key der Prï¿½feinrichtung (K1208)
                            keys.Add(KKey.Of("K1007"), KKeyMetadata.of("TENRKURZ", typeof(string), 20)); //Teile-Nr. Kurzbezeichnung (K1007)
                            keys.Add(KKey.Of("K1102"), KKeyMetadata.of("TEWERKSTATT", typeof(string), 40)); //Werkstatt (K1102)
                            keys.Add(KKey.Of("K1211"), KKeyMetadata.of("TENORMNR", typeof(string), 20)); //Normal Nummer (K1211)
                            keys.Add(KKey.Of("K1212"), KKeyMetadata.of("TENORMBEZ", typeof(string), 40)); //Normal Bezeichnung (K1212)
                            keys.Add(KKey.Of("K1215"), KKeyMetadata.of("TENORMAL", typeof(int), 5)); //Normal (K1215)
                            keys.Add(KKey.Of("K1008"), KKeyMetadata.of("TETYP", typeof(string), 20)); //Teiletyp (K1008)
                            keys.Add(KKey.Of("K1009"), KKeyMetadata.of("TECODE", typeof(string), 20)); //Teilecode (K1009)
                            keys.Add(KKey.Of("K1011"), KKeyMetadata.of("TEVARIANTE", typeof(string), 20)); //Variante (K1011)
                            keys.Add(KKey.Of("K1012"), KKeyMetadata.of("TESACHNRZUS", typeof(string), 20)); //Sachnummer Zusatz (K1012)
                            keys.Add(KKey.Of("K1013"), KKeyMetadata.of("TESACHNRIDX", typeof(string), 20)); //Sachnummer Index (K1013)
                            keys.Add(KKey.Of("K1014"), KKeyMetadata.of("TETEILIDENT", typeof(string), 20)); //Teile-Ident. (K1014)
                            keys.Add(KKey.Of("K1103"), KKeyMetadata.of("TEKOSTST", typeof(string), 40)); //Kostenstelle (K1103)
                            keys.Add(KKey.Of("K1104"), KKeyMetadata.of("TESCHICHT", typeof(string), 20)); //Schicht (K1104)
                            keys.Add(KKey.Of("K1110"), KKeyMetadata.of("TEBESTNR", typeof(string), 20)); //Bestellnummer (K1110)
                            keys.Add(KKey.Of("K1111"), KKeyMetadata.of("TEWARENEINNR", typeof(string), 20)); //Wareneingangsnummer (K1111)
                            keys.Add(KKey.Of("K1112"), KKeyMetadata.of("TEWUERFEL", typeof(string))); //Wï¿½rfel (K1112)
                            keys.Add(KKey.Of("K1113"), KKeyMetadata.of("TEPOSITION", typeof(string))); //Position (K1113)
                            keys.Add(KKey.Of("K1114"), KKeyMetadata.of("TEVORRICHT", typeof(string))); //Vorrichtung (K1114)
                            keys.Add(KKey.Of("K1115"), KKeyMetadata.of("TEFERTDAT", typeof(string))); //Fertigungsdatum (K1115)
                            keys.Add(KKey.Of("K1209"), KKeyMetadata.of("TEPRUEFART", typeof(string), 20)); //Prï¿½fart (K1209)
                            keys.Add(KKey.Of("K1230"), KKeyMetadata.of("TEMESSRAUM", typeof(string), 40)); //Meï¿½raum (K1230)
                            keys.Add(KKey.Of("K1231"), KKeyMetadata.of("TEMESSPROGNR", typeof(string), 20)); //Meï¿½programmnummer (K1231)
                            keys.Add(KKey.Of("K1232"), KKeyMetadata.of("TEMESSPROGVER", typeof(string), 20)); //Meï¿½programmversion (K1232)
                            keys.Add(KKey.Of("K1223"), KKeyMetadata.of("TEPRUEFERKEY", typeof(int), 5)); //Prï¿½fer Key (K1223)
                            keys.Add(KKey.Of("K1221"), KKeyMetadata.of("TEPRUEFERNR", typeof(string), 20)); //Prï¿½fernummer (K1221)
                            keys.Add(KKey.Of("K1222"), KKeyMetadata.of("TEPRUEFERNAME", typeof(string), 40)); //Prï¿½fername (K1222)
                            keys.Add(KKey.Of("K1016"), KKeyMetadata.of("TEZSB_1016", typeof(string), 30)); //"Zusammenbauteil" (K1016)
                            keys.Add(KKey.Of("K1350"), KKeyMetadata.of("TEREPORTFILE_1350", typeof(string), 50)); //Verknï¿½pfung des Teils mit einer Berichtsdatei (*.def) (K1350)
                            keys.Add(KKey.Of("K1045"), KKeyMetadata.of("TE_1045", typeof(string), 20)); //Zeichnungsgï¿½ltigkeitsdatum (K1045)
                            keys.Add(KKey.Of("K1046"), KKeyMetadata.of("TE_1046", typeof(string), 60)); //Zeichnungsdateiname (K1046)
                            keys.Add(KKey.Of("K1047"), KKeyMetadata.of("TE_1047", typeof(string), 20)); //Grundzeichnung Nummer (K1047)
                            keys.Add(KKey.Of("K1300"), KKeyMetadata.of("TE_1300", typeof(int))); //Auswertestrategie (K1300)
                            keys.Add(KKey.Of("K1301"), KKeyMetadata.of("TE_1301", typeof(int), 5)); //Mandant (K1301)
                            keys.Add(KKey.Of("K1302"), KKeyMetadata.of("TE_1302", typeof(string), 40)); //Prï¿½flos (K1302)
                            keys.Add(KKey.Of("K1311"), KKeyMetadata.of("TE_1311", typeof(string), 40)); //Fertigungsauftrag (K1311)
                            keys.Add(KKey.Of("K1341"), KKeyMetadata.of("TE_1341", typeof(string), 20)); //Prï¿½fplan Nummertext (K1341)
                            keys.Add(KKey.Of("K1342"), KKeyMetadata.of("TE_1342", typeof(string), 40)); //Prï¿½fplanindex (K1342)
                            keys.Add(KKey.Of("K1343"), KKeyMetadata.of("TE_1343", typeof(string), 20)); //Prï¿½fplan Erstellungsdatum (K1343)
                            keys.Add(KKey.Of("K1303"), KKeyMetadata.of("TEWERK", typeof(string), 40)); //Werk (K1303)
                            keys.Add(KKey.Of("K1210"), KKeyMetadata.of("TEMESSTYP", typeof(int), 5)); //Messtyp (K1210)
                            keys.Add(KKey.Of("K1344"), KKeyMetadata.of("TE_1344", typeof(string), 40)); //Prï¿½fplan Ersteller (K1344)
                            keys.Add(KKey.Of("K1015"), KKeyMetadata.of("TE_1015", typeof(int), 3)); //Modul-Key mit dem das Teil erstellt wurde
                            keys.Add(KKey.Of("K1017"), KKeyMetadata.of("TE_1017", typeof(int), 3)); //Prï¿½fplan gesperrt (K1017)
                            keys.Add(KKey.Of("K1087"), KKeyMetadata.of("TE_1087", typeof(string))); //Arbeitsgangbezeichnung (K1087)
                            keys.Add(KKey.Of("K1018"), KKeyMetadata.of("TE_1018", typeof(int))); //zugehï¿½riges Masterteil (K1018)
                            keys.Add(KKey.Of("K1401"), KKeyMetadata.of("TE_1401", typeof(int))); //destra vp_typ (K1401)
                            keys.Add(KKey.Of("K1402"), KKeyMetadata.of("TE_1402", typeof(int))); //destra rg_typ (K1402)
                            keys.Add(KKey.Of("K1403"), KKeyMetadata.of("TE_1403", typeof(int))); //destra va_typ (K1403)
                            keys.Add(KKey.Of("K1404"), KKeyMetadata.of("TE_1404", typeof(int))); //destra vp_k (K1404)
                            keys.Add(KKey.Of("K1405"), KKeyMetadata.of("TE_1405", typeof(int))); //destra vp_p (K1405)
                            keys.Add(KKey.Of("K1407"), KKeyMetadata.of("TE_1407", typeof(int))); //destra rg_polynom (K1407)
                            keys.Add(KKey.Of("K1408"), KKeyMetadata.of("TE_1408", typeof(int))); //destra rg_ww  (K1408)
                            keys.Add(KKey.Of("K1410"), KKeyMetadata.of("TE_1410", typeof(string))); //destra up_def_block (K1410)
                            keys.Add(KKey.Of("K1411"), KKeyMetadata.of("TE_1411", typeof(int))); //destra akt_destra_typ (K1411)
                            keys.Add(KKey.Of("K1091"), KKeyMetadata.of("TE_1091", typeof(string))); //Linien-Nr (K1091)
                            keys.Add(KKey.Of("K1092"), KKeyMetadata.of("TE_1092", typeof(string))); //Linienbezeichnung (K1092)
                            keys.Add(KKey.Of("K1105"), KKeyMetadata.of("TE_1105", typeof(string))); //Werksbereich-Nr. (K1105)
                            keys.Add(KKey.Of("K1106"), KKeyMetadata.of("TE_1106", typeof(string))); //Abteilung-Nr. (K1106)
                            keys.Add(KKey.Of("K1107"), KKeyMetadata.of("TE_1107", typeof(string))); //Werkstatt-Nr. (K1107)
                            keys.Add(KKey.Of("K1108"), KKeyMetadata.of("TE_1108", typeof(string))); //Kostenstelle-Nr. (K1108)
                            keys.Add(KKey.Of("K1304"), KKeyMetadata.of("TE_1304", typeof(string))); //Werk-Nr (K1304)
                            keys.Add(KKey.Of("K1048"), KKeyMetadata.of("TE_1048", typeof(string))); //CAD-Zeichnungsname (K1048)
                            keys.Add(KKey.Of("K0001"), KKeyMetadata.of("WVWERTNR", typeof(decimal), 22)); //Wert (K0001)
                            keys.Add(KKey.Of("K0002"), KKeyMetadata.of("WVATTRIBUT", typeof(int), 5)); //Attribut (K0002)
                            keys.Add(KKey.Of("K0008"), KKeyMetadata.of("WVPRUEFER", typeof(int), 10)); //Prï¿½fer Key (K0008)
                            keys.Add(KKey.Of("K0012"), KKeyMetadata.of("WVPRUEFMIT", typeof(int), 10)); //Prï¿½fmittel (K0012)
                            keys.Add(KKey.Of("K0010"), KKeyMetadata.of("WVMASCHINE", typeof(int), 10)); //Maschinen-Nr (K0010)
                            keys.Add(KKey.Of("K0007"), KKeyMetadata.of("WVNEST", typeof(int), 10)); //Nest-Nr (K0007)
                            keys.Add(KKey.Of("K0004"), KKeyMetadata.of("WVDATZEIT", typeof(DateTime))); //Datum/Zeit (K0004)
                            keys.Add(KKey.Of("K0006"), KKeyMetadata.of("WVCHARGE", typeof(string), 14)); //Chargen-/Ident.-Nr. (K0006)
                            keys.Add(KKey.Of("K0053"), KKeyMetadata.of("WVAUFTRAG", typeof(string), 20)); //Key des Auftrags (K0053)
                            keys.Add(KKey.Of("K0031"), KKeyMetadata.of("WV0031", typeof(int))); //ID der Messung/Untersuchung (K0031)
                            keys.Add(KKey.Of("K0034"), KKeyMetadata.of("WV0034", typeof(int))); //Messungsstatus fï¿½r SAP-ï¿½bertragung (K0034)
                            keys.Add(KKey.Of("K0009"), KKeyMetadata.of("WV0009", typeof(string), 255)); //Short Text
                            keys.Add(KKey.Of("K0014"), KKeyMetadata.of("WV0014", typeof(string), 40)); //Short Text
                            keys.Add(KKey.Of("K0015"), KKeyMetadata.of("WV0015", typeof(int), 5)); //Number
                            keys.Add(KKey.Of("K0016"), KKeyMetadata.of("WV0016", typeof(string))); //Short Text
                            keys.Add(KKey.Of("K0017"), KKeyMetadata.of("WV0017", typeof(string))); //Short Text
                            keys.Add(KKey.Of("K0097"), KKeyMetadata.of("WV0097", typeof(Guid))); //Number
                            keys.Add(KKey.Of("K2001"), KKeyMetadata.of("MEMERKNR", typeof(string), 20)); //Merkmals-Nr (K2001)
                            keys.Add(KKey.Of("K2002"), KKeyMetadata.of("MEMERKBEZ", typeof(string), 80)); //Bezeichnung des Merkmals (K2002)
                            keys.Add(KKey.Of("K2101"), KKeyMetadata.of("MENENNMAS", typeof(decimal), 22)); //Nennmaï¿½ numerisch (K2101)
                            keys.Add(KKey.Of("K2120"), KKeyMetadata.of("MEARTUGW", typeof(int), 3)); //Art des UGW : Abmaï¿½(1) ,Grenzwert(2) oder Natï¿½rliche Grenze(3), sonst wird Grenzwert angenommen (K2120)
                            keys.Add(KKey.Of("K2121"), KKeyMetadata.of("MEARTOGW", typeof(int), 3)); //Art des OGW : Abmaï¿½(1) ,Grenzwert(2) oder Natï¿½rliche Grenze(3), sonst wird Grenzwert angenommen (K2121)
                            keys.Add(KKey.Of("K2240"), KKeyMetadata.of("MEARTPLAUSIUNT", typeof(int))); //Temperatur Methode (K2240) (ehemals: Art der Plausigrenze unten : Keine Grenze (0),ï¿½berprï¿½fung bei Eingabe(1),ï¿½berprï¿½fung Eingabe und File-IO(2))
                            keys.Add(KKey.Of("K2241"), KKeyMetadata.of("MEARTPLAUSIOB", typeof(int))); //Komponente Methode (K2241) (ehemals: Art der Plausigrenze oben : Keine Grenze (0),ï¿½berprï¿½fung bei Eingabe(1),ï¿½berprï¿½fung Eingabe und File-IO(2))
                            keys.Add(KKey.Of("K2110"), KKeyMetadata.of("MEUGW", typeof(decimal), 22)); //UGW numerisch (K2110)
                            keys.Add(KKey.Of("K2111"), KKeyMetadata.of("MEOGW", typeof(decimal), 22)); //OGW numerisch (K2111)
                            keys.Add(KKey.Of("K2504"), KKeyMetadata.of("MEFSK", typeof(int), 3)); //ï¿½nderungsstatus Zeichnung (K2504) (ehemals: Nr. der Fehlersammelkarte))
                            keys.Add(KKey.Of("K2163"), KKeyMetadata.of("MEFEHLKOST", typeof(decimal), 22)); //Fehlerkosten (K2163)
                            keys.Add(KKey.Of("K2006"), KKeyMetadata.of("MEDPFLICHT", typeof(int), 5)); //Dokupflichtig (K2006)
                            keys.Add(KKey.Of("K2141"), KKeyMetadata.of("MEEINHEIT", typeof(int), 5)); //Masseinheit (K2141)
                            keys.Add(KKey.Of("K2022"), KKeyMetadata.of("MEAUFLOES", typeof(int), 5)); //Aufloesung = Anzahl Nachkommastellen (K2022)
                            keys.Add(KKey.Of("K2013"), KKeyMetadata.of("MEKLASSENW", typeof(decimal), 22)); //Klassenweite (K2013)
                            keys.Add(KKey.Of("K2311"), KKeyMetadata.of("MEFERTARTNR", typeof(string), 20)); //Fertigungsart-Nr. (K2311)
                            keys.Add(KKey.Of("K2312"), KKeyMetadata.of("MEFERTART", typeof(string), 40)); //Fertigungsart (K2312)
                            keys.Add(KKey.Of("K2405"), KKeyMetadata.of("MEPRUEFMIT", typeof(int), 5)); //Prï¿½fmittel. (K2405)
                            keys.Add(KKey.Of("K2403"), KKeyMetadata.of("MEPMGRUPPET", typeof(string), 80)); //Prï¿½fmittel-Gruppe Text (K2403)
                            keys.Add(KKey.Of("K2402"), KKeyMetadata.of("MEPRUEFMITT", typeof(string), 80)); //Prï¿½fmittel Text (K2402)
                            keys.Add(KKey.Of("K2401"), KKeyMetadata.of("MEPRUEFMITNRT", typeof(string), 40)); //Prï¿½fmittel-Nr. Text (K2401)
                            keys.Add(KKey.Of("K2041"), KKeyMetadata.of("MEERFART", typeof(int), 3)); //Erfassungsart (K2041)
                            keys.Add(KKey.Of("K2305"), KKeyMetadata.of("MEMASCHINE", typeof(int), 5)); //Maschinen-Nr (K2305)
                            keys.Add(KKey.Of("K2900"), KKeyMetadata.of("MEBEMERK", typeof(string), 255)); //Bemerkung (K2900)
                            //keys.Add(KKey.Of("K2205"), KKeyMetadata.of("MEUMFSTICH", typeof(int), 5)); //Stichprobenumfang (K2205)
                            keys.Add(KKey.Of("K2220"), KKeyMetadata.of("MEANZPRUEF", typeof(int), 5)); //Anzahl Prï¿½fer (K2220)
                            keys.Add(KKey.Of("K2221"), KKeyMetadata.of("MEANZWIED", typeof(int), 5)); //Anzahl Wiederholungen (K2221)
                            keys.Add(KKey.Of("K2205"), KKeyMetadata.of("MEANZTEILE", typeof(int), 5)); //Anzahl zu prï¿½fender Teile (K2205)
                            keys.Add(KKey.Of("K2021"), KKeyMetadata.of("MEFORMEL", typeof(string), 255)); //Verknï¿½pfungsformel (K2021)
                            keys.Add(KKey.Of("K2024"), KKeyMetadata.of("METRANSPA", typeof(decimal), 22)); //Transformationsparameter a (K2024)
                            keys.Add(KKey.Of("K2025"), KKeyMetadata.of("METRANSPB", typeof(decimal), 22)); //Transformationsparameter b (K2025)
                            keys.Add(KKey.Of("K2026"), KKeyMetadata.of("METRANSPC", typeof(decimal), 22)); //Transformationsparameter c (K2026)
                            keys.Add(KKey.Of("K2027"), KKeyMetadata.of("METRANSPD", typeof(decimal), 22)); //Transformationsparameter d (K2027)
                            keys.Add(KKey.Of("K2502"), KKeyMetadata.of("MEAUSWART", typeof(int), 3)); //Darstellungsformat Toleranz (K2502) (ehemals: Auswerteart)
                            keys.Add(KKey.Of("K2202"), KKeyMetadata.of("MEAUSWTYP", typeof(int), 3)); //Auswertetyp (K2202)
                            keys.Add(KKey.Of("K2004"), KKeyMetadata.of("MEMERKART", typeof(int), 5)); //Art des Merkmals (K2004)
                            keys.Add(KKey.Of("K2011"), KKeyMetadata.of("MEVERTFORM", typeof(int), 5)); //Verteilungsform (K2011)
                            keys.Add(KKey.Of("K2130"), KKeyMetadata.of("MEPLAUSIUN", typeof(decimal), 22)); //Plausibgrenze unten (K2130)
                            keys.Add(KKey.Of("K2131"), KKeyMetadata.of("MEPLAUSIOB", typeof(decimal), 22)); //Plausibgrenze oben (K2131)
                            keys.Add(KKey.Of("K2201"), KKeyMetadata.of("MEPROSTREU", typeof(decimal), 22)); //Prozeï¿½streuung numerisch (K2201)
                            keys.Add(KKey.Of("K2217"), KKeyMetadata.of("MENORMISTSTR", typeof(string), 80)); //Normal Hersteller (K2217) - (ehemals: Istmaï¿½ des Normals String - geï¿½ndert 11.02.2005)
                            keys.Add(KKey.Of("K2213"), KKeyMetadata.of("MENORMIST", typeof(decimal), 22)); //Istmaï¿½ des Normals numerisch (K2213)
                            keys.Add(KKey.Of("K2211"), KKeyMetadata.of("MENORMNR", typeof(string), 40)); //Nummer des Normals (als String) (K2211)
                            keys.Add(KKey.Of("K2212"), KKeyMetadata.of("MENORMBEZ", typeof(string), 40)); //Bezeichnung des Normals (K2212)
                            keys.Add(KKey.Of("K2007"), KKeyMetadata.of("MESTEUERB", typeof(int), 5)); //steuerbar (K2007)
                            keys.Add(KKey.Of("K2060"), KKeyMetadata.of("MEEREIGKAT", typeof(string), 50)); //Ereigniskatalog (K2060)
                            keys.Add(KKey.Of("K2005"), KKeyMetadata.of("MEMERKKLASSE", typeof(int), 5)); //Merkmals-Klasse (K2005)
                            keys.Add(KKey.Of("K2009"), KKeyMetadata.of("MEUNTERSART", typeof(int))); //Untersuchungs-Art (qs-STAT-Modul) (K2010)
                            keys.Add(KKey.Of("K2234"), KKeyMetadata.of("MEANZORDKLASSE", typeof(int))); //Unabhï¿½ngige Einflussgrï¿½ï¿½en (K2234)  (ehemals: Anzahl Ordinalklassen (K2014) - Feld ist entfallen)
                            keys.Add(KKey.Of("K2503"), KKeyMetadata.of("MEAUTOERKENNUNG", typeof(int), 3)); //Bemaï¿½ungstyp (K2503) (ehemals: automatische Werteerkennung (K2020))
                            keys.Add(KKey.Of("K2501"), KKeyMetadata.of("MEATTR", typeof(int), 3)); //Bemaï¿½ungsattribut (K2501) (ehemals: Attribut fï¿½r Regression)
                            keys.Add(KKey.Of("K2072"), KKeyMetadata.of("METRANSFEINGA", typeof(decimal), 22)); //Lineare Transformation fï¿½r Eingabe a*xB (Parameter a) (K2072)
                            keys.Add(KKey.Of("K2071"), KKeyMetadata.of("METRANSFEINGB", typeof(decimal), 22)); //Lineare Transformation fï¿½r Eingabe a*xB (Parameter b) (K2071)
                            keys.Add(KKey.Of("K2045"), KKeyMetadata.of("MEERFKANAL", typeof(string), 20)); //Erfassungskanal (K2045)
                            keys.Add(KKey.Of("K2046"), KKeyMetadata.of("MEERFSUBKANAL", typeof(string), 20)); //Erfassungssubkanal (K2046)
                            keys.Add(KKey.Of("K2012"), KKeyMetadata.of("MENACHARBEIT", typeof(int))); //Unterscheidung bei attr. Merkmalen : 0 - Grenzwerte,1-Nacharbeit (K2012)
                            keys.Add(KKey.Of("K2100"), KKeyMetadata.of("MEZIELWERT", typeof(decimal), 22)); //Sollwert/Zielwert (K2100)
                            keys.Add(KKey.Of("K2102"), KKeyMetadata.of("MEPMAX", typeof(decimal), 22)); //Zur Berechnung von cpk-Werten bei attributiven Merkmalen (K2102)
                            keys.Add(KKey.Of("K2142"), KKeyMetadata.of("MEEINHEITTEXT", typeof(string), 20)); //Einheit als Text fï¿½r alte Struktur (K2142)
                            keys.Add(KKey.Of("K2160"), KKeyMetadata.of("MELOSUMFANG", typeof(int), 5)); //Losumfang (K2160)
                            keys.Add(KKey.Of("K2161"), KKeyMetadata.of("MEKOSTENNACHARBEIT", typeof(decimal), 22)); //Kosten Nacharbeit (K2161)
                            keys.Add(KKey.Of("K2162"), KKeyMetadata.of("MEKOSTENAUSSCHUSS", typeof(decimal), 22)); //Kosten Ausschuï¿½ (K2162)
                            keys.Add(KKey.Of("K2301"), KKeyMetadata.of("MEMASCHNR", typeof(string), 20)); //Maschinen-Nr. (K2301)
                            keys.Add(KKey.Of("K2302"), KKeyMetadata.of("MEMASCHBEZ", typeof(string), 40)); //Maschinen-Bez. (K2302)
                            keys.Add(KKey.Of("K2303"), KKeyMetadata.of("MEABT", typeof(string), 40)); //Abteilung (K2303)
                            keys.Add(KKey.Of("K2304"), KKeyMetadata.of("MESTANDORT", typeof(string), 40)); //Standort (K2304)
                            keys.Add(KKey.Of("K2320"), KKeyMetadata.of("MEAUFTRNR", typeof(string), 20)); //Auftrags-Nr. (K2320)
                            keys.Add(KKey.Of("K2323"), KKeyMetadata.of("MEAUFTRAGGEBNR", typeof(int), 5)); //Auftraggeber-Nr. (K2323)
                            keys.Add(KKey.Of("K2321"), KKeyMetadata.of("MEAUFTRAGGEBNRT", typeof(string), 20)); //Auftraggeber-Nr.-Text (K2321)
                            keys.Add(KKey.Of("K2322"), KKeyMetadata.of("MEAUFTRAGGEB", typeof(string), 40)); //Auftraggeber (K2322)
                            keys.Add(KKey.Of("K2410"), KKeyMetadata.of("MEPRUEFORTT", typeof(string), 40)); //Prï¿½fort Text  (K2410)
                            keys.Add(KKey.Of("K2411"), KKeyMetadata.of("MEPRUEFBEGINN", typeof(string), 80)); //Prï¿½fbeginn (String) (K2411)
                            keys.Add(KKey.Of("K2412"), KKeyMetadata.of("MEPRUEFENDE", typeof(string), 80)); //Prï¿½fende (String) (K2412)
                            keys.Add(KKey.Of("K2423"), KKeyMetadata.of("MEPRUEFER", typeof(int), 5)); //Prï¿½fer (K2423)
                            keys.Add(KKey.Of("K2421"), KKeyMetadata.of("MEPRUEFERNR", typeof(string), 20)); //Prï¿½fer-Nr. (K2421)
                            keys.Add(KKey.Of("K2422"), KKeyMetadata.of("MEPRUEFERNAME", typeof(string), 40)); //Prï¿½fer-Name (K2422)
                            keys.Add(KKey.Of("K2901"), KKeyMetadata.of("MEPRUEFBEDING", typeof(string), 80)); //Prï¿½fbedingungen (K2901)
                            keys.Add(KKey.Of("K2019"), KKeyMetadata.of("MEPRUEFMITNR", typeof(int))); //Gruppen-Nr der Ausprï¿½gung (fï¿½r ordinale Merkmale) (K2019)  (Nummer bei FSK )(K2031)
                            keys.Add(KKey.Of("K2030"), KKeyMetadata.of("MEAUGROUP", typeof(int), 5)); //Nr. des ï¿½bergeordneten Merkmals (K2030)
                            keys.Add(KKey.Of("K2151"), KKeyMetadata.of("METOLERANZTEXT", typeof(string), 20)); //Toleranz als Text (K2151)
                            keys.Add(KKey.Of("K2333"), KKeyMetadata.of("MEWERKSTCK", typeof(int), 5)); //Werkstï¿½ck-Nr. (K2333)
                            keys.Add(KKey.Of("K2332"), KKeyMetadata.of("MEWERKSTCKTEXT", typeof(string), 40)); //Werkstï¿½ckbezeichnung (K2332)
                            keys.Add(KKey.Of("K2404"), KKeyMetadata.of("MEPMAUFLOES", typeof(decimal), 22)); //Auflï¿½sung/Meï¿½unsicherheit des Prï¿½fmittels (K2404)
                            keys.Add(KKey.Of("K2215"), KKeyMetadata.of("MENORMAL", typeof(int), 5)); //Normal-Key (K2215)
                            keys.Add(KKey.Of("K2214"), KKeyMetadata.of("MENORMALTEMP", typeof(decimal), 22)); //Temperatur des Normals (K2214)
                            keys.Add(KKey.Of("K2331"), KKeyMetadata.of("MEWERKSTCKNR", typeof(string), 20)); //Werkstï¿½ck-Nr. (String) (K2331)
                            keys.Add(KKey.Of("K2003"), KKeyMetadata.of("MEKURZBEZ", typeof(string), 20)); //Kurzbezeichnung (K2003)
                            keys.Add(KKey.Of("K2114"), KKeyMetadata.of("MEUGSCHROTT", typeof(decimal), 22)); //Untere Schrottgrenze (K2114)
                            keys.Add(KKey.Of("K2115"), KKeyMetadata.of("MEOGSCHROTT", typeof(decimal), 22)); //Obere Schrottgrenze (K2115)
                            keys.Add(KKey.Of("K2225"), KKeyMetadata.of("MECG", typeof(decimal), 22)); //ermittelter Cg-Wert (K2225)
                            keys.Add(KKey.Of("K2226"), KKeyMetadata.of("MECGK", typeof(decimal), 22)); //ermittelter Cgk-Wert (K2226)
                            keys.Add(KKey.Of("K2227"), KKeyMetadata.of("MEABWGC", typeof(decimal), 22)); //Abweichung GC Typ3- GC Typ 1 (K2227)
                            keys.Add(KKey.Of("K2243"), KKeyMetadata.of("MEZEICHN", typeof(string), 80)); //Zeichnung Dateiname (K2243)
                            keys.Add(KKey.Of("K2313"), KKeyMetadata.of("MEFERTARTKEY", typeof(int), 5)); //Key der Fertigungsart (K2313)
                            keys.Add(KKey.Of("K2406"), KKeyMetadata.of("MEPMHERST", typeof(string), 40)); //Prï¿½fmittelhersteller (K2406)
                            keys.Add(KKey.Of("K2042"), KKeyMetadata.of("MEERFNR", typeof(int), 5)); //Erfassungsgerï¿½t Nr. (K2042)
                            keys.Add(KKey.Of("K2043"), KKeyMetadata.of("MEERFNAME", typeof(string), 40)); //Erfassungsgerï¿½t Name (K2043)
                            keys.Add(KKey.Of("K2044"), KKeyMetadata.of("MEERFINDEX", typeof(int), 5)); //Erfassungsgerï¿½t Index (K2044)
                            keys.Add(KKey.Of("K2047"), KKeyMetadata.of("MEANFINDEX", typeof(int), 3)); //Software-Anforderung Index (K2047)
                            keys.Add(KKey.Of("K2051"), KKeyMetadata.of("MEINTERFACE", typeof(int), 3)); //Schnittstelle (K2051)
                            keys.Add(KKey.Of("K2052"), KKeyMetadata.of("MEBAUD", typeof(int), 5)); //Baudrate (K2052)
                            keys.Add(KKey.Of("K2053"), KKeyMetadata.of("MEIRQ", typeof(int), 3)); //IRQ-Nummer (K2053)
                            keys.Add(KKey.Of("K2054"), KKeyMetadata.of("MEPARITY", typeof(int), 3)); //Paritï¿½t (K2054)
                            keys.Add(KKey.Of("K2055"), KKeyMetadata.of("MEDATA", typeof(int), 3)); //Datenbits (K2055)
                            keys.Add(KKey.Of("K2056"), KKeyMetadata.of("MESTOP", typeof(int), 3)); //Stopbits (K2056)
                            keys.Add(KKey.Of("K2061"), KKeyMetadata.of("MEPZPKAT", typeof(int), 5)); //Prozeï¿½parameterkatalog (K2061)
                            keys.Add(KKey.Of("K2152"), KKeyMetadata.of("METOLERANZCALC", typeof(decimal), 22)); //berechnete Toleranz (K2152)
                            keys.Add(KKey.Of("K2306"), KKeyMetadata.of("MEBEREICH", typeof(string), 40)); //Bereich im Werk / Halle (K2306)
                            keys.Add(KKey.Of("K2307"), KKeyMetadata.of("MEPTM", typeof(string), 40)); //PTM-Nr. (K2307)
                            keys.Add(KKey.Of("K2341"), KKeyMetadata.of("MEPPLANNRT", typeof(string), 20)); //Prï¿½fplannummer Text (K2341)
                            keys.Add(KKey.Of("K2342"), KKeyMetadata.of("MEPPLAN", typeof(string), 40)); //Prï¿½fplan-Name (K2342)
                            keys.Add(KKey.Of("K2343"), KKeyMetadata.of("MEPPLANDAT", typeof(string), 20)); //Prï¿½fplan-Erstellungsdatum (K2343)
                            keys.Add(KKey.Of("K2344"), KKeyMetadata.of("MEPPLANERST", typeof(string), 40)); //Prï¿½fplanersteller (K2344)
                            keys.Add(KKey.Of("K2407"), KKeyMetadata.of("MESPCNR", typeof(string), 20)); //SPC-Gerï¿½te Nummer (K2407)
                            keys.Add(KKey.Of("K2408"), KKeyMetadata.of("MESPCHERST", typeof(string), 20)); //SPC-Gerï¿½te Hersteller (K2408)
                            keys.Add(KKey.Of("K2409"), KKeyMetadata.of("MESPCTYP", typeof(string), 20)); //SPC-Gerï¿½te Typ (K2409)
                            keys.Add(KKey.Of("K2116"), KKeyMetadata.of("MENORMISTUN", typeof(decimal))); //Temperaturkonstante (K2237) (ehemals: Unterer Istwert normal (K2251))
                            keys.Add(KKey.Of("K2117"), KKeyMetadata.of("MENORMISTOB", typeof(decimal))); //Temperatur Werkstï¿½ck (K2238) (ehemals: Oberer Istwert normal (K2252))
                            keys.Add(KKey.Of("K2216"), KKeyMetadata.of("MENORMALSERNR", typeof(string), 20)); //Normal-Seriennummer (K2216) [ab hier: Felder aus MERKMAL_AD]
                            keys.Add(KKey.Of("K2415"), KKeyMetadata.of("MEPRUEFMITSERNR", typeof(string), 20)); //Prï¿½fmittel-Seriennummer (K2415)
                            keys.Add(KKey.Of("K2416"), KKeyMetadata.of("MEANZGERAET", typeof(string), 40)); //Anzeigegerï¿½t (K2416)
                            keys.Add(KKey.Of("K2261"), KKeyMetadata.of("MEREFTEILNRSTR", typeof(string), 40)); //Referenzteil-Nummer (K2261)
                            keys.Add(KKey.Of("K2262"), KKeyMetadata.of("MEREFTEILBEZ", typeof(string), 40)); //Referenzteil-Bezeichnung (K2262)
                            keys.Add(KKey.Of("K2263"), KKeyMetadata.of("MEREFTEILIST", typeof(decimal), 22)); //Referenzteil-Istwert (K2263)
                            keys.Add(KKey.Of("K2264"), KKeyMetadata.of("MEREFTEILTEMP", typeof(decimal), 22)); //Referenzteil-Temperatur (K2264)
                            keys.Add(KKey.Of("K2265"), KKeyMetadata.of("MEREFTEILNR", typeof(int), 3)); //Referenzteil-Nummer (num) (K2265)
                            keys.Add(KKey.Of("K2266"), KKeyMetadata.of("MEREFTEILSERNR", typeof(string), 40)); //Referenzteil-Seriennummer (K2266)
                            keys.Add(KKey.Of("K2271"), KKeyMetadata.of("MEKALTEILUNRSTR", typeof(string))); //Kalibrierteil-Nummer unten (K2271)
                            keys.Add(KKey.Of("K2272"), KKeyMetadata.of("MEKALTEILUBEZ", typeof(string))); //Kalibrierteil-Bezeichnung unten (K2272)
                            keys.Add(KKey.Of("K2273"), KKeyMetadata.of("MEKALTEILUIST", typeof(decimal))); //Kalibrierteil-Istwert unten (K2273)
                            keys.Add(KKey.Of("K2274"), KKeyMetadata.of("MEKALTEILUTEMP", typeof(decimal))); //Kalibrierteil-Temperatur unten (K2274)
                            keys.Add(KKey.Of("K2275"), KKeyMetadata.of("MEKALTEILUNR", typeof(int))); //Kalibrierteil-Nummer (num) unten (K2275)
                            keys.Add(KKey.Of("K2276"), KKeyMetadata.of("MEKALTEILUSERNR", typeof(string))); //Kalibrierteil-Seriennummer unten (K2276)
                            keys.Add(KKey.Of("K2281"), KKeyMetadata.of("MEKALTEILMNRSTR", typeof(string), 40)); //Kalibrierteil-Nummer mitte (K2281)
                            keys.Add(KKey.Of("K2282"), KKeyMetadata.of("MEKALTEILMBEZ", typeof(string), 40)); //Kalibrierteil-Bezeichnung mitte (K2282)
                            keys.Add(KKey.Of("K2283"), KKeyMetadata.of("MEKALTEILMIST", typeof(decimal), 22)); //Kalibrierteil-Istwert mitte (K2283)
                            keys.Add(KKey.Of("K2284"), KKeyMetadata.of("MEKALTEILMTEMP", typeof(decimal), 22)); //Kalibrierteil-Temperatur mitte (K2284)
                            keys.Add(KKey.Of("K2285"), KKeyMetadata.of("MEKALTEILMNR", typeof(int), 3)); //Kalibrierteil-Nummer (num) mitte (K2285)
                            keys.Add(KKey.Of("K2286"), KKeyMetadata.of("MEKALTEILMSERNR", typeof(string), 40)); //Kalibrierteil-Seriennummer mitte (K2286)
                            keys.Add(KKey.Of("K2291"), KKeyMetadata.of("MEKALTEILONRSTR", typeof(string))); //Kalibrierteil-Nummer oben (K2291)
                            keys.Add(KKey.Of("K2292"), KKeyMetadata.of("MEKALTEILOBEZ", typeof(string))); //Kalibrierteil-Bezeichnung oben (K2292)
                            keys.Add(KKey.Of("K2293"), KKeyMetadata.of("MEKALTEILOIST", typeof(decimal))); //Kalibrierteil-Istwert oben (K2293)
                            keys.Add(KKey.Of("K2294"), KKeyMetadata.of("MEKALTEILOTEMP", typeof(decimal))); //Kalibrierteil-Temperatur oben (K2294)
                            keys.Add(KKey.Of("K2295"), KKeyMetadata.of("MEKALTEILONR", typeof(int))); //Kalibrierteil-Nummer (num) oben (K2295)
                            keys.Add(KKey.Of("K2296"), KKeyMetadata.of("MEKALTEILOSERNR", typeof(string))); //Kalibrierteil-Seriennummer oben (K2296)
                            keys.Add(KKey.Of("K2048"), KKeyMetadata.of("MEUEBERKAN", typeof(int), 3)); //ï¿½bernahmekanal (K2048)
                            keys.Add(KKey.Of("K2090"), KKeyMetadata.of("MEMERKCODE", typeof(string), 40)); //Merkmalcode (K2090)
                            keys.Add(KKey.Of("K2091"), KKeyMetadata.of("MEMERKINDEX", typeof(string), 20)); //Merkmalindex (K2091)
                            keys.Add(KKey.Of("K2092"), KKeyMetadata.of("MEMERKTEXT", typeof(string), 50)); //Merkmalstext (K2092)
                            keys.Add(KKey.Of("K2093"), KKeyMetadata.of("MEBEARBZUST", typeof(string), 80)); //Bearbeitungszustand (K2093)
                            keys.Add(KKey.Of("K2095"), KKeyMetadata.of("MEELEMCODE", typeof(string), 40)); //Elementcode (K2095)
                            keys.Add(KKey.Of("K2096"), KKeyMetadata.of("MEELEMINDEX", typeof(string), 20)); //Elementindex (K2096)
                            keys.Add(KKey.Of("K2097"), KKeyMetadata.of("MEELEMTEXT", typeof(string), 50)); //Elementtext (K2097)
                            keys.Add(KKey.Of("K2098"), KKeyMetadata.of("MEELEMADR", typeof(string), 20)); //Elementadresse (K2098)
                            keys.Add(KKey.Of("K2074"), KKeyMetadata.of("MECALIBADD", typeof(decimal), 22)); //Einstelloffset (K2074)
                            keys.Add(KKey.Of("K2075"), KKeyMetadata.of("MECALIBMULT", typeof(decimal), 22)); //Einstellfaktor (K2075)
                            keys.Add(KKey.Of("K2105"), KKeyMetadata.of("MEANZNIAUSGEF", typeof(int), 5)); //Anzahl nicht ausgefallener Teile (Modul RB) (K2105)
                            keys.Add(KKey.Of("K2203"), KKeyMetadata.of("MEGCKONVART", typeof(int))); //Konvertierungsart GC (K2203)
                            keys.Add(KKey.Of("K2222"), KKeyMetadata.of("MEANZREF", typeof(int), 5)); //Anzahl Referenzmessungen (K2222)
                            keys.Add(KKey.Of("K2244"), KKeyMetadata.of("MEREFPKTX", typeof(int), 5)); //Referenzpunkt X (K2244)
                            keys.Add(KKey.Of("K2245"), KKeyMetadata.of("MEREFPKTY", typeof(int), 5)); //Referenzpunkt Y (K2245)
                            keys.Add(KKey.Of("K2246"), KKeyMetadata.of("MEREFPKTZ", typeof(int), 5)); //Referenzpunkt Z (K2246)
                            keys.Add(KKey.Of("K2430"), KKeyMetadata.of("ME_2430", typeof(int), 5)); //Bemusterungsart EMPB (K2430)
                            keys.Add(KKey.Of("K2432"), KKeyMetadata.of("ME_2432", typeof(int), 5)); //Einzelwertausgabe EMPB (K2432)
                            keys.Add(KKey.Of("K2434"), KKeyMetadata.of("ME_2434", typeof(int), 5)); //Prozessfï¿½higkeitsnachweis EMPB (K2434)
                            keys.Add(KKey.Of("K2436"), KKeyMetadata.of("ME_2436", typeof(string), 10)); //Test Freq. EMPB/PPAP (K2436)
                            keys.Add(KKey.Of("K2438"), KKeyMetadata.of("ME_2438", typeof(string), 10)); //Qty. tested EMPB/PPAP (K2438)
                            keys.Add(KKey.Of("K2440"), KKeyMetadata.of("ME_2440", typeof(string), 40)); //ZSB-Komponente (K2440)
                            keys.Add(KKey.Of("K2442"), KKeyMetadata.of("ME_2442", typeof(string), 12)); //Masse der ZSB-Komponente (K2442)
                            keys.Add(KKey.Of("K2444"), KKeyMetadata.of("ME_2444", typeof(string), 40)); //Material der ZSB-Komponente (K2444)
                            keys.Add(KKey.Of("K2446"), KKeyMetadata.of("ME_2446", typeof(string), 40)); //Herstellerbezogene Produktbezeichnung der ZSB-Komponente (K2448)
                            keys.Add(KKey.Of("K2448"), KKeyMetadata.of("ME_2448", typeof(string), 40)); //Hersteller der ZSB-Komponente (K2448)
                            keys.Add(KKey.Of("K2073"), KKeyMetadata.of("ME_2073", typeof(decimal), 22)); //Einstellmaï¿½ (K2073)
                            keys.Add(KKey.Of("K2107"), KKeyMetadata.of("ME_2107", typeof(decimal))); //Erweiterungsfaktor fï¿½r erweiterte Meï¿½unsicherheit (K2107)
                            keys.Add(KKey.Of("K2170"), KKeyMetadata.of("ME_2170", typeof(decimal), 22)); //(K2170)
                            keys.Add(KKey.Of("K2171"), KKeyMetadata.of("ME_2171", typeof(decimal), 22)); //(K2171)
                            keys.Add(KKey.Of("K2172"), KKeyMetadata.of("ME_2172", typeof(decimal), 22)); //(K2172)
                            keys.Add(KKey.Of("K2173"), KKeyMetadata.of("ME_2173", typeof(decimal), 22)); //(K2173)
                            keys.Add(KKey.Of("K2228"), KKeyMetadata.of("ME_2228", typeof(decimal), 22)); //(K2228)
                            keys.Add(KKey.Of("K2229"), KKeyMetadata.of("ME_2229", typeof(decimal))); //(K2229)
                            keys.Add(KKey.Of("K2230"), KKeyMetadata.of("ME_2230", typeof(decimal))); //(K2230)
                            keys.Add(KKey.Of("K2231"), KKeyMetadata.of("ME_2231", typeof(decimal))); //(K2231)
                            keys.Add(KKey.Of("K2232"), KKeyMetadata.of("ME_2232", typeof(decimal))); //(K2232)
                            keys.Add(KKey.Of("K2233"), KKeyMetadata.of("ME_2233", typeof(decimal), 22)); //(K2233)
                            keys.Add(KKey.Of("K2235"), KKeyMetadata.of("ME_2235", typeof(decimal), 22)); //(K2235)
                            keys.Add(KKey.Of("K2236"), KKeyMetadata.of("ME_2236", typeof(decimal), 22)); //(K2236)
                            keys.Add(KKey.Of("K2016"), KKeyMetadata.of("ME_2016", typeof(int), 3)); //(K2016)
                            keys.Add(KKey.Of("K8500"), KKeyMetadata.of("MEUMFPROZ", typeof(int), 5)); //Stichprobenumfang Prozeï¿½fï¿½higkeit (K8500)
                            keys.Add(KKey.Of("K8501"), KKeyMetadata.of("MEGLEITSTUMF", typeof(int), 3)); //fï¿½r gleitende Mittelwertkarten Umfang der Gesamtstichprobe (K8501)
                            keys.Add(KKey.Of("K8502"), KKeyMetadata.of("MESTIFREQT", typeof(string), 40)); //Stichprobenfrequenz (String) (K8502)
                            keys.Add(KKey.Of("K8504"), KKeyMetadata.of("MESTIFREQ", typeof(int), 5)); //Stichprobenfrequenz (K8504)
                            keys.Add(KKey.Of("K8510"), KKeyMetadata.of("MECP", typeof(decimal), 22)); //Cp-Wert (K8510)
                            keys.Add(KKey.Of("K8511"), KKeyMetadata.of("MECPK", typeof(decimal), 22)); //Cpk-Wert (K8511)
                            keys.Add(KKey.Of("K8520"), KKeyMetadata.of("MEVORGCP", typeof(decimal), 22)); //Vorgabe Cp Wert (K8520)
                            keys.Add(KKey.Of("K8521"), KKeyMetadata.of("MEVORGCPK", typeof(decimal), 22)); //Vorgabe Cpk Wert (K8521)
                            keys.Add(KKey.Of("K8522"), KKeyMetadata.of("MECPFIX", typeof(decimal), 22)); //Gefixter Cp-Wert (K8522)
                            keys.Add(KKey.Of("K8523"), KKeyMetadata.of("MECPKFIX", typeof(decimal), 22)); //Gefixter Cpk-Wert (K8523)
                            keys.Add(KKey.Of("K8530"), KKeyMetadata.of("ME_8530", typeof(int), 5)); //Prozeï¿½fï¿½higkeit EMPB (K8530)
                            keys.Add(KKey.Of("K8531"), KKeyMetadata.of("ME_8531", typeof(decimal), 22)); //Eingegebener Fï¿½higkeitsindex Cp EMPB (K8531)
                            keys.Add(KKey.Of("K8532"), KKeyMetadata.of("ME_8532", typeof(decimal), 22)); //Eingegebener Fï¿½higkeitsindex Cpk EMPB (K8532)
                            keys.Add(KKey.Of("K8540"), KKeyMetadata.of("ME_8540", typeof(int), 5)); //Bewertung EMPB (K8540)
                            keys.Add(KKey.Of("K8600"), KKeyMetadata.of("MEKORRSTRAT", typeof(int), 3)); //Korrekturstrategie (K8600)
                            keys.Add(KKey.Of("K8610"), KKeyMetadata.of("MEUKG", typeof(decimal), 22)); //Untere Korrekturgrenze (K8610)
                            keys.Add(KKey.Of("K8611"), KKeyMetadata.of("MEOKG", typeof(decimal), 22)); //Obere Korrekturgrenze (K8611)
                            keys.Add(KKey.Of("K8612"), KKeyMetadata.of("MEPUFFERSIZE", typeof(int), 3)); //Puffergroesse (K8612)
                            keys.Add(KKey.Of("K8613"), KKeyMetadata.of("MEKORRZIEL", typeof(decimal), 22)); //Korrekturzielwert (K8613)
                        }

                         */
        }

        private static KKeyRepository _instance;

        public static KKeyRepository getInstance()
        {
            if (_instance == null)
            {
                _instance = new KKeyRepository();
            }
            return _instance;
        }

#if NETCORE
        private readonly ImmutableDictionary<string, KKeyMetadata> kKeysWithMetadata;
        private readonly ImmutableList<string> allKKeys;
        private readonly ImmutableList<KKey> partKKeys;
        private readonly ImmutableList<KKey> characteristicKKeys;
        private readonly ImmutableList<KKey> valueKKeys;
#else
        private readonly IDictionary<string, KKeyMetadata> kKeysWithMetadata;
        private readonly IList<string> allKKeys;
        private readonly IList<KKey> partKKeys;
        private readonly IList<KKey> characteristicKKeys;
        private readonly IList<KKey> valueKKeys;

#endif

        private KKeyRepository()
        {

            kKeysWithMetadata = new Dictionary<string, KKeyMetadata>(new DefaultKKeyProvider().CreateKKeysWithMetadata());
            //kKeysWithMetadata.putAll(new DefaultKKeyProvider().createKKeysWithMetadata());
            //kKeysWithMetadata.putAll(new CustomKKeyProvider().createKKeysWithMetadata()); /* override and fill in missing K-keys */

            //ServiceLoader<IKKeyProvider> thirdpartyProviders = ServiceLoader.load(IKKeyProvider.class);
            //for (IKKeyProvider provider : thirdpartyProviders) {
            //    kKeysWithMetadata.putAll(provider.createKKeysWithMetadata());
            //}


            //this.kKeysWithMetadata = ImmutableMap.copyOf(kKeysWithMetadata);


            this.allKKeys = this.kKeysWithMetadata.Keys.OrderBy(k => k).ToList();

            //this.partKKeys = this.kKeysWithMetadata.Keys.Where(k => k.IsPartLevel).OrderBy(k => k.Key).ToList();

            //this.characteristicKKeys = this.kKeysWithMetadata.Keys.Where(k => k.IsCharacteristicLevel).OrderBy(k => k.Key).ToList();

            //this.valueKKeys = this.kKeysWithMetadata.Keys.Where(k => k.IsValueLevel).OrderBy(k => k.Key).ToList();

        }


        /// <summary>
        /// Finds {@link KKeyMetadata metadata} for a given K-key. 
        /// <p>* Returns<b>null</b> if there is no metadata for the given K-key.</p>
        /// </summary>
        /// <param name="kKey"></param>
        /// <returns></returns>
        public KKeyMetadata GetMetadataFor(KKey kKey)
        {
            KKeyMetadata metadata = null;
            kKeysWithMetadata.TryGetValue(kKey.Key, out metadata);
            return metadata;
        }

        /// <summary>
        /// all sorted K-keys
        /// </summary>
        /// <returns></returns>
        public IList<string> GetAllKKeys()
        {
            return allKKeys;
        }

        /// <summary>
        /// sorted K-keys of part
        /// </summary>
        /// <returns></returns>
        public IList<KKey> GetPartKKeys()
        {
            return partKKeys;
        }


        /// <summary>
        /// sorted K-keys of characteristic
        /// </summary>
        /// <returns></returns>
        public IList<KKey> GetCharacteristicKKeys()
        {
            return characteristicKKeys;
        }

        /// <summary>
        /// sorted K-keys of value
        /// </summary>
        /// <returns></returns>
        public IList<KKey> GetValueKKeys()
        {
            return valueKKeys;
        }
    }
}