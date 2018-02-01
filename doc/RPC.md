# AQDEF KKey Fields

| Key   | PRC.TXTSINGULAR    | ENG.TXTSINGULAR                          | Amendment                                | AQDEF | Typ  | DB-table    | DB-field           |
| ----- | ------------------ | ---------------------------------------- | ---------------------------------------- | ----- | ---- | ----------- | ------------------ |
| K0001 | 测量值                | measured value                           |                                          | TRUE  | F    |             |                    |
| K0002 | 定性                 | attribute                                |                                          | TRUE  | I5   |             |                    |
| K0004 | 时间                 | Time                                     |                                          | TRUE  | D    |             |                    |
| K0005 | 事件                 | Event                                    | Catalog  based                           | TRUE  | S    |             |                    |
| K0006 | 批次编码               | Batch  number                            |                                          | TRUE  | A    |             |                    |
| K0007 | 巢穴编号               | Cavity  number                           | Catalog  based                           | TRUE  | I10  |             |                    |
| K0008 | 检验员姓名              | Operator  name                           | Catalog  based                           | TRUE  | I10  |             |                    |
| K0009 | 文字                 | Text                                     |                                          | TRUE  | A    |             |                    |
| K0010 | 机器编号               | Machine  number                          | Catalog  based                           | TRUE  | I10  |             |                    |
| K0011 | 过程参数               | Process  parameter                       | Catalog  based                           | TRUE  | S    |             |                    |
| K0012 | 检测工具编号             | Gage  number                             | Catalog  based                           | TRUE  | I10  |             |                    |
| K0014 | 零件  ID             | Part  ID number                          |                                          | TRUE  | A    |             |                    |
| K0015 | 检验的依据              | Reason  for test                         | defined  field content                   | TRUE  | I5   |             |                    |
| K0020 | 子组容量               | Subgroup  size                           | attributive  values only                 | TRUE  | I5   |             |                    |
| K0021 | 缺陷数目               | No.  of errors                           | attributive  values only                 | TRUE  | I5   |             |                    |
| K0053 | 定单                 | Order                                    |                                          | TRUE  | A    |             |                    |
| K0100 | 文件中的参数总数           | Total  no. of characteristics in file    |                                          | TRUE  | I5   |             |                    |
| K1001 | 零件号                | Part  number                             |                                          | TRUE  | A    | TEIL        | TETEIL             |
| K1002 | 零件名                | Part  description                        |                                          | TRUE  | A    | TEIL        | TETEILNR           |
| K1003 | 零件简称               | Part  abbreviation                       |                                          | TRUE  | A    | TEIL        | TEBEZEICH          |
| K1004 | 零件更改状态             | Part  Amendment status                   |                                          | TRUE  | A    | TEIL        | TEAENDSTAND        |
| K1005 | 产品                 | Product                                  |                                          | TRUE  | A    | TEIL        | TEERZEUGNIS        |
| K1007 | 零件编号简称             | Abbreviation  Part no.                   |                                          | TRUE  | A    | TEIL        | TENRKURZ           |
| K1008 | 零件类型               | Part  type                               |                                          | TRUE  | A    | TEIL        | TETYP              |
| K1009 | 零件代码               | Part  code                               |                                          | TRUE  | A    | TEIL        | TECODE             |
| K1010 | 受控文件               | Control  item                            | defined  field content                   | TRUE  | I3   | TEIL        | TEDPFLICHT         |
| K1011 | 变型                 | Variant                                  |                                          | TRUE  | A    | TEIL        | TEVARIANTE         |
| K1012 | 识别号  附件            | ID  number annex                         |                                          | TRUE  | A    | TEIL        | TESACHNRZUS        |
| K1013 | 识别号  索引            | ID  number index                         |                                          | TRUE  | A    | TEIL        | TESACHNRIDX        |
| K1014 | 零件识别               | Parts  ID                                |                                          | TRUE  | A    | TEIL        | TETEILIDENT        |
| K1020 | 制造商目录              | Manufacturer  Catalog                    |                                          | TRUE  | I5   |             |                    |
| K1021 | 制造商编号              | Manufacturer  No.                        |                                          | TRUE  | A    | TEIL        | TEHERSTELLERNR     |
| K1022 | 制造商名称              | Manufacturer  name                       |                                          | TRUE  | A    | TEIL        | TEHERSTELLERBEZ    |
| K1023 | 制造商名称              | Manufacturer  number                     | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEHERSTELLERKEY    |
| K1030 | 材料目录               | Materials  Catalog                       |                                          | TRUE  | I5   |             |                    |
| K1031 | 材料编号               | Material  number                         |                                          | TRUE  | A    | TEIL        | TEWERKSTOFFNR      |
| K1032 | 材料名称               | Material  Description                    | new  lenght in V10                       | TRUE  | A    | TEIL        | TEWERKSTOFFBEZ     |
| K1033 | 材料编号               | Material  number                         | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEWERKSTOFFKEY     |
| K1040 | 图纸目录               | Drawing  Catalog                         |                                          | TRUE  | I5   |             |                    |
| K1041 | 图纸编号               | Drawing  number                          |                                          | TRUE  | A    | TEIL        | TEZEICHNUNGNR      |
| K1042 | 图纸更改               | Drawing  Amendment                       |                                          | TRUE  | A    | TEIL        | TEZEICHNUNGAEND    |
| K1043 | 图纸索引               | Drawing  Index                           | new  lenght in V10                       | TRUE  | A    | TEIL        | TEZEICHNUNGINDEX   |
| K1044 | 图纸编号               | Drawing  Number                          | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEZEICHNUNGKEY     |
| K1050 | 委托方-目录             | Contractor  Catalog                      |                                          | TRUE  | I5   |             |                    |
| K1051 | 委托方-编号             | Contractor  Number                       |                                          | TRUE  | A    | TEIL        | TEAUFTRAGGBNR      |
| K1052 | 委托方名称              | Contractor  Name                         | new  lenght in V10                       | TRUE  | A    | TEIL        | TEAUFTRAGGBBEZ     |
| K1053 | 合同                 | Contract                                 | or  K0053                                | TRUE  | A    | TEIL        | TEAUFTRAGSTR       |
| K1054 | 委托方-编号             | Contractor  Number                       | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEAUFTRAGGBKEY     |
| K1060 | 用户目录               | Customer  Catalog                        |                                          | TRUE  | I5   |             |                    |
| K1061 | 用户编号               | Customer  Number                         |                                          | TRUE  | A    | TEIL        | TEKUNDENR          |
| K1062 | 用户名称               | Customer  Name                           | new  lenght in V10                       | TRUE  | A    | TEIL        | TEKUNDEBEZ         |
| K1063 | 用户编号               | Customer  Number                         | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEKUNDEKEY         |
| K1070 | 供应商目录              | Supplier  Catalog                        |                                          | TRUE  | I5   |             |                    |
| K1071 | 供应商编号              | Supplier  Number                         |                                          | TRUE  | A    | TEIL        | TELIEFERANTNR      |
| K1072 | 供应商名称              | Supplier  Name                           |                                          | TRUE  | A    | TEIL        | TELIEFERANTBEZ     |
| K1073 | 供应商编号              | Supplier  Number                         | new  lenght in V10                       | TRUE  | I10  | TEIL        | TELIEFERANTKEY     |
| K1080 | 机器目录               | Machine  Catalog                         |                                          | TRUE  | I5   |             |                    |
| K1081 | 机器编号               | Machine  Number                          | or  K0010 / K2301                        | TRUE  | A    | TEIL        | TEMASCHINENR       |
| K1082 | 机器名称               | Machine  Description                     | or  K0010 / K2302                        | TRUE  | A    | TEIL        | TEMASCHINEBEZ      |
| K1083 | 机器编号               | Machine  Number                          |                                          | TRUE  | I5   | TEIL        | TEMASCHINEKEY      |
| K1085 | 机器位置               | Machine  Location                        | or  K0010                                | TRUE  | A    | TEIL        | TEMASCHINEORT      |
| K1086 | 道序                 | Work  Cycle / Operation no.              | or  K2311                                | TRUE  | A    | TEIL        | TEARBEITSGANG      |
| K1100 | 工厂范围               | Plant  Sector                            |                                          | TRUE  | A    | TEIL        | TEBEREICH          |
| K1101 | 部门                 | Department                               |                                          | TRUE  | A    | TEIL        | TEABT              |
| K1102 | 车间/范围              | Workshop/sector                          |                                          | TRUE  | A    | TEIL        | TEWERKSTATT        |
| K1103 | 成本核算点              | Cost  centre                             |                                          | TRUE  | A    | TEIL        | TEKOSTST           |
| K1104 | 班次                 | Shift                                    |                                          | TRUE  | A    | TEIL        | TESCHICHT          |
| K1110 | 订货号                | Order  number                            |                                          | TRUE  | A    | TEIL        | TEBESTNR           |
| K1111 | 进货编号               | Goods  received number                   |                                          | TRUE  | A    | TEIL        | TEWARENEINNR       |
| K1112 | Cube               | Cube                                     |                                          | TRUE  | A    | TEIL        | TEWUERFEL          |
| K1113 | 位置                 | Location                                 |                                          | TRUE  | A    | TEIL        | TEPOSITION         |
| K1114 | 设备                 | Device                                   |                                          | TRUE  | A    | TEIL        | TEVORRICHT         |
| K1115 | 生产日期               | Production  date                         |                                          | TRUE  | A    | TEIL        | TEFERTDAT          |
| K1201 | 检验设备编号             | Test  Facility Number                    | or  K2401                                | TRUE  | A    | TEIL        | TEPREINRNR         |
| K1202 | 检验设备名称             | Test  Facility Description               | or  K2402                                | TRUE  | A    | TEIL        | TEPREINRBEZ        |
| K1203 | 检验原因               | Reason  for Test                         |                                          | TRUE  | A    | TEIL        | TEPRGRUNDBEZ       |
| K1204 | 检验开始               | Test  Begin                              |                                          | TRUE  | D    | TEIL        | TEPRBEGINNSTR      |
| K1205 | 检验结束               | Test  End                                |                                          | TRUE  | D    | TEIL        | TEPRENDESTR        |
| K1206 | 检验台                | Test  Location                           | or  K1201                                | TRUE  | A    | TEIL        | TEPRPLATZ          |
| K1207 | 检验计划编制者            | Test  Plan Developer                     |                                          | TRUE  | A    | TEIL        | TEPPLANERST        |
| K1208 | 检验设备编号             | Test  Facility No.                       | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEPREINRKEY        |
| K1209 | 检验方法               | Inspection  type                         |                                          | TRUE  | A    | TEIL        | TEPRUEFART         |
| K1210 | 测量类型               | measurement  type                        | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEMESSTYP          |
| K1211 | 样件编号               | Standard  Number                         | new  lenght in V10                       | TRUE  | A    | TEIL        | TENORMNR           |
| K1212 | 样件名称               | Standard  description                    |                                          | TRUE  | A    | TEIL        | TENORMBEZ          |
| K1215 | 样件编号               | Standard  number                         | new  lenght in V10                       | TRUE  | I10  | TEIL        | TENORMAL           |
| K1221 | 检验员编号              | Inspector  number                        |                                          | TRUE  | A    | TEIL        | TEPRUEFERNR        |
| K1222 | 检验员名称              | Inspector  name                          |                                          | TRUE  | A    | TEIL        | TEPRUEFERNAME      |
| K1223 | 检验员编号              | Inspector  number                        | new  lenght in V10                       | TRUE  | I10  | TEIL        | TEPRUEFERKEY       |
| K1230 | 测量室                | Gage  room                               |                                          | TRUE  | A    | TEIL        | TEMESSRAUM         |
| K1231 | 测量程序编号             | Measuring  program number                |                                          | TRUE  | A    | TEIL        | TEMESSPROGNR       |
| K1232 | 测量程序版本             | Measuring  program version               |                                          | TRUE  | A    | TEIL        | TEMESSPROGVER      |
| K1303 | 工厂                 | Plant                                    |                                          | TRUE  | A    | TEIL        | TEWERK             |
| K1900 | 说明                 | Remark                                   |                                          | TRUE  | A    | TEIL        | TEBEM              |
| K2001 | 被检参数编号             | Characteristic  Number                   |                                          | TRUE  | A    | MERKMAL     | MEMERKNR           |
| K2002 | 被检参数名称             | Characteristic  Description              |                                          | TRUE  | A    | MERKMAL     | MEMERKBEZ          |
| K2003 | 被测参数简称             | Characteristic  Abbreviation             |                                          | TRUE  | A    | MERKMAL     | MEKURZBEZ          |
| K2004 | 被测参数类型             | Characteristic  Type                     | defined  field content                   | TRUE  | I5   | MERKMAL     | MEMERKART          |
| K2005 | 被测参数级别             | Characteristics  Class                   | defined  field content                   | TRUE  | I5   | MERKMAL     | MEMERKKLASSE       |
| K2006 | 受控文件               | Control  Item                            | defined  field content                   | TRUE  | I5   | MERKMAL     | MEDPFLICHT         |
| K2007 | 控制方式               | Control  Type                            | defined  field content                   | TRUE  | I5   | MERKMAL     | MESTEUERB          |
| K2011 | 分布                 | Distribution                             | defined  field content                   | TRUE  | I5   | MERKMAL     | MEVERTFORM         |
| K2013 | 自然级宽               | natural  class width                     | natural  class width for variable-classified characteristics | TRUE  | F    | MERKMAL     | MEKLASSENW         |
| K2021 | 逻辑运算公式             | Logical  Operation Formula               | formula  for calculation of values of a characteristic from values of other  characteristics. Ex.:m1+m2 (addition of two characteristics) | TRUE  | A    | MERKMAL     | MEFORMEL           |
| K2022 | 小数点位数              | Decimal  Places                          | number  of decimal places in value recording | TRUE  | I5   | MERKMAL     | MEAUFLOES          |
| K2023 | 转换方式               | Transformation  Type                     |                                          | TRUE  | I3   | MERKMAL     | METRANSART         |
| K2024 | 转换参数  a            | Transformation  Parameter a              |                                          | TRUE  | F    | MERKMAL     | METRANSPA          |
| K2025 | 转换参数  b            | Transformation  Parameter b              |                                          | TRUE  | F    | MERKMAL     | METRANSPB          |
| K2026 | 转换参数  c            | Transformation  Parameter c              |                                          | TRUE  | F    | MERKMAL     | METRANSPC          |
| K2027 | 转换参数  d            | Transformation  Parameter d              |                                          | TRUE  | F    | MERKMAL     | METRANSPD          |
| K2030 | 组编号                | Group  Number                            | only  for simple aggregation, see also K5000 | TRUE  | I5   | MERKMAL     | MEAUGROUP          |
| K2031 | 组元素编号              | Group  Element Number                    | only  for simple aggregation, see also K5000 | TRUE  | I5   | MERKMAL     | MEUPPERMERKMAL     |
| K2041 | 采录方式               | Recording  Type                          | flag:  chosen recording type: manual or serial interface | TRUE  | I3   | MERKMAL     | MEERFART           |
| K2042 | 采录设备编号             | Recording  Device Number                 |                                          | TRUE  | I5   | MERKMAL     | MEERFNR            |
| K2043 | 采录设备名称             | Recording  Device Name                   |                                          | TRUE  | A    | MERKMAL     | MEERFNAME          |
| K2044 | 采录设备索引             | Recording  Device Index                  |                                          | TRUE  | I5   | MERKMAL     | MEERFINDEX         |
| K2045 | 采录通道               | Recording  Channel                       |                                          | TRUE  | I3   | MERKMAL     | MEERFKANAL         |
| K2046 | 采录亚通道              | Recording  Subchannel                    |                                          | TRUE  | I3   | MERKMAL     | MEERFSUBKANAL      |
| K2047 | 软件要求索引             | Software  Requirement Index              |                                          | TRUE  | I3   | MERKMAL     | MEANFINDEX         |
| K2048 | 录取通道               | Takeover  channel                        |                                          | TRUE  | I3   | MERKMAL     | MEUEBERKAN         |
| K2049 | 通道初始化              | Channel  initialization                  |                                          | TRUE  | I3   | MERKMAL     | MEFEHLART          |
| K2051 | 界面                 | Interface                                |                                          | TRUE  | I3   | MERKMAL     | MEINTERFACE        |
| K2052 | 波特率                | Baud  Rate                               |                                          | TRUE  | I5   | MERKMAL     | MEBAUD             |
| K2054 | 奇偶性                | Parity                                   |                                          | TRUE  | I3   | MERKMAL     | MEPARITY           |
| K2055 | Datenbits          | Data  bits                               |                                          | TRUE  | I3   | MERKMAL     | MEDATA             |
| K2056 | Stopbits           | Stop  bits                               |                                          | TRUE  | I3   | MERKMAL     | MESTOP             |
| K2060 | 事件目录               | Events  Catalog                          | Catalog  selection, (see also chapter 8.3), necessary for usage of K0005 | TRUE  | I5   | MERKMAL     | MEEREIGKAT         |
| K2061 | 过程参数目录             | Process  Parameter Catalog               | Catalog  selection, (see also chapter 8.3), necessary for usage of K0011 | TRUE  | I5   | MERKMAL     | MEPZPKAT           |
| K2062 | 巢穴目录               | Cavity  catalog                          | Catalog  selection, (see also chapter 8.3), necessary for usage of K0007 | TRUE  | I5   | MZ          | ME_2062            |
| K2063 | 机器目录               | Machine  catalog                         | Catalog  selection, (see also chapter 8.3), necessary for usage of K0010 | TRUE  | I5   | MZ          | ME_2063            |
| K2064 | 量具目录               | Gage  catalog                            | Catalog  selection, (see also chapter 8.3), necessary for usage of K0012 | TRUE  | I5   | MZ          | ME_2064            |
| K2065 | 操作员目录              | Operator  catalog                        | Catalog  selection, (see also chapter 8.3), necessary for usage of K0008 | TRUE  | I5   | MZ          | ME_2065            |
| K2071 | 附加常数               | Accumulating  Constant                   | for  linear transformation when entering values referring to form value = K2072 *  input + K2071 | TRUE  | F    | MERKMAL     | METRANSFEINGB      |
| K2072 | 乘数因子               | Multiplication  factor                   |                                          | TRUE  | F    | MERKMAL     | METRANSFEINGA      |
| K2080 | 被测参数状态(选定,  去选, …) | Characteristics  status (selected, unselected, ...) |                                          | TRUE  | I    | MERKMAL     | MEMASSN            |
| K2091 | 被测参数索引             | Characteristic  index                    |                                          | TRUE  | A    | MERKMAL     | MEMERKINDEX        |
| K2092 | 被检参数说明             | Characteristic  text                     |                                          | TRUE  | A    | MERKMAL     | MEMERKTEXT         |
| K2093 | 加工状态               | Processing  status                       |                                          | TRUE  | A    | MERKMAL     | MEBEARBZUST        |
| K2095 | 组件代码               | Element  code                            |                                          | TRUE  | A    | MERKMAL     | MEELEMCODE         |
| K2096 | 组件索引               | Element  index                           |                                          | TRUE  | A    | MERKMAL     | MEELEMINDEX        |
| K2097 | 组件说明               | Element  text                            |                                          | TRUE  | A    | MERKMAL     | MEELEMTEXT         |
| K2098 | 组件地址               | Element  address                         |                                          | TRUE  | A    | MERKMAL     | MEELEMADR          |
| K2100 | 名义-/目标值            | Target  value                            | objecticve  measure; in case of attributive characteristics use Ptarget as absolute value | TRUE  | F    | MERKMAL     | MEZIELWERT         |
| K2101 | 名义值                | Nominal  value                           | drawing  measure, nominal value will be referred to, when calaculating specification  limits input tolerance | TRUE  | F    | MERKMAL     | MENENNMAS          |
| K2102 | Pmax               | Pmax                                     | for  calculation of Cpk values with attribute characteristics Cpk = (Pmax - P)/3* | TRUE  | F    | MERKMAL     | MEPMAX             |
| K2105 | 审查时零件时合格           | Parts  OK at Censoring                   | module  RB                               | TRUE  | I5   | MERKMAL     | MEANZNIAUSGEF      |
| K2110 | 下限                 | Lower  Specification Limit               |                                          | TRUE  | F    | MERKMAL     | MEUGW              |
| K2111 | 上限                 | Upper  Specification Limit               |                                          | TRUE  | F    | MERKMAL     | MEOGW              |
| K2112 | 下公差                | Lower  Allowance                         |                                          | TRUE  | F    |             |                    |
| K2113 | 上公差                | Upper  Allowance                         |                                          | TRUE  | F    |             |                    |
| K2114 | 下报废界限              | Lower  Scrap Limit                       |                                          | TRUE  | F    | MERKMAL     | MEUGSCHROTT        |
| K2115 | 上报废界限              | Upper  Scrap Limit                       |                                          | TRUE  | F    | MERKMAL     | MEOGSCHROTT        |
| K2120 | 界限                 | Boundary                                 | natural  limit                           | TRUE  | I3   | MERKMAL     | MEARTUGW           |
| K2121 | 界限                 | Boundary                                 | natural  limit                           | TRUE  | I3   | MERKMAL     | MEARTOGW           |
| K2130 | 下置信界限              | Lower  Plausibility Limit                |                                          | TRUE  | F    | MERKMAL     | MEPLAUSIUN         |
| K2131 | 上置信界限              | Upper  Plausibility Limit                |                                          | TRUE  | F    | MERKMAL     | MEPLAUSIOB         |
| K2141 | 单位                 | Unit                                     | number  of selected unit (e.g. from catalogues) | TRUE  | I5   | MERKMAL     | MEEINHEIT          |
| K2142 | 单位                 | Unit                                     | text                                     | TRUE  | A    | MERKMAL     | MEEINHEITTEXT      |
| K2143 | 相对单位               | Unit  relative                           |                                          | TRUE  | A    | MERKMAL     | MEEINHREL          |
| K2144 | 附加常数  相对的          | Adding  constant relative                |                                          | TRUE  | F    | MERKMAL     | MEADDFAKREL        |
| K2145 | 相对乘数因子             | Multiplication  factor relative          |                                          | TRUE  | F    | MERKMAL     | MEMULFAKREL        |
| K2151 | 公差                 | Tolerance                                |                                          | TRUE  | A    | MERKMAL     | METOLERANZTEXT     |
| K2152 | 计算的公差              | Calculated  Tolerance                    |                                          | TRUE  | F    | MERKMAL     | METOLERANZCALC     |
| K2160 | 分批大小               | Batch  size                              |                                          | TRUE  | I10  | MERKMAL     | MELOSUMFANG        |
| K2161 | 返工成本               | Re-work  Cost                            | cost  for parts to be re-worked          | TRUE  | F    | MERKMAL     | MEKOSTENNACHARBEIT |
| K2162 | 报废成本               | Rejects  Cost                            |                                          | TRUE  | F    | MERKMAL     | MEKOSTENAUSSCHUSS  |
| K2163 | 缺陷成本               | Error  Cost                              |                                          | TRUE  | F    | MERKMAL     | MEFEHLKOST         |
| K2170 | 审查时间点              | Censoring  Time                          | module  RB                               | TRUE  | F    | MERKMAL     | ME_2170            |
| K2171 | 推断                 | Extrapolation                            | module  RB                               | TRUE  | F    | MERKMAL     | ME_2171            |
| K2201 | 过程离散               | Process  Variation                       | module  GC                               | TRUE  | F    | MERKMAL     | MEPROSTREU         |
| K2202 | 评定方法               | Evaluation  Type                         | defined  field content (e.g. type 1, type 2 etc. - see also chapter 4.1) | TRUE  | I3   | MERKMAL     | MEAUSWTYP          |
| K2205 | 零件数目               | Number  of Parts                         | module  GC                               | TRUE  | I5   | MERKMAL     | MEANZTEILE         |
| K2210 | 样件目录               | Master  Catalog                          | Catalog  selection, (see also chapter 8.3), module GC | TRUE  | I5   |             |                    |
| K2211 | 样件编号               | Master  Number                           |                                          | TRUE  | A    | MERKMAL     | MENORMNR           |
| K2212 | 标准件名称              | Master  Description                      |                                          | TRUE  | A    | MERKMAL     | MENORMBEZ          |
| K2213 | 样件实际值              | Standard  actual value                   | module  GC type 1                        | TRUE  | F    | MERKMAL     | MENORMIST          |
| K2214 | 样件温度               | Master  Temperature                      |                                          | TRUE  | F    | MERKMAL     | MENORMALTEMP       |
| K2215 | 样件编号               | Master  Number                           |                                          | TRUE  | I5   | MERKMAL     | MENORMAL           |
| K2216 | 样件系列号              | Master  Serial Number                    |                                          | TRUE  | A    | MERKMAL     | MENORMALSERNR      |
| K2220 | 检验员数量              | Number  of operators                     | module  GC                               | TRUE  | I5   | MERKMAL     | MEANZPRUEF         |
| K2221 | 测量次数               | No.  of Trials                           | in  type-2 studies (measurements per operator and parts e.g. 2) in type-3 studies  number of measurements | TRUE  | I5   | MERKMAL     | MEANZWIED          |
| K2222 | 标准件测量次数            | Number  of reference measurements        | module  GC                               | TRUE  | I5   | MERKMAL     | MEANZREF           |
| K2225 | Cg-值               | Cg  value                                |                                          | TRUE  | F    | MERKMAL     | MECG               |
| K2226 | Cgk-值              | Cgk  value                               |                                          | TRUE  | F    | MERKMAL     | MECGK              |
| K2227 | 偏离方法1              | Deviation  from Type 1                   | module  GC CNOMO                         | TRUE  | F    | MERKMAL     | MEABWGC            |
| K2228 | Sg                 | Sg                                       | module  GC Stability                     | TRUE  | F    | MERKMAL     | ME_2228            |
| K2243 | 图纸文件名              | Drawing  file name                       |                                          | TRUE  | A    | MERKMAL     | MEZEICHN           |
| K2244 | 图纸基准点  X           | drawing  reference point X               |                                          | TRUE  | I5   | MERKMAL     | MEREFPKTX          |
| K2245 | 图纸基准点  Y           | drawing  reference point Y               |                                          | TRUE  | I5   | MERKMAL     | MEREFPKTY          |
| K2301 | 机器编号               | Machine  number                          | or  K1081 / K0010                        | TRUE  | A    | MERKMAL     | MEMASCHNR          |
| K2302 | 机器名称               | Machine  Description                     | or  K1082 / K0010                        | TRUE  | A    | MERKMAL     | MEMASCHBEZ         |
| K2303 | 部门/成本位置            | Department/Cost  center                  | or  K1103                                | TRUE  | A    | MERKMAL     | MEABT              |
| K2304 | 机器位置               | Machine  Location                        |                                          | TRUE  | A    | MERKMAL     | MESTANDORT         |
| K2305 | 机器编号               | Machine  Number                          |                                          | TRUE  | I5   | MERKMAL     | MEMASCHINE         |
| K2306 | 区域  工厂/车间          | Plant/Hall  Sector                       |                                          | TRUE  | A    | MERKMAL     | MEBEREICH          |
| K2307 | PTM  编号            | PTM  Number                              |                                          | TRUE  | A    | MERKMAL     | MEPTM              |
| K2311 | 产品类型               | Production  Type                         | or  K1086                                | TRUE  | A    | MERKMAL     | MEFERTARTNR        |
| K2312 | 产品类型名称             | Production  Type Description             | or  K1086                                | TRUE  | A    | MERKMAL     | MEFERTART          |
| K2313 | 产品类型编号             | Production  Type Number                  |                                          | TRUE  | I5   | MERKMAL     | MEFERTARTKEY       |
| K2320 | 合同编号               | Contract  Number                         |                                          | TRUE  | A    | MERKMAL     | MEAUFTRNR          |
| K2321 | 委托方-编号             | Contractor  Number                       |                                          | TRUE  | A    | MERKMAL     | MEAUFTRAGGEBNRT    |
| K2322 | 委托方姓名              | Contractor  Name                         |                                          | TRUE  | A    | MERKMAL     | MEAUFTRAGGEB       |
| K2323 | 委托方-编号             | Contractor  Number                       |                                          | TRUE  | I5   | MERKMAL     | MEAUFTRAGGEBNR     |
| K2331 | 工件编号               | Work  piece Number                       |                                          | TRUE  | A    | MERKMAL     | MEWERKSTCKNR       |
| K2332 | 工件名称               | Work  piece Description                  |                                          | TRUE  | A    | MERKMAL     | MEWERKSTCKTEXT     |
| K2333 | 工件编号               | Work  piece Number                       |                                          | TRUE  | I5   | MERKMAL     | MEWERKSTCK         |
| K2341 | 检验计划编号             | Test  Plan Number                        |                                          | TRUE  | A    | MERKMAL     | MEPPLANNRT         |
| K2342 | 检验计划名称             | Test  Plan Name                          |                                          | TRUE  | A    | MERKMAL     | MEPPLAN            |
| K2343 | 检验计划编制日期           | Test  Plan Development Date              |                                          | TRUE  | D    | MERKMAL     | MEPPLANDAT         |
| K2344 | 检验计划编制者            | Test  Plan Developer                     |                                          | TRUE  | A    | MERKMAL     | MEPPLANERST        |
| K2401 | 检具编号               | Gage  Number                             | or  K1201 / K0012                        | TRUE  | A    | MERKMAL     | MEPRUEFMITNRT      |
| K2402 | 检具名称               | Gage  Description                        | or  K1202 / K0012                        | TRUE  | A    | MERKMAL     | MEPRUEFMITT        |
| K2403 | 检具组                | Gage  Group                              |                                          | TRUE  | A    | MERKMAL     | MEPMGRUPPET        |
| K2404 | 检具精度               | Gage  Resolution                         |                                          | TRUE  | F    | MERKMAL     | MEPMAUFLOES        |
| K2405 | 检具编号               | Gage  Number                             |                                          | TRUE  | I5   | MERKMAL     | MEPRUEFMIT         |
| K2406 | 检具制造商              | Gage  Manufacturer                       |                                          | TRUE  | A    | MERKMAL     | MEPMHERST          |
| K2407 | SPC-设备编号           | SPC  device number                       |                                          | TRUE  | A    | MERKMAL     | MESPCNR            |
| K2408 | SPC-设备制造商          | SPC  device manufacturer                 | if  A20 is used instead of A40, match field length in DB | TRUE  | A    | MERKMAL     | MESPCHERST         |
| K2409 | SPC-设备-型号          | SPC  device type                         |                                          | TRUE  | A    | MERKMAL     | MESPCTYP           |
| K2410 | 检验地点               | Test  Location                           |                                          | TRUE  | A    | MERKMAL     | MEPRUEFORTT        |
| K2411 | 检验开始               | Test  Begin                              |                                          | TRUE  | D    | MERKMAL     | MEPRUEFBEGINN      |
| K2412 | 检验结束               | Test  End                                |                                          | TRUE  | D    | MERKMAL     | MEPRUEFENDE        |
| K2415 | 检具系列号              | Gage  serial number                      |                                          | TRUE  | A    | MERKMAL     | MEPRUEFMITSERNR    |
| K2416 | 显示仪                | Display                                  |                                          | TRUE  | A    | MERKMAL     | MEANZGERAET        |
| K2421 | 检验员编号              | Operator  Number                         |                                          | TRUE  | A    | MERKMAL     | MEPRUEFERNR        |
| K2422 | 检验员名称              | Operator  Name                           |                                          | TRUE  | A    | MERKMAL     | MEPRUEFERNAME      |
| K2423 | 检验员编号              | Operator  Number                         |                                          | TRUE  | I5   | MERKMAL     | MEPRUEFER          |
| K2800 | 用户域名称  1           | user  field description 1                | no  selectionfield                       | TRUE  | A    | MZ          | ME_2646            |
| K2801 | 用户域类型  1           | user  field type 1                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2802 | 用户域内容  1           | user  field contents 1                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2810 | 用户域名称  2           | user  field description 2                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2811 | 用户域类型  2           | user  field type 2                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2812 | 用户域内容  2           | user  field contents 2                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2820 | 用户域名称  3           | user  field description 3                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2821 | 用户域类型  3           | user  field type 3                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2822 | 用户域内容  3           | user  field contents 3                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2830 | 用户域名称  4           | user  field description 4                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2831 | 用户域类型  4           | user  field type 4                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2832 | 用户域内容  4           | user  field contents 4                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2840 | 用户域名称  5           | user  field description 5                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2841 | 用户域类型  5           | user  field type 5                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2842 | 用户域内容  5           | user  field contents 5                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2850 | 用户域名称  6           | user  field description 6                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2851 | 用户域类型  6           | user  field type 6                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2852 | 用户域内容  6           | user  field contents 6                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2860 | 用户域名称  7           | user  field description 7                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2861 | 用户域类型  7           | user  field type 7                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2862 | 用户域内容  7           | user  field contents 7                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2870 | 用户域名称  8           | user  field description 8                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2871 | 用户域类型  8           | user  field type 8                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2872 | 用户域内容  8           | user  field contents 8                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2880 | 用户域名称  9           | user  field description 9                | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2881 | 用户域类型  9           | user  field type 9                       | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2882 | 用户域内容  9           | user  field contents 9                   | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2890 | 用户域名称  10          | user  field description 10               | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2891 | 用户域类型  10          | user  field type 10                      | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2892 | 用户域内容  10          | user  field contents 10                  | no  selectionfield                       | TRUE  | A    | MEMO_FIELDS | MM_CONTENTS        |
| K2900 | 说明                 | Remark                                   |                                          | TRUE  | A    | MERKMAL     | MEBEMERK           |
| K2901 | 检验条件               | Test  Conditions                         | within  Measurement System Analysis saving of test conditions in text form | TRUE  | A    | MERKMAL     | MEPRUEFBEDING      |
| K2998 | 内部的  qs-STAT 设置    | internal  qs-STAT configuration          |                                          | TRUE  | A    | MERKMAL     | MEKONFIG           |
| K8006 | 下报警界限(位置)          | lo.  alarm lim. (location)               |                                          | TRUE  | F    | EG_AEND     | EGLAGUIG           |
| K8007 | 上报警界限(位置)          | up.  alarm lim. (location)               |                                          | TRUE  | F    | EG_AEND     | EGLAGOIG           |
| K8010 | 控制图类型  (位置)        | Chart  Type (Loc)                        | defined  field content                   | TRUE  | S    | EG_AEND     | EGLAGART           |
| K8011 | 中间位置  (位置)         | Central  Position (Loc)                  |                                          | TRUE  | F    | EG_AEND     | EGLAGMITTE         |
| K8012 | 下控制界限  (位置)        | lower  Control Limit (Loc)               |                                          | TRUE  | F    | EG_AEND     | EGLAGUEG           |
| K8013 | 上控制界限  (位置)        | upper  Control Limit (Loc)               |                                          | TRUE  | F    | EG_AEND     | EGLAGOEG           |
| K8014 | 下警告界限  (位置)        | lower  Warning Limit (Loc)               |                                          | TRUE  | F    | EG_AEND     | EGLAGUWG           |
| K8015 | 上警告界限  (位置)        | upper  Warning Limit (Loc)               |                                          | TRUE  | F    | EG_AEND     | EGLAGOWG           |
| K8110 | 控制图类型(变动)          | Chart  Type (Variation)                  | defined  field content                   | TRUE  | S    | EG_AEND     | EGSTRART           |
| K8111 | 中间位置(变动)           | Central  Position (Variation)            |                                          | TRUE  | F    | EG_AEND     | EGSTRMITTE         |
| K8112 | 下控制界限(变动)          | lower  Control lim. (Variation)          |                                          | TRUE  | F    | EG_AEND     | EGSTRUEG           |
| K8113 | 上控制界限(变动)          | upper  Control Limit (Variation)         |                                          | TRUE  | F    | EG_AEND     | EGSTROEG           |
| K8114 | 下警告界限(变动)          | lower  Warning Limit (Variation)         |                                          | TRUE  | F    | EG_AEND     | EGSTRUWG           |
| K8115 | 上警告界限(变动)          | upper  Warning Limit (Variation)         |                                          | TRUE  | F    | EG_AEND     | EGSTROWG           |
| K8500 | 子组容量               | Subgroup  size                           |                                          | TRUE  | I5   | MERKMAL     | MEUMFPROZ          |
| K8501 | 子组类型               | Subgroup  type                           | defined  field content fixed, floating   | TRUE  | I3   | MERKMAL     | MEGLEITSTUMF       |
| K8502 | 抽检频率               | Subgroup  frequency                      | text  indication of frequency            | TRUE  | A    | MERKMAL     | MESTIFREQT         |
| K8503 | 恒定的子组容量            | stable  subgroup size                    | only  for inspection by attributes       | TRUE  | I3   | MERKMAL     | METRANSART         |
| K8504 | 抽检频率               | Subgroup  incidence                      |                                          | TRUE  | I5   | MERKMAL     | MESTIFREQ          |
| K8520 | 要求的  Cp-值          | required  Cp value                       | VDA  5                                   | TRUE  | F    | MERKMAL     | MEVORGCP           |
| K8521 | 要求的  Cpk-值         | required  Cpk value                      |                                          | TRUE  | F    | MERKMAL     | MEVORGCPK          |
| K8522 | 固定的Cp-值            | fixed  Cp value                          |                                          | TRUE  | F    | MERKMAL     | MECPFIX            |
| K8523 | 固定的Cpk-值           | fixed  Cpk value                         |                                          | TRUE  | F    | MERKMAL     | MECPKFIX           |
| K8600 | 修正的策略              | Correction  Strategy                     | number  of values which can be recorded in a buffer / moving register with start of  machine | TRUE  | I3   | MERKMAL     | MEKORRSTRAT        |
| K8610 | 下修正界限              | lower  Correction Limit                  | number  of values which can be recorded in a buffer / moving register with start of  machine | TRUE  | F    | MERKMAL     | MEUKG              |
| K8611 | 上修正界限              | upper  Correction Limit                  | number  of values which can be recorded in a buffer / moving register with start of  machine | TRUE  | F    | MERKMAL     | MEOKG              |
| K8612 | 缓冲器大小              | Buffer  size                             | number  of values which can be recorded in a buffer / moving register with start of  machine | TRUE  | I3   | MERKMAL     | MEPUFFERSIZE       |
| K8613 | 修正目标值              | Correction target value                  | number of values which can be  recorded in a buffer / moving register with start of machine | TRUE  | F    | MERKMAL     | MEKORRZIEL         |