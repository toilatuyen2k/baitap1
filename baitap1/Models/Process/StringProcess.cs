using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace baitap1.Models.Process
{
    public class StringProcess
    {
        public string AutoGenerateKey(string id)
        {
            //tham số đầu vào STD001
            //khai báo tham số
            string numPart, strPart, newKey = "", newNumPart = "";
            int intNumber;
            //Bước 1 tách phần số và phần chữ => 2 phần STD và 001
            //Phần số numPart=001
            numPart = Regex.Match(id, @"\d+").Value;
            //Phần chữ strPart=STD
            strPart = Regex.Match(id, @"\D+").Value;
            //Chuyển phần số sang dạng số nguyên tăng phần số ;lên 1 đơn vị giá trị bằng 2
            intNumber = Convert.ToInt32(numPart) + 1;

            //sử dụng vòng lặp sd các số 00=> phần số mới 002
            for (int i = 0; i < numPart.Length - intNumber.ToString().Length; i++)
            {
                newNumPart += "0";
            }

            //Sinh ra mã từ dòng STD002
            //Gép phần chữ và phần số 
            newKey = strPart + newNumPart + intNumber;
            //Trả về giá trị k
            return newKey;
        }
    }
}