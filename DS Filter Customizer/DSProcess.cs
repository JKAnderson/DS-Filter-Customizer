using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DS_Filter_Customizer
{
    class DSProcess
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static DSProcess GetProcess()
        {
            DSProcess result = null;
            Process[] candidates = Process.GetProcessesByName("DARKSOULS");
            if (candidates.Length > 0)
                result = new DSProcess(candidates[0]);
            return result;
        }


        private readonly Process process;
        private readonly DSInterface dsInterface;
        private readonly DSOffsets offsets;

        public int ID { get; private set; }
        public string Version { get; private set; }
        public bool Valid { get; private set; }

        public DSProcess(Process candidate)
        {
            process = candidate;
            ID = process.Id;
            Version = "Unknown";
            Valid = false;

            dsInterface = DSInterface.Attach(process);
            if (dsInterface != null)
            {
                uint versionValue = dsInterface.ReadUInt32(DSOffsets.CheckVersion);
                if (DSOffsets.Versions.ContainsKey(versionValue))
                {
                    Version = DSOffsets.Versions[versionValue].Name;
                    offsets = DSOffsets.Versions[versionValue].Offsets;
                    Valid = offsets != null;
                }
            }
        }

        public void Close()
        {
            dsInterface.Close();
        }

        public bool Alive()
        {
            return !process.HasExited;
        }

        public bool Loaded()
        {
            return Valid && getCharData1() != 0;
        }

        public bool Focused()
        {
            IntPtr hwnd = GetForegroundWindow();
            GetWindowThreadProcessId(hwnd, out uint pid);
            return pid == process.Id;
        }

        #region Pointer loading
        private struct DSPointers
        {
            public int GraphicsData, Unknown1, Unknown5;
        }
        private DSPointers pointers;

        public void LoadPointers()
        {
            int pointer = dsInterface.ReadInt32(offsets.GraphicsDataPtr);
            pointers.GraphicsData = dsInterface.ReadInt32(pointer + offsets.GraphicsDataPtr2);

            pointers.Unknown1 = dsInterface.ReadInt32(offsets.Unknown1Ptr);

            pointer = dsInterface.ReadInt32(offsets.Unknown5Ptr);
            pointers.Unknown5 = dsInterface.ReadInt32(pointer + offsets.Unknown5Ptr2);
        }

        // Used to check if game is loaded
        private int getCharData1()
        {
            int pointer = dsInterface.ReadInt32(offsets.CharData1Ptr);
            pointer = dsInterface.ReadInt32(pointer + offsets.CharData1Ptr2);
            return dsInterface.ReadInt32(pointer + offsets.CharData1Ptr3);
        }
        #endregion

        public int GetWorld()
        {
            return dsInterface.ReadByte(pointers.Unknown1 + (int)DSOffsets.Unknown1.World);
        }

        public int GetFilter()
        {
            return dsInterface.ReadByte(pointers.Unknown5 + (int)DSOffsets.Unknown5.Filter);
        }

        public void OverrideFilter(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.EnableFilter, enable);
        }

        public void SetBrightness(float brightnessR, float brightnessG, float brightnessB)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessR, brightnessR);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessG, brightnessG);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessB, brightnessB);
        }

        public void SetContrast(float contrastR, float contrastG, float contrastB)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastR, contrastR);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastG, contrastG);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastB, contrastB);
        }

        public void SetSaturation(float saturation)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.Saturation, saturation);
        }

        public void SetHue(float hue)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.Hue, hue);
        }
    }
}
