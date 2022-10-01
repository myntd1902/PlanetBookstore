using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetBook.Utility
{
    public static class SD
    {
        public const string Proc_CoverType_Create = "sp_CreateCoverType";
        public const string Proc_CoverType_Get = "sp_GetCoverType";
        public const string Proc_CoverType_GetAll = "sp_GetCoverTypes";
        public const string Proc_CoverType_Update = "sp_UpdateCoverType";
        public const string Proc_CoverType_Delete = "sp_DeleteCoverType";

        public const string Role_User_Indi = "Khách hàng cá nhân";
        public const string Role_User_Comp = "Khách hàng công ty";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Nhân viên";

        public const string ShoppingCart_Session = "Phiên giỏ hàng";

        public static double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if (quantity < 50)
            {
                return price;
            }
            else
            {
                if (quantity < 100)
                    return price50;
                else
                    return price100;
            }
        }

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

    }
}
