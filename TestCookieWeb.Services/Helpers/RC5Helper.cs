using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Services.Helpers
{
    public class RC5Helper
    {
        public static string HashMes(string Message)
        {
            byte[] TaskArr = MD5_Step2(MD5_Step1(StringToByteArr(Message)), Message.Length);
            uint[] TaskIntArr = ByteArrToIntArr(TaskArr);
            return MD5_Step3_4(TaskIntArr, GenerateTable(), GenerateShifting());
        }

        public static bool VerifyHash(string HashMessage, string Message)
        {
            byte[] TaskArr = MD5_Step2(MD5_Step1(StringToByteArr(Message)), Message.Length);
            uint[] TaskIntArr = ByteArrToIntArr(TaskArr);
            string ResultMessageHash = MD5_Step3_4(TaskIntArr, GenerateTable(), GenerateShifting());
            if (HashMessage == ResultMessageHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Перетворення стрічки в масив байтів
        private static byte[] StringToByteArr(string mes)
        {
            byte[] ReturnRez = new byte[mes.Length];
            for (int i = 0; i < mes.Length; i++)
            {
                ReturnRez[i] = (byte)mes[i];
            }
            return ReturnRez;
        }
        //Доповнення масиву до розміру 448 + 512... 
        //Доповнення спочатку 1 і до кінця 0
        private static byte[] MD5_Step1(byte[] mes)
        {
            byte[] ReturnRez = new byte[mes.Length + FindSize(mes.Length * 8)];
            mes.CopyTo(ReturnRez, 0);
            ReturnRez[mes.Length] = 0x80;
            for (int i = mes.Length + 1; i < ReturnRez.Length; i++)
            {
                ReturnRez[i] = 0;
            }
            return ReturnRez;

        }
        //Дописування розміру повідомлення в бітах в останні 8 байт (64 біт)
        private static byte[] MD5_Step2(byte[] mes, int meslen)
        {
            byte[] ReturnRez = new byte[mes.Length + 8];
            //к-сть бітів у повідомленні !!!!!!!
            byte[] Len = BitConverter.GetBytes(meslen * 8);
            mes.CopyTo(ReturnRez, 0);
            Len.CopyTo(ReturnRez, mes.Length);
            return ReturnRez;
        }
        //Ініціалізація 128 бітного буфера
        //Розділення повідомлення на блоки по 512 біт і потім по 32 біт 
        //Виконання 4 циклів по 16 раундів операцій not, xor, or, and, циклічного зсуву, додавання блоку повідомлення і матриці синусів
        private static string MD5_Step3_4(uint[] Mes, uint[] Table, int[] ShiftingArr)
        {
            uint Reg_A = 0x67452301;
            uint Reg_B = (uint)0xEFCDAB89L;
            uint Reg_C = (uint)0x98BADCFEL;
            uint Reg_D = 0x10325476;

            for (int j = 0; j < Mes.Length; j += 16)
            {
                uint[] Temp_Mes = new uint[16];
                for (int t = j; t < j + 16; t++)
                {
                    Temp_Mes[t % 16] = Mes[t];
                }
                uint Temp_A = Reg_A;
                uint Temp_B = Reg_B;
                uint Temp_C = Reg_C;
                uint Temp_D = Reg_D;
                uint Temp_F = 0;
                int Temp_K = 0;
                for (int i = 0; i < 64; i++)
                {
                    if (i >= 0 && i < 16)
                    {
                        Temp_F = (Temp_B & Temp_C) | (~Temp_B & Temp_D);
                        Temp_K = i;
                    }
                    if (i >= 16 && i < 32)
                    {
                        Temp_F = (Temp_B & Temp_D) | (Temp_C & ~Temp_D);
                        Temp_K = (5 * i + 1) % 16;
                    }
                    if (i >= 32 && i < 48)
                    {
                        Temp_F = Temp_B ^ Temp_C ^ Temp_D;
                        Temp_K = (3 * i + 5) % 16;
                    }
                    if (i >= 48 && i < 64)
                    {
                        Temp_F = Temp_C ^ (Temp_B | ~Temp_D);
                        Temp_K = (7 * i) % 16;
                    }
                    Temp_F = Temp_F + Temp_A + Temp_Mes[Temp_K] + Table[i];
                    Temp_A = Temp_D;
                    Temp_D = Temp_C;
                    Temp_C = Temp_B;
                    Temp_B += (Shifting(Temp_F, ShiftingArr[i]));
                }
                Reg_A += Temp_A;
                Reg_B += Temp_B;
                Reg_C += Temp_C;
                Reg_D += Temp_D;
            }
            byte[] RezArr = new byte[16];
            byte[] PartArr = BitConverter.GetBytes(Reg_A);
            PartArr.CopyTo(RezArr, 0);
            PartArr = BitConverter.GetBytes(Reg_B);
            PartArr.CopyTo(RezArr, 4);
            PartArr = BitConverter.GetBytes(Reg_C);
            PartArr.CopyTo(RezArr, 8);
            PartArr = BitConverter.GetBytes(Reg_D);
            PartArr.CopyTo(RezArr, 12);

            return BitConverter.ToString(RezArr);
        }

        //Знаходження кількості байт потрібних для додавнання до масиву на кроці 1
        private static int FindSize(int len)
        {
            int start = 448;
            while (len >= start)
            {
                start += 512;
            }
            int rez = (start - len) / 8;
            return rez;
        }
        //Перетворення масиву байт в масив 32 бітних значень uint для роботи із буфером на кроці 4
        private static uint[] ByteArrToIntArr(byte[] mes)
        {
            uint[] ReturnRez = new uint[mes.Length / 4];
            for (int i = 0; i < ReturnRez.Length; i++)
            {
                ReturnRez[i] = BitConverter.ToUInt32(mes, i * 4);
            }
            return ReturnRez;
        }
        //Генерація таблиці синусів
        private static uint[] GenerateTable()
        {
            uint[] Table_T = new uint[64];
            for (int i = 0; i < 64; i++)
            {
                Table_T[i] = (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)));
            }
            return Table_T;
        }
        //Циклічний зсув
        private static uint Shifting(uint num, int shift)
        {
            uint j = (num << shift) | num >> (32 - shift);
            return j;
        }
        //Значення циклічного зсуву для кожного раунду в циклах
        private static int[] GenerateShifting()
        {
            int[] ShiftingArr = { 7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,
                                  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,
                                  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,
                                  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };
            return ShiftingArr;
        }
    }
}
