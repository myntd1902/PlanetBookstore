﻿using System;
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
    }
}
