﻿using CIMComponent;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using System.Net;
using System.Reflection;
using System.Text;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public static class Extensions
    {
        internal static bool Open(this clsMCE71Interface mcIF, McInterfaceOptions mc_internface_options, out int retCode, clsMC_TCPCnt.enuDataType enuDataType = clsMC_TCPCnt.enuDataType.ByteArr_02)
        {
            retCode = mcIF.Open(mc_internface_options.RemoteIP, mc_internface_options.RemotePort, mc_internface_options.T_ConnectTimeout, mc_internface_options.T_MessageTimeout
                , enuDataType);
            return retCode == 0;
        }
        internal static void SetMemoryStart(this MemoryTable memTable, string bitStartAddress, string wordStartAddress)
        {
            bitStartAddress.SplitAddress(true, out string bitRegionName, out int address, out string addressStr);
            string bitStartAddress_Num = addressStr.ToString();
            wordStartAddress.SplitAddress(true, out string wordRegionName, out address, out addressStr);
            string wordStartAddress_Num = addressStr.ToString();
            memTable.SetMemoryStart(bitRegionName, bitStartAddress_Num, wordRegionName, wordStartAddress_Num);
        }

        internal static void GetMemoryAddressList(this clsMemoryGroupOptions memoryGroupOptions, out List<clsMemoryAddress> bitAddressList, out List<clsMemoryAddress> wordAddressList)
        {
            var memoryTable = memoryGroupOptions.memoryTable;
            bitAddressList = new List<clsMemoryAddress>();
            foreach (var Address in memoryGroupOptions.bitAddresList)
            {
                bool bitVal = memoryTable.ReadOneBit(Address);
                bitAddressList.Add(new clsMemoryAddress(clsMemoryAddress.DATA_TYPE.BIT)
                {
                    Address = Address,
                    Value = bitVal
                });
            }
            wordAddressList = new List<clsMemoryAddress>();
            foreach (var Address in memoryGroupOptions.wordAddresList)
            {
                int wordVal = memoryTable.ReadBinary(Address);
                wordAddressList.Add(new clsMemoryAddress(clsMemoryAddress.DATA_TYPE.WORD)
                {
                    Address = Address,
                    Value = wordVal
                });
            }
        }


        internal static int ReadMemory(this clsMCE71Interface mcIF, clsMemoryGroupOptions memoryGroupOptions, out string errMsg)
        {
            errMsg = string.Empty;
            //string bitRegionName = memoryGroupOptions.bitStartAddress.Substring(0, 1);
            memoryGroupOptions.bitStartAddress.SplitAddress(true, out string bitRegionName, out int bitStartAddressNum, out string addressNumtStr);
            memoryGroupOptions.bitEndAddress.SplitAddress(true, out _, out int bitEndAddressNum, out addressNumtStr);
            string bitStartAddress_Num = memoryGroupOptions.bitStartAddress.Replace(bitRegionName, "");


            memoryGroupOptions.wordStartAddress.SplitAddress(true, out string wordRegionName, out int wordStartAddressNum, out addressNumtStr);
            memoryGroupOptions.wordEndAddress.SplitAddress(true, out _, out int wordEndAddressNum, out addressNumtStr);
            string wordStartAddress_Num = memoryGroupOptions.wordStartAddress.Replace(wordRegionName, "");

            int bits_size = bitEndAddressNum - bitStartAddressNum + 1;
            int words_size = wordEndAddressNum - wordStartAddressNum + 1;
            var reccode = -1;
            try
            {
                reccode = mcIF.ReadBit(ref memoryGroupOptions.memoryTable, bitRegionName, bitStartAddress_Num, bits_size);
                if (reccode != 0)
                {

                }
                reccode = mcIF.ReadWord(ref memoryGroupOptions.memoryTable, wordRegionName, wordStartAddress_Num, words_size);
                if (reccode != 0)
                {

                }
                return reccode;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return 4444;
            }
        }

        internal static void SplitAddress(this string address, bool isHex, out string regionName, out int addressNum, out string addressStr)
        {
            try
            {
                char ss = address.First(chr => int.TryParse(chr.ToString(), out int _v));
                var indexEndOfWordRegName = address.IndexOf(ss);
                regionName = address.Substring(0, indexEndOfWordRegName);
                var addressNumStr = address.Substring(regionName.Length, address.Length - regionName.Length);
                if (!isHex)
                    addressNum = int.Parse(addressNumStr);
                else
                    addressNum = int.Parse(addressNumStr, System.Globalization.NumberStyles.HexNumber);
                addressStr = addressNumStr;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal static void TrySetPropertyValue(this object aimObj, string propertyName, object value, out bool ValueChanged)
        {
            ValueChanged = false;
            if (propertyName == "")
                return;

            PropertyInfo? propertyInfo = aimObj.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
                return;
            object oriVal = propertyInfo.GetValue(aimObj);
            if (value.GetType().Name == typeof(int).Name)
                propertyInfo?.SetValue(aimObj, (int)value);
            if (value.GetType().Name == typeof(bool).Name)
                propertyInfo?.SetValue(aimObj, (bool)value);
            object newVal = propertyInfo.GetValue(aimObj);
            ValueChanged = oriVal.ToString() != newVal.ToString();
            if (ValueChanged)
            {

            }
        }

        public static string ToASCII(this IEnumerable<int> words)
        {
            var bb = words.SelectMany(_int => new ArraySegment<byte>(BitConverter.GetBytes(_int), 0, 2).Select(b => b));
            return Encoding.ASCII.GetString(bb.ToArray());
        }

        public static int[] ToASCIIWords(this string input)
        {
            var strLen = input.Length;
            if (strLen != 10)
            {
                //ABC123 12-6=6
                for (int i = 0; i < 10 - strLen; i++)
                {
                    input += " ";
                }
            }
            List<ushort> result = new List<ushort> { };
            for (int i = 0; i < input.Length; i += 2)
            {
                ushort char1 = i < input.Length ? (ushort)input[i] : (ushort)0;
                ushort char2 = i + 1 < input.Length ? (ushort)input[i + 1] : (ushort)0;
                // char1 占低 8 位，char2 占高 8 位
                ushort combined = (ushort)(char2 << 8 | char1);
                //result[i / 2 * 2] = (ushort)(combined & 0xFF);         // 低位字节
                //result[i / 2 * 2 + 1] = (ushort)((combined >> 8) & 0xFF); // 高位字节
                result.Add(combined);
            }
            var ret = result.Select(s => Convert.ToInt32(s)).ToArray();
            var outputs = new int[10];
            Array.Copy(ret, 0, outputs, 0, ret.Length);
            return outputs;
        }


        public static IO_MODE ToIOMODE(this string mode_int_str)
        {
            if (mode_int_str == null)
                return IO_MODE.Unknown;
            if (mode_int_str == "0")
                return IO_MODE.FromIOModule;
            else if (mode_int_str == "1")
                return IO_MODE.FromCIMSimulation;
            else
                return IO_MODE.Unknown;
        }

    }
}
