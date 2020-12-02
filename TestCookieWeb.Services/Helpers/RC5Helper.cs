using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCookieWeb.Services.Helpers
{
    public class RC5Helper
    {
        public static string HashMes(string Message)
        {
            string Result = RC5_Init_Enc(Message, 12, MD5_Algo("abcdefghijklmnop"));
            //byte[] TaskArr = MD5_Step2(MD5_Step1(StringToByteArr(Message)), Message.Length);
            //uint[] TaskIntArr = ByteArrToIntArr(TaskArr);
            return Result;
        }

        public static bool VerifyHash(string HashMessage, string Message)
        {
            //byte[] TaskArr = MD5_Step2(MD5_Step1(StringToByteArr(Message)), Message.Length);
            //uint[] TaskIntArr = ByteArrToIntArr(TaskArr);
            //string ResultMessageHash = MD5_Step3_4(TaskIntArr, GenerateTable(), GenerateShifting());
            string Result = RC5_Init_Enc(Message, 12, MD5_Algo("abcdefghijklmnop"));
            if (HashMessage == Result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetStartMes(string Message)
        {
            string Result = RC5_Init_Dec(Message, 12, MD5_Algo("abcdefghijklmnop"));
            return Result;
        }
        public static string[] UserMes;
        public static string[] InitVecMes;
        public static string PassKeyPhrase = "abcdefghijklmnop";

        public static string[] EncBtn()
        {
            string PassPhrase = "abcdefghijklmnop";
            string[] RetStrArr = new string[UserMes.Length];
            UInt64[] Vec = new UInt64[2] { 123456, 654321 }/*RandFunc((UInt64)(UserMes.Length * 2))*/;
            for (int i = 0; i < UserMes.Length; i++)
            {
                UInt64[] Tmp_Vec = new UInt64[2];
                Tmp_Vec[0] = Vec[i * 2];
                Tmp_Vec[1] = Vec[i * 2 + 1];
                string teststr = UserMes[i].Replace("\n", "").Replace("\r", "");
                RetStrArr[i] = RC5_Algo_Enc(teststr, 12, MD5_Algo(PassPhrase), Tmp_Vec);
                UserMes[i] = RetStrArr[i].Replace("-", "");
            }
            InitVecMes = new string[Vec.Length];
            for (int j = 0; j < Vec.Length; j++)
            {
                InitVecMes[j] = RC5_Init_Enc(Vec[j].ToString(), 12, MD5_Algo(PassPhrase));
            }
            return RetStrArr;
        }

        public static string[] DecBtn()
        {
            string PassPhrase = "abcdefghijklmnop";
            string[] RetStrArr = new string[UserMes.Length];
            UInt64[] Vec = new UInt64[InitVecMes.Length];
            for (int j = 0; j < InitVecMes.Length; j++)
            {
                string tmp = InitVecMes[j].Replace("\n", "").Replace("\r", "");
                Vec[j] = Convert.ToUInt64(RC5_Init_Dec(tmp, 12, MD5_Algo(PassPhrase)));
            }
            for (int i = 0; i < UserMes.Length; i++)
            {
                UInt64[] Tmp_Vec = new UInt64[2];
                Tmp_Vec[0] = Vec[i * 2];
                Tmp_Vec[1] = Vec[i * 2 + 1];
                string teststr = UserMes[i].Replace("\n", "").Replace("\r", "");
                RetStrArr[i] = RC5_Algo_Dec(teststr, 12, MD5_Algo(PassPhrase), Tmp_Vec);
            }
            return RetStrArr;
        }
        //Підготовка повідомлення і подальше шифрування 
        public static string RC5_Algo_Enc(string Mes, int RoundCount, byte[] Key, UInt64[] Init)
        {
            UInt64[] Key_S = KeyEncryption(RoundCount, Key);
            byte[] ByteArr = StringToByteArr(Mes);
            byte[] FilledMes;
            if (ByteArr.Length % 16 != 0)
            {
                FilledMes = FillMesLength(ByteArr);
            }
            else
            {
                FilledMes = new byte[ByteArr.Length];
                ByteArr.CopyTo(FilledMes, 0);
            }
            byte[] EncCBCArr = RC5_CBC_Encryption(FilledMes, 12, Key_S, Init);
            return BitConverter.ToString(EncCBCArr)/*.Replace("-", "")*/;
            //WriteInFile(DestFile.Text.ToString(), BitConverter.ToString(EncCBCArr).Replace("-", ""));
        }
        //Дешифрування повідомлення і його відновлення
        public static string RC5_Algo_Dec(string Mes, int RoundCount, byte[] Key, UInt64[] Init)
        {
            UInt64[] Key_S = KeyEncryption(RoundCount, Key);
            byte[] ByteArr = HexStringToByteArray(Mes);
            byte[] FilledMes;
            if (ByteArr.Length % 16 != 0)
            {
                FilledMes = FillMesLength(ByteArr);
            }
            else
            {
                FilledMes = new byte[ByteArr.Length];
                ByteArr.CopyTo(FilledMes, 0);
            }
            byte[] DesCBCArr = RC5_CBC_Decryption(FilledMes, 12, Key_S, Init);
            byte[] Rez = ReturnStartMes(DesCBCArr);
            return Encoding.UTF8.GetString(Rez, 0, Rez.Length);
            // WriteInFile(DestFile.Text.ToString(), Encoding.UTF8.GetString(Rez, 0, Rez.Length));
        }

        //Шифрування вектора ініціалізації
        public static string RC5_Init_Enc(string Mes, int RoundCount, byte[] Key)
        {
            UInt64[] Key_S = KeyEncryption(RoundCount, Key);
            byte[] ByteArr = StringToByteArr(Mes);
            byte[] FilledMes;
            if (ByteArr.Length % 16 != 0)
            {
                FilledMes = FillMesLength(ByteArr);
            }
            else
            {
                FilledMes = new byte[ByteArr.Length];
                ByteArr.CopyTo(FilledMes, 0);
            }
            byte[] EncECBArr = RC5_ECB_Encryption(FilledMes, 12, Key_S);
            //WriteInFile(InitFile.Text.ToString(), BitConverter.ToString(EncECBArr).Replace("-", ""));
            return BitConverter.ToString(EncECBArr).Replace("-", "");
        }

        //Дешифрування вектора ініціалізації
        public static string RC5_Init_Dec(string Mes, int RoundCount, byte[] Key)
        {
            UInt64[] Key_S = KeyEncryption(RoundCount, Key);
            byte[] ByteArr = HexStringToByteArray(Mes);
            byte[] FilledMes;
            if (ByteArr.Length % 16 != 0)
            {
                FilledMes = FillMesLength(ByteArr);
            }
            else
            {
                FilledMes = new byte[ByteArr.Length];
                ByteArr.CopyTo(FilledMes, 0);
            }
            byte[] DesECBArr = RC5_ECB_Decryption(FilledMes, 12, Key_S);
            byte[] Rez = ReturnStartMes(DesECBArr);
            string test = Encoding.UTF8.GetString(Rez, 0, Rez.Length);
            return test;// Convert.ToUInt64(test);
        }

        //Перетворення стрічки у вигляді послідовності шістандцяткових величин у масив байтів
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        //Доповненя повідомлення до потрібної довжини
        public static byte[] FillMesLength(byte[] Mes)
        {
            if (Mes.Length % 16 != 0)
            {
                int AddedLength = 16 - (Mes.Length % 16);
                byte[] ReturnMes = new byte[Mes.Length + AddedLength];
                Mes.CopyTo(ReturnMes, 0);
                for (int i = Mes.Length; i < Mes.Length + AddedLength; i++)
                {
                    ReturnMes[i] = (byte)AddedLength;
                }
                return ReturnMes;
            }
            return Mes;
        }

        //Відновлення повідомлення відкиданням доповнених байтів
        public static byte[] ReturnStartMes(byte[] Mes)
        {
            int LenCnt = 0;
            byte Len = Mes[Mes.Length - 1];
            if (Len >= Mes.Length)
            {
                return Mes;
            }
            for (int i = Mes.Length - 1; i > Mes.Length - Len - 1; i--)
            {
                if (Mes[i] == Len)
                {
                    LenCnt++;
                }
            }
            if (LenCnt == Len)
            {
                byte[] RetMes = new byte[Mes.Length - Mes[Mes.Length - 1]];
                for (int i = 0; i < RetMes.Length; i++)
                {
                    RetMes[i] = Mes[i];
                }
                return RetMes;
            }
            return Mes;
        }

        //Знаходження підключів
        public static UInt64[] KeyEncryption(int RoundCount, byte[] Key)
        {
            int W = 64;
            int b = Key.Length;
            const UInt64 PW = 0xB7E151628AED2A6B;
            const UInt64 QW = 0x9E3779B97F4A7C15;

            int U = W / 8;
            int C = b / U;

            UInt64[] L = new UInt64[C];
            //Перетворення ключа в ноий масив
            int index = C - 1;
            for (int q = b - 1; q >= 0; q--)
            {
                L[index] = RC5LeftShifting(L[index], 8) + Key[q];
                if (q % 8 == 0)
                {
                    index--;
                }
            }

            //Ініціалізація масиву підключів S
            int t = 2 * (RoundCount + 1);
            UInt64[] S = new UInt64[t];
            S[0] = PW;
            for (int p = 1; p < t; p++)
            {
                S[p] = S[p - 1] + QW;
            }

            //Перемішування
            UInt64 Param_A = 0;
            UInt64 Param_B = 0;
            int i = 0;
            int j = 0;
            int n = 3 * Math.Max(t, C);

            for (int k = 0; k < n; k++)
            {
                Param_A = S[i] = RC5LeftShifting((S[i] + Param_A + Param_B), 3);
                Param_B = L[j] = RC5LeftShifting((L[j] + Param_A + Param_B), (int)(Param_A + Param_B));
                i = (i + 1) % t;
                j = (j + 1) % C;
            }
            return S;
        }

        //Шифрування rc5 в режимі ECB без вектора ініціалізації 
        public static byte[] RC5_ECB_Encryption(byte[] ByteArr, int RoundCount, UInt64[] KeyArr_S)
        {
            UInt64[] UintArr = ByteArrToInt64Arr(ByteArr);
            byte[] RezArr = new byte[UintArr.Length * 8];
            for (int i = 0; i < UintArr.Length; i += 2)
            {
                UInt64 Uint_A = UintArr[i];
                UInt64 Uint_B = UintArr[i + 1];
                Uint_A += KeyArr_S[0];
                Uint_B += KeyArr_S[1];

                for (int p = 1; p < RoundCount; p++)
                {
                    Uint_A = RC5LeftShifting((Uint_A ^ Uint_B), (int)Uint_B) + KeyArr_S[2 * p];
                    Uint_B = RC5LeftShifting((Uint_B ^ Uint_A), (int)Uint_A) + KeyArr_S[2 * p + 1];
                }

                BitConverter.GetBytes(Uint_A).CopyTo(RezArr, i * 8 + 0);
                BitConverter.GetBytes(Uint_B).CopyTo(RezArr, i * 8 + 8);
            }
            return RezArr;
        }

        //Дешифрування rc5 в режимі ECB без вектора ініціалізації
        public static byte[] RC5_ECB_Decryption(byte[] ByteArr, int RoundCount, UInt64[] KeyArr_S)
        {
            UInt64[] UintArr = ByteArrToInt64Arr(ByteArr);
            byte[] RezArr = new byte[UintArr.Length * 8];

            for (int i = 0; i < UintArr.Length; i += 2)
            {
                UInt64 Uint_A = UintArr[i];
                UInt64 Uint_B = UintArr[i + 1];

                for (int p = RoundCount - 1; p > 0; p--)
                {
                    Uint_B = RC5RightShifting(Uint_B - KeyArr_S[2 * p + 1], (int)Uint_A) ^ Uint_A;
                    Uint_A = RC5RightShifting(Uint_A - KeyArr_S[2 * p], (int)Uint_B) ^ Uint_B;
                }

                Uint_A -= KeyArr_S[0];
                Uint_B -= KeyArr_S[1];

                BitConverter.GetBytes(Uint_A).CopyTo(RezArr, i * 8 + 0);
                BitConverter.GetBytes(Uint_B).CopyTo(RezArr, i * 8 + 8);
            }
            return RezArr;
        }

        //Шифрування rc5 в режимі CBC-Pad із вектором ініціалізації 
        public static byte[] RC5_CBC_Encryption(byte[] ByteArr, int RoundCount, UInt64[] KeyArr_S, UInt64[] Init_Vec)
        {
            UInt64[] UintArr = ByteArrToInt64Arr(ByteArr);
            byte[] RezArr = new byte[UintArr.Length * 8];
            UInt64 Xor_A = Init_Vec[0];
            UInt64 Xor_B = Init_Vec[1];

            for (int i = 0; i < UintArr.Length; i += 2)
            {

                UInt64 Uint_A = UintArr[i];
                UInt64 Uint_B = UintArr[i + 1];
                Uint_A = Uint_A ^ Xor_A;
                Uint_B = Uint_B ^ Xor_B;
                Uint_A += KeyArr_S[0];
                Uint_B += KeyArr_S[1];

                for (int p = 1; p < RoundCount; p++)
                {
                    Uint_A = RC5LeftShifting((Uint_A ^ Uint_B), (int)Uint_B) + KeyArr_S[2 * p];
                    Uint_B = RC5LeftShifting((Uint_B ^ Uint_A), (int)Uint_A) + KeyArr_S[2 * p + 1];
                }

                Xor_A = Uint_A;
                Xor_B = Uint_B;

                BitConverter.GetBytes(Uint_A).CopyTo(RezArr, i * 8 + 0);
                BitConverter.GetBytes(Uint_B).CopyTo(RezArr, i * 8 + 8);
            }
            return RezArr;
        }

        //Дешифрування rc5 в режимі CBC-Pad із вектором ініціалізації
        public static byte[] RC5_CBC_Decryption(byte[] ByteArr, int RoundCount, UInt64[] KeyArr_S, UInt64[] Init_Vec)
        {
            UInt64[] UintArr = ByteArrToInt64Arr(ByteArr);
            byte[] RezArr = new byte[UintArr.Length * 8];
            UInt64 Xor_A = Init_Vec[0];
            UInt64 Xor_B = Init_Vec[1];

            for (int i = 0; i < UintArr.Length; i += 2)
            {
                UInt64 Uint_A = UintArr[i];
                UInt64 Uint_B = UintArr[i + 1];
                UInt64 Tmp_Uint_A = Uint_A;
                UInt64 Tmp_Uint_B = Uint_B;

                for (int p = RoundCount - 1; p > 0; p--)
                {
                    Uint_B = RC5RightShifting(Uint_B - KeyArr_S[2 * p + 1], (int)Uint_A) ^ Uint_A;
                    Uint_A = RC5RightShifting(Uint_A - KeyArr_S[2 * p], (int)Uint_B) ^ Uint_B;
                }

                Uint_A -= KeyArr_S[0];
                Uint_B -= KeyArr_S[1];

                Uint_A = Uint_A ^ Xor_A;
                Uint_B = Uint_B ^ Xor_B;
                Xor_A = Tmp_Uint_A;
                Xor_B = Tmp_Uint_B;

                BitConverter.GetBytes(Uint_A).CopyTo(RezArr, i * 8 + 0);
                BitConverter.GetBytes(Uint_B).CopyTo(RezArr, i * 8 + 8);
            }
            return RezArr;
        }

        //Алгоритм MD5
        public static byte[] MD5_Algo(string EncMes)
        {
            byte[] TaskArr = MD5_Step2(MD5_Step1(StringToByteArr(EncMes)), EncMes.Length);
            uint[] TaskIntArr = ByteArrToIntArr(TaskArr);
            return MD5_Step3_4(TaskIntArr, GenerateTable(), GenerateShifting());
        }
        //Перетворення стрічки у масив байтів
        public static byte[] StringToByteArr(string mes)
        {
            byte[] ReturnRez = new byte[mes.Length];
            for (int i = 0; i < mes.Length; i++)
            {
                ReturnRez[i] = (byte)mes[i];
            }
            return ReturnRez;
        }

        //Перший крок MD5
        public static byte[] MD5_Step1(byte[] mes)
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

        //Другий крок MD5
        public static byte[] MD5_Step2(byte[] mes, int meslen)
        {
            byte[] ReturnRez = new byte[mes.Length + 8];
            //к-сть бітів у повідомленні !!!!!!!
            byte[] Len = BitConverter.GetBytes(meslen * 8);
            mes.CopyTo(ReturnRez, 0);
            Len.CopyTo(ReturnRez, mes.Length);
            return ReturnRez;
        }

        //Третій і четвертий кроки MD5
        public static byte[] MD5_Step3_4(uint[] Mes, uint[] Table, int[] ShiftingArr)
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
            //BitConverter.ToString(RezArr).Replace("-", "");
            //return BitConverter.ToString(RezArr).Replace("-", "");
            return RezArr;
        }

        //Знаходження довжини масиву байтів для повідомлення на першому кроці MD5
        public static int FindSize(int len)
        {
            int start = 448;
            while (len >= start)
            {
                start += 512;
            }
            int rez = (start - len) / 8;
            return rez;
        }

        //Перетворення масиву байтів у uint
        public static uint[] ByteArrToIntArr(byte[] mes)
        {
            uint[] ReturnRez = new uint[mes.Length / 4];
            for (int i = 0; i < ReturnRez.Length; i++)
            {
                ReturnRez[i] = BitConverter.ToUInt32(mes, i * 4);
            }
            return ReturnRez;
        }

        //Перетворення масиву байтів у UInt64
        public static UInt64[] ByteArrToInt64Arr(byte[] mes)
        {
            UInt64[] ReturnRez = new UInt64[mes.Length / 8];
            for (int i = 0; i < ReturnRez.Length; i++)
            {
                ReturnRez[i] = BitConverter.ToUInt64(mes, i * 8);
            }
            return ReturnRez;
        }

        //Генерування табоиці із синусами
        public static uint[] GenerateTable()
        {
            uint[] Table_T = new uint[64];
            for (int i = 0; i < 64; i++)
            {
                Table_T[i] = (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)));
                //byte[] arr = BitConverter.GetBytes(Table_T[i]);
            }
            return Table_T;
        }

        //Циклічний зсув у MD5
        public static uint Shifting(uint num, int shift)
        {
            uint rez = (num << shift) | num >> (32 - shift);
            return rez;
        }

        //Циклічний зсув у RC5 вліво
        public static UInt64 RC5LeftShifting(UInt64 num, int shift)
        {
            UInt64 rez = (num << shift) | num >> (64 - shift);
            return rez;
        }
        //Циклічний зсув у RC5 вправо
        public static UInt64 RC5RightShifting(UInt64 num, int shift)
        {
            UInt64 rez = (num >> shift) | num << (64 - shift);
            return rez;
        }

        //Масив циклічного зсуву
        public static int[] GenerateShifting()
        {
            int[] ShiftingArr = { 7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,  7, 12, 17, 22,
                                  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,
                                  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,
                                  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21 };
            return ShiftingArr;
        }

        //Функція генерації псевдовипадкових чисел
        public static UInt64[] RandFunc(UInt64 NumCount)
        {
            UInt64[] InitVector = new UInt64[NumCount];
            UInt64 Param_A = (UInt64)Math.Pow(14, 3), Param_C = 2584, Param_M = (UInt64)Math.Pow(2, 27) - 1, Param_X = 17, Param_XN;
            UInt64 Param_X0 = Param_X;
            for (UInt64 i = 0; i < NumCount/*Param_M*/; i++)
            {
                Param_XN = (Param_A * Param_X + Param_C) % Param_M;
                InitVector[i] = Param_XN;
                Param_X = Param_XN;
            }
            return InitVector;
        }
    }
}
