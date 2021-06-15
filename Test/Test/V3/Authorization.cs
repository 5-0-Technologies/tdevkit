﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public partial class TestClass
    {
        //[TestMethod]
        public async Task A_Authenticate()
        {
            AuthenticationResponseContract auth = await devkitConnector.Authenticate(true);
            //Assert.IsNotNull(auth.Token);
        }

        //[TestMethod]
        public async Task A_DeleteToken()
        {
            HttpResponseMessage auth = await devkitConnector.DeleteCurrentToken();
        }
    }
}