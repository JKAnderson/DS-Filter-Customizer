namespace DS_Filter_Customizer
{
    class DSOffsets
    {
        public const int CheckVersion = 0x400080;

        public int CharData1Ptr = 0x137DC70;
        public int CharData1Ptr2 = 0x4;
        public int CharData1Ptr3 = 0x0;

        public int GraphicsDataPtr = 0x1378520;
        public int GraphicsDataPtr2 = 0x10;
        public enum GraphicsData
        {
            EnableFilter = 0x26D,
            BrightnessR = 0x270,
            BrightnessG = 0x274,
            BrightnessB = 0x278,
            Saturation = 0x27C,
            ContrastR = 0x280,
            ContrastG = 0x284,
            ContrastB = 0x288,
            Hue = 0x28C,
        }

        public int Unknown1Ptr = 0x137E204;
        public enum Unknown1
        {
            World = 0xA13,
        }

        public int Unknown5Ptr = 0x13783C0;
        public int Unknown5Ptr2 = 0x6F8;
        public enum Unknown5
        {
            Filter = 0x172,
        }

        public static DSOffsets Release = new DSOffsets();
        public static DSOffsets Debug = new DSOffsets()
        {
            CharData1Ptr = 0x1381E30,
            GraphicsDataPtr = 0x137C6E0,
            Unknown1Ptr = 0x13823C4,
            Unknown5Ptr = 0x137C580,
        };
    }
}
