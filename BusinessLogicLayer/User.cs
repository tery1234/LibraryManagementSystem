﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLogicLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class User
    {

        private string userName;
        private string password;
        private int userTypeId;

      

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int UserTypeID
        {
            get { return userTypeId; }
            set { userTypeId = value; }
        }




        public bool UserLogin()
        {
            DataAccess DAL = new DataAccess();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@userName",
                    Value = userName,
                },

                new SqlParameter()
                {
                    ParameterName="@password",
                    Value=password
                },
            };

           return DAL.spExecuteWithReturnValues("SPValidateUser", parameters);
        }

        public int UserType()
        {
            DataAccess DAL = new DataAccess();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@userName",
                    Value = userName,
                },

                new SqlParameter()
                {
                    ParameterName="@password",
                    Value=password
                },
            };

            return DAL.SelectUserType("SPValidateUserType", parameters);

        }

    }
}
