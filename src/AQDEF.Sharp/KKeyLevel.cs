using System;

namespace AQDEF.Sharp {
    [Flags]
    public enum KKeyLevel {
        /// <summary>
        /// �������� (Part Data)
        /// </summary>
        Part,
        /// <summary>
        /// �������� (Characteristic Data)
        /// </summary>
        Characteristic,
        /// <summary>
        /// ����ֵ
        /// </summary>
        VALUE,
        /// <summary>
        /// �Զ��岿��
        /// </summary>
        CUSTOM_PART,
        /// <summary>
        /// �Զ�������
        /// </summary>
        CUSTOM_CHARACTERISTIC,
        /// <summary>
        /// �Զ������ֵ
        /// </summary>
        CUSTOM_VALUE,
        /// <summary>
        /// 
        /// </summary>
        GROUP,
        HIERARCHY,
        SIMPLE_HIERARCHY,
        CATALOG,
        UNKNOWN
    }
}