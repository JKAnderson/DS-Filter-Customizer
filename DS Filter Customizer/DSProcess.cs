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

        private const uint VERSION_RELEASE = 0xFC293654;
        private const uint VERSION_DEBUG = 0xCE9634B4;
        private const uint VERSION_BETA = 0xE91B11E2;

        public static DSProcess GetProcess()
        {
            DSProcess result = null;
            Process[] candidates = Process.GetProcessesByName("DARKSOULS");
            foreach (Process candidate in candidates)
            {
                if (result == null)
                    result = new DSProcess(candidate);
            }
            return result;
        }


        private readonly Process process;
        private readonly DSInterface dsInterface;
        private readonly DSOffsets offsets;

        public readonly int ID;
        public readonly string Version;
        public readonly bool Valid;

        public DSProcess(Process candidate)
        {
            process = candidate;
            ID = process.Id;
            dsInterface = DSInterface.Attach(process);
            switch (dsInterface?.ReadUInt32(DSOffsets.CheckVersion))
            {
                case VERSION_RELEASE:
                    Version = "Steam";
                    offsets = DSOffsets.Release;
                    Valid = true;
                    break;
                case VERSION_DEBUG:
                    Version = "Debug";
                    offsets = DSOffsets.Debug;
                    Valid = true;
                    break;
                case VERSION_BETA:
                    Version = "Beta";
                    Valid = false;
                    break;
                default:
                    Version = "Unknown";
                    Valid = false;
                    break;
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
