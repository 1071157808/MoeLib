// ***********************************************************************
// Project          : MoeLib
// File             : Program.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-28  6:55 PM
// ***********************************************************************
// <copyright file="Program.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace MoeLibLab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HttpClientTest.TestAsync().Wait();
        }
    }
}